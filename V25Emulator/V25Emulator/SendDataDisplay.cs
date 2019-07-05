using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace V25Emulator
{
    public partial class SendDataDisplay : UserControl
    {
        #region Variables
        private DBManager dbMgr ;
        private string configFilePath = "systemConfig.xml";
        ArrayList dataBytes;
        private bool hexDisplay = false;
        #endregion

        #region Constructor
        public SendDataDisplay()
        {
            InitializeComponent();

        }
        #endregion

        #region Methods
        public void RefreshAll(string deviceAddress , string command)
        {
            dbMgr = new DBManager();
            Controls.Clear();
            dataBytes = new ArrayList();

            if (dbMgr.OpenConfig(configFilePath))
            {

                int Id = dbMgr.GetDeviceId(deviceAddress, command);
                object[] sendPacketData = dbMgr.ReadSendPacketData(Id);

                for (int i = 0; i < sendPacketData.Length; i++ )
                {
                    string dataTagType     = (((object[])sendPacketData[i])[4].ToString());
                    string dataTypeNibble  = ByteDataTag.EightBitNibble.ToString();

                    if (dataTagType == ByteDataTag.EightBitSingle.ToString())
                    {

                        UserInputData userInputData1 = new V25Emulator.UserInputData();
                        userInputData1.LabelName   = (string)(((object [])sendPacketData[i])[1]);

                        if (i > 0)
                        {
                            if (((object[])sendPacketData[i - 1])[4].ToString() == dataTypeNibble)
                            {
                                userInputData1.Location = new System.Drawing.Point(20, 10 + 30 * (i-1));
                            }
                            else
                            {
                                userInputData1.Location = new System.Drawing.Point(20, 10 + 30 * i);
                            }
                        }
                        else
                        {
                            userInputData1.Location = new System.Drawing.Point(20, 10 + 30 * i);
                        }
                        userInputData1.Name        = "userInputData1";
                        userInputData1.Size        = new System.Drawing.Size(205, 34);
                        userInputData1.TabIndex    = 0;
                        userInputData1.TextBoxData = "";
                        dataBytes.Add( userInputData1 );
                        Controls.Add(userInputData1);
                    }
                    else
                        if (dataTagType == dataTypeNibble && (((object[])sendPacketData[i + 1])[4].ToString()) == dataTypeNibble)
                        {
                            UserInputData userInputData1 = new V25Emulator.UserInputData();
                            userInputData1.LabelName     = (string)(((object[])sendPacketData[i])[1]);

                            if (dataBytes.Count >= 1)
                            {
                                userInputData1.Location  = new System.Drawing.Point(20, ((UserInputData)dataBytes[dataBytes.Count - 1]).Location.Y + 30 );
                            }
                            else
                            {
                                userInputData1.Location  = new System.Drawing.Point(20, 10 + 30 * i);
                            }
                            userInputData1.Name          = "userInputData1";
                            userInputData1.Size          = new System.Drawing.Size(205, 34);
                            userInputData1.TabIndex      = 0;
                            userInputData1.TextBoxData   = "";
                            dataBytes.Add(userInputData1);
                            Controls.Add(userInputData1);
                            i++;
                        }
                }
            }
        }

        public void SetDisplayMethod(bool displayInHex)
        {
            hexDisplay = displayInHex;
            if (dataBytes != null)
            {
            for (int i = 0; i < dataBytes.Count; i++)
              {
                  ((UserInputData)dataBytes[i]).HexEnable = displayInHex;
              }
            }
        }

        public ArrayList GetDataByteValues()
        {
            ArrayList tempArray = new ArrayList();
            for(int i =0;i < dataBytes.Count;i++)
            {

                tempArray.Add(((UserInputData)dataBytes[i]).TextBoxData);
            }
            return tempArray;
        }

        public void SetDataByteValues(ArrayList dataArray)
        {
            for (int i = 0; i < dataBytes.Count; i++)
            {

                ((UserInputData)dataBytes[i]).TextBoxData = (string)dataArray[i];
            }
        }

        #endregion

        #region Properties
        public string ConfigFilePath
        {
            set
            {
                configFilePath = value;
            }
            get
            {
                return configFilePath;
            }
        }

        public ArrayList DataByte
        {
            set
            {
                dataBytes = value;
            }
            get
            {
                return dataBytes;
            }
        }
        
        #endregion
    }
}
