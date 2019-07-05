using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace V25Emulator
{
    public partial class ResponsePacketCreateForm : Form
    {
        #region Local Fields
        private string configFileName = "SystemConfig.xml";
        private DBManager dbMgr;
        private  ArrayList dataBytes  = new ArrayList();
        #endregion
        public ResponsePacketCreateForm()
        {
            InitializeComponent();
            InitializeForm();
          
        }
        #region Methods
        private void InitializeForm ()
        {
            dbMgr = new DBManager();
            
            comboBoxDeviceAddress.DataSource = Enum.GetValues(typeof(DeviceAddresses));
            if (dbMgr.OpenConfig(configFileName))
            {
                ArrayList deviceCommandList = dbMgr.GetAvailableCommands(comboBoxDeviceAddress.SelectedValue.ToString());
                comboBoxCommand.DataSource  = deviceCommandList;
            }

            for (int i = 0; i < 12; i++ )
            {
                CustomByteData customBytedata = new CustomByteData();
                // 
                // customByteData
                // 
                
                customBytedata.Location = new System.Drawing.Point(27, 200 + i * 30);
                customBytedata.Name     = "customByteData1";
                customBytedata.Size     = new System.Drawing.Size(500, 37);
                customBytedata.TabIndex = 6+i;
                customBytedata.TxtDataDescription = "";
                dataBytes.Add(customBytedata);
                this.Controls.Add(customBytedata);
               
            }
            try
            {
                comboBoxCommand.SelectedIndex = comboBoxCommand.Items.Count-1;
            }
            catch
            {

            }
        }
        private bool SaveDataBytes(int Id)
        {
            object[] responsePacketData = new object[5];
            responsePacketData[0] = Id;

            dbMgr.RemoveResponsePackets(Id);
            for (int i = 0; i < dataBytes.Count; i++)
            {
                if (((CustomByteData)dataBytes[i]).TxtDataDescription != "")
                {
                    responsePacketData[1] = ((CustomByteData)dataBytes[i]).DataTypeTag;
                    responsePacketData[2] = 2 + i;
                    responsePacketData[3] = ((CustomByteData)dataBytes[i]).TxtDataDescription;
                    responsePacketData[4] = ((CustomByteData)dataBytes[i]).DataTag;
                    dbMgr.UpdateResponsePacketData(responsePacketData);
                }
                else
                {
                    break;
                }
            }
            return true;
        }
       
        #region Events

        #region button events
        private void buttonSave_Click(object sender, EventArgs e)
        {
            object[] deviceConfig = new object[4];
            deviceConfig[0] = null;
            deviceConfig[1] = comboBoxDeviceAddress.SelectedValue;
            deviceConfig[2] = comboBoxCommand.Text;
            deviceConfig[3] = textBoxCommandDesc.Text;
            dbMgr.UpdateDevice(deviceConfig);
            int Id = dbMgr.GetDeviceId(comboBoxDeviceAddress.SelectedValue.ToString(), comboBoxCommand.Text);
            SaveDataBytes(Id);
            dbMgr.SaveConfig();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void comboBoxDeviceAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCommand.DataSource = null;
            ArrayList deviceCommandList = dbMgr.GetAvailableCommands(comboBoxDeviceAddress.SelectedValue.ToString());
            comboBoxCommand.DataSource = deviceCommandList;
        }

        private void comboBoxCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCommand.SelectedValue != null && dataBytes.Count > 0)
            {
                textBoxCommandDesc.Text = dbMgr.GetDeviceDescription(comboBoxDeviceAddress.SelectedValue.ToString(), comboBoxCommand.SelectedValue.ToString());
                int Id = dbMgr.GetDeviceId(comboBoxDeviceAddress.SelectedValue.ToString(), comboBoxCommand.Text);
                object[] readByteData = dbMgr.ReadResponsePacketData(Id);
                for (int i = 0; i < dataBytes.Count; i++)
                {
                    ((CustomByteData)dataBytes[i]).DataTypeTag = DataType.Address.ToString();
                    ((CustomByteData)dataBytes[i]).TxtDataDescription = "";
                    ((CustomByteData)dataBytes[i]).DataTag = ByteDataTag.EightBitSingle.ToString();
                }
                for (int i = 0; i < readByteData.Length; i++)
                {
                    object[] tempObject = (object[])(readByteData[i]);

                    ((CustomByteData)dataBytes[i]).DataTypeTag = (string)tempObject[1];
                    ((CustomByteData)dataBytes[i]).TxtDataDescription = (string)tempObject[3];
                    ((CustomByteData)dataBytes[i]).DataTag = (string)tempObject[4];
                }
            }
            else
            {
                textBoxCommandDesc.Text = "";
            }
        }
        #endregion

        #endregion

        #region Properties
        public string ConfigFileName
        {
            set
            {
                configFileName = value;
            }
            get
            {
                return configFileName;
            }
        }
        #endregion

    }
}