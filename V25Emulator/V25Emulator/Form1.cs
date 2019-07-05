using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace V25Emulator
{
    public delegate void SetDataDelegate(System.Windows.Forms.Control ctrl, ArrayList data);
    public partial class Form1 : Form
    {
        #region Local Fields
        private string configFileName = Application.StartupPath.ToString() + "\\SystemConfig.xml";
        private DBManager dbMgr;
        private V25Controller v25controller;
        private bool hexDisplayEnable   = true;
        private bool startPolling       = false;
        private bool commthreadRunnning = false;
        private bool commConnected      = false;
        #endregion
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }
        #endregion 

        #region Methods

        #region Private Methods
        private void Initialize()
        {
            // Set the view to show details.
            comboBoxDeviceType.DataSource   = Enum.GetValues(typeof(DeviceAddresses));
            listViewCaptureQ.View           = View.Details;
            sendDataDisplay1.ConfigFilePath = configFileName;
            FillCommandBox();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            string[] buttonNames = new string[5];
            for (int i = 0; i < 5; i++)
            {
                buttonNames[i] = dbMgr.ReadShortcutButtonName(i + 1);
                
            }
            if(buttonNames[0] != null)
                shortcutButton1.Text = buttonNames[0];
            if (buttonNames[1] != null)
                shortcutButton2.Text = buttonNames[1];
            if (buttonNames[2] != null)
                shortcutButton3.Text = buttonNames[2];
            if (buttonNames[3] != null)
                shortcutButton4.Text = buttonNames[3];
            if (buttonNames[4] != null)
                shortcutButton5.Text = buttonNames[4];
        }
        private void FillCommandBox()
        {
            dbMgr = new DBManager();
            dbMgr.OpenConfig(configFileName);
            ArrayList deviceCommandList = dbMgr.GetAvailableCommands(comboBoxDeviceType.Text);
            comboBoxCommand.DataSource = null;
            comboBoxCommand.DataSource = deviceCommandList;
           // comboBoxCommand.Sorted = true;
        }

        private void RecievedDataProcess(ArrayList data)
        {
            SetData(this, data);
        }
        private void SaveCurrentCapturedData()
        {
            string fileName = "";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; 
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               fileName = saveFileDialog.FileName;
               StreamWriter streamWriter = new StreamWriter(fileName);
               for (int i = 0; i < listViewCaptureQ.Items.Count; i++)
               {
                   string curLine = listViewCaptureQ.Items[i].SubItems[0].Text;
                   curLine += " \t" + listViewCaptureQ.Items[i].SubItems[1].Text;
                   curLine += " \t" + listViewCaptureQ.Items[i].SubItems[2].Text;
                   curLine += " \t" + listViewCaptureQ.Items[i].SubItems[3].Text;
                   curLine += " \t" + listViewCaptureQ.Items[i].SubItems[4].Text;
                   curLine += " \t" + listViewCaptureQ.Items[i].SubItems[5].Text;
                   streamWriter.WriteLine(curLine);
               }
               streamWriter.Close();
            }
            
        }

        private void SetData(System.Windows.Forms.Control ctrl, ArrayList data)
        {
            if (data.Count == 0)
                return;

            if (ctrl.InvokeRequired)
            {
                object[] paramList = new object[] { ctrl, data };
                ctrl.Invoke(new SetDataDelegate(SetData), paramList);
            }
            else
            {
                string packet = listViewCaptureQ.Items.Count.ToString();
                ListViewItem item = new ListViewItem(packet, 0);
                          
                DateTime dt = DateTime.Now;
                string time = dt.Second.ToString() + "." + DateTime.Now.Millisecond.ToString("000");
                item.SubItems.Add(time);
                item.SubItems.Add(data[0].ToString());
                item.SubItems.Add(data[1].ToString());
                item.SubItems.Add(data[2].ToString());
                string dataString = "";
                for (int i = 3; i < data.Count; i++)
                {
                    dataString += " " + data[i].ToString();
                }
                item.SubItems.Add(dataString);
                listViewCaptureQ.Items.Add(item);
                listViewCaptureQ.Items[listViewCaptureQ.Items.Count - 1].EnsureVisible();
                if (data[0].ToString() == "Read")
                {
                    listViewCaptureQ.Items[listViewCaptureQ.Items.Count - 1].Selected = true;
                }
            }

        }

        private void SendButtonCommand(object[] commandData)
        {
            if (commandData != null)
            {
                string data = commandData[2].ToString();
                string[] cmd = data.Split(new char[] { ',' });
                ArrayList dataBytes = new ArrayList();
                for (int i = 2; i < cmd.Length; i++)
                {
                    dataBytes.Add(cmd[i]);
                }
                v25controller.SendCMD(cmd[0], cmd[1], dataBytes);
            }
        }

        #region events
       
        private void comboBoxCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
               sendDataDisplay1.RefreshAll(this.comboBoxDeviceType.Text, this.comboBoxCommand.Text);
               sendDataDisplay1.SetDisplayMethod(hexDisplayEnable);
        }

        private void comboBoxDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCommandBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            v25controller = new V25Controller();
            buttonHex_Dec.Text = "Decimal";
            
            sendDataDisplay1.SetDisplayMethod(hexDisplayEnable);
            v25controller.ConfigFilePath = configFileName;
            v25controller.FillInitialPollingQ();
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            v25controller.Uninit();
        }

        private void buttonPolling_Click(object sender, EventArgs e)
        {
            if (startPolling)
            {
                startPolling = false;
                v25controller.StartPolling(startPolling);
                buttonPolling.Text = "Start Polling";
            }
            else
            {
                startPolling = true;
                v25controller.StartPolling(startPolling);
                buttonPolling.Text = "Stop Polling";
            }
        }
        
        private void listViewCaptureQ_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int index      = e.Item.SubItems.Count;
            string data    = e.Item.SubItems[index - 1].Text;
            string device  = e.Item.SubItems[3].Text;
            string command = e.Item.SubItems[4].Text;
            richtextBoxDataDetails.Text = v25controller.GetDataPacketDetails(device, command, e.Item.SubItems[2].Text, data);
            if (e.Item.SubItems[2].Text == "Write")
            {
                string[] split  = data.Split(new char[] { ' ' });
                byte[] response = new byte[split.Length + index - 7];
                response[0]     = Convert.ToByte(Convert.ToInt32(device, 16));
                response[1]     = Convert.ToByte(Convert.ToInt32(command, 16));
                for (int i = 0; i < split.Length - 3; i++)
                {
                    response[i + 2] = Convert.ToByte(Convert.ToInt32(split[i + 1], 16));
                }
                ArrayList decodeArray = v25controller.DecodeResponse2(response);
                object deviceValue    = "";
                switch (device)
                {
                    case "10":
                        deviceValue = DeviceAddresses.SmartBord;
                        break;
                    case "13":
                        deviceValue = DeviceAddresses.BackPlane;
                        break;
                }

                comboBoxDeviceType.SelectedItem = (object)deviceValue;
                comboBoxCommand.SelectedItem    = (object)("0x" + command);

                ArrayList tempSendArray = new ArrayList();
                for (int i = 0; i < sendDataDisplay1.DataByte.Count; i++)
                {
                    tempSendArray.Add( decodeArray[i].ToString());
                }
                sendDataDisplay1.SetDataByteValues(tempSendArray);

            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ArrayList databytes = new ArrayList();
           
            databytes = sendDataDisplay1.GetDataByteValues();
            string device = comboBoxDeviceType.Text;
            string command = comboBoxCommand.Text;
            command = command.Remove(0, 2);
            v25controller.SendCMD(device, command, databytes);
        }

        private void buttonHex_Dec_Click(object sender, EventArgs e)
        {
            if (hexDisplayEnable)
            {
                buttonHex_Dec.Text = "Hex";
                hexDisplayEnable = false;
                sendDataDisplay1.SetDisplayMethod(hexDisplayEnable);
            }
            else
            {
                buttonHex_Dec.Text = "Decimal";
                hexDisplayEnable = true;
                sendDataDisplay1.SetDisplayMethod(hexDisplayEnable);
            }
        }

        private void buttonAddToQ_Click(object sender, EventArgs e)
        {
            ArrayList databytes = new ArrayList();
          
            databytes = sendDataDisplay1.GetDataByteValues();
            string device = comboBoxDeviceType.Text;
            string command = comboBoxCommand.Text;
            command = command.Remove(0, 2);

            v25controller.AddToPollingQueue(device, command, databytes);
        }

        private void buttonAddToShortcut_Click(object sender, EventArgs e)
        {
            AddToShortcutForm addButtonFrm = new AddToShortcutForm();
            addButtonFrm.ShowDialog(); 
            
            if (addButtonFrm.DialogResult == DialogResult.OK)
            {
                int buttonId        = addButtonFrm.SelectedButtonIndex + 1;
                
                string buttonText   = addButtonFrm.ButtonText;
                ArrayList databytes = new ArrayList();
          
                databytes      = sendDataDisplay1.GetDataByteValues();
                string device  = comboBoxDeviceType.Text;
                string command = comboBoxCommand.Text;
                command        = command.Remove(0, 2);
                switch (buttonId)
                {
                    case 1:
                        {
                            shortcutButton1.Text = buttonText;
                            break;
                        }
                    case 2:
                        {
                            shortcutButton2.Text = buttonText;
                            break;
                        }
                    case 3:
                        {
                            shortcutButton3.Text = buttonText;
                            break;
                        }
                    case 4:
                        {
                            shortcutButton4.Text = buttonText;
                            break;
                        }
                    case 5:
                        {
                            shortcutButton5.Text = buttonText;
                            break;
                        }
                }
                v25controller.AddToButton(buttonId.ToString(), buttonText, device, command, databytes);
                dbMgr = new DBManager();
                dbMgr.OpenConfig(configFileName);
            }

        }

        /*private void buttonStop_Click(object sender, EventArgs e)
        {
            if (!commthreadRunnning && commConnected)
            {
                v25controller.StartComm();
                buttonStop.Text = "Stop Comm";
                commthreadRunnning = true;
            }
            else
            {
                v25controller.StopComm();
                buttonStop.Text = "Start Comm";
                commthreadRunnning = false;
            }
        }*/
        #region Shortcut Button Events
        private void shortcutButton1_Click(object sender, EventArgs e)
        {
            object[] commandData = dbMgr.ReadShortcutButton(1);
            SendButtonCommand(commandData);
        }

        private void shortcutButton2_Click(object sender, EventArgs e)
        {
            object[] commandData = dbMgr.ReadShortcutButton(2);
            SendButtonCommand(commandData);
        }

        private void shortcutButton3_Click(object sender, EventArgs e)
        {
            object[] commandData = dbMgr.ReadShortcutButton(3);
            SendButtonCommand(commandData);
        }

        private void shortcutButton4_Click(object sender, EventArgs e)
        {
            object[] commandData = dbMgr.ReadShortcutButton(4);
            SendButtonCommand(commandData);
        }

        private void shortcutButton5_Click(object sender, EventArgs e)
        {
            object[] commandData = dbMgr.ReadShortcutButton(5);
            SendButtonCommand(commandData);
        }
        private void buttonClearQ_Click(object sender, EventArgs e)
        {
            listViewCaptureQ.Items.Clear();
            richtextBoxDataDetails.Clear();
        }
        #endregion

        #region Menu

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCommandFromPollingQForm rcfpollQfrm = new RemoveCommandFromPollingQForm();
            rcfpollQfrm.PollingList = v25controller.PollingList;
            rcfpollQfrm.ShowDialog();
            v25controller.SavePollingQ();
        }

        private void commandWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommandPacketCreateForm CmdPacketCreateFrm     = new CommandPacketCreateForm();
            CmdPacketCreateFrm.ConfigFileName              = configFileName;
            CmdPacketCreateFrm.ShowDialog();
            ResponsePacketCreateForm responsePcktCreateFrm = new ResponsePacketCreateForm();
            responsePcktCreateFrm.ConfigFileName           = configFileName;
            responsePcktCreateFrm.ShowDialog();
            FillCommandBox();
        }

        private void commSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingFrm   = new SettingsForm();
            settingFrm.configFilePath = configFileName;
            settingFrm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearCaptureQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewCaptureQ.Items.Clear();
            richtextBoxDataDetails.Clear();
        }
        private void connectCommToolStripMenuItem_Click(object sender, EventArgs e)
        {
                     
            if ((v25controller.CommThreadState == ThreadState.Unstarted || v25controller.CommThreadState == ThreadState.Stopped) && !commConnected)
            {
                commConnected = v25controller.Init();
                v25controller.SubscribeToDataRecieved += new UpdateValuesEvent(RecievedDataProcess);
                if (commConnected)
                connectCommToolStripMenuItem.Text = "Disconnect Comm";
            }
            else
            {
                v25controller.Uninit();
                v25controller.SubscribeToDataRecieved -= new UpdateValuesEvent(RecievedDataProcess);
                connectCommToolStripMenuItem.Text = "Connect Comm";
                commConnected = false;
            }
        }
        #endregion

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveCurrentCapturedData();
        }

        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

      
       

        #endregion

        private void buttonCommConnect_Click(object sender, EventArgs e)
        {
            if ((v25controller.CommThreadState == ThreadState.Unstarted || v25controller.CommThreadState == ThreadState.Stopped) && !commConnected)
            {
                commConnected = v25controller.Init();
                v25controller.SubscribeToDataRecieved += new UpdateValuesEvent(RecievedDataProcess);
                if (commConnected)
                {
                    connectCommToolStripMenuItem.Text = "Disconnect Comm";
                    textBoxComm.BackColor  = Color.LimeGreen;
                    buttonCommConnect.Text = "Disconnect Comm";
                }
            }
            else
            {
                v25controller.Uninit();
                v25controller.SubscribeToDataRecieved -= new UpdateValuesEvent(RecievedDataProcess);
                connectCommToolStripMenuItem.Text = "Connect Comm";
                commConnected = false;
                textBoxComm.BackColor = Color.Red;
                buttonCommConnect.Text = "Connect Comm";
            }
        }

        #endregion
      
    }
}