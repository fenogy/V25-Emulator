#region Copyright (c) ExcelTechnology Inc.

#region Disclaimer
//	ExcelTechnology Inc.
//	This program is protected by copyright law and by international
//	conventions. All licensing, renting, lending or copying (including
//	for private use), and all other use of the program, which is not
//	expressively permitted by ExcelTechnology Inc., is a violation of the rights
//	of ExcelTechnology Inc.. Such violations will be reported to the
//	appropriate authorities.
//	Violation of any copyright is punishable by law and can lead to 
//	imprisonment and liability to pay damages

#endregion //Disclaimer

#region Revision history

#endregion //Revision history

#endregion //Copyright (c) ExcelTechnology Inc.

using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;

namespace V25Emulator
{
    class DBManager
    {
        #region Fields

        #region Private

        // XML database. data set definitions
        private Configuration config = new Configuration();

        // Configuration file name
        private string configFileName = "";

        #endregion

        #region Public

        #endregion

        #endregion

        #region Methods

        #region Public
        #region Open/Save

        public bool OpenConfig(string fileName)
        {
            bool status = false;
            configFileName = fileName;

            try
            {
                config.ReadXml(fileName, XmlReadMode.ReadSchema);

                status = true;
            }
            catch (FileNotFoundException)
            {
                status = false;
            }
            return status;

        }

        public void SaveConfig()
        {
            config.WriteXml(configFileName, XmlWriteMode.WriteSchema);
        }
        #endregion


        #region Add new items


        public void AddShortcutButton(string[] buttonData)
        {
            config.ShortCutButton.Rows.Add(buttonData);
        }
        public void WriteDeviceConfig(object[] newDeviceContent)
        {
            config.Device.Rows.Add(newDeviceContent);
        }

        public void WriteSendPacketDataConfig(object[] newSendPacketDataContent)
        {
            config.SendPacketData.Rows.Add(newSendPacketDataContent);
        }

        public void WriteResponsePacketDataConfig(object[] newResponsePacketDataContent)
        {
            config.ResponsePacketData.Rows.Add(newResponsePacketDataContent);
        }

        public void AddNewRS232Setting(object[] newContent)
        {
            config.RS232Config.Rows.Add(newContent);
        }
		

        #endregion

        #region Update

        public void UpdateShortcutButton(string[] buttonData)
        {
            int count = config.ShortCutButton.Count;
            if (count != 0)
            {
                bool found = false;
                for (int i = 0; i < count; i++ )
                {
                    DataRow row = config.ShortCutButton.Rows[i];
                    int buttonId = Convert.ToInt32( row[0]);
                    if (buttonId == Convert.ToInt32(buttonData[0]))
                    {
                        row.ItemArray = buttonData;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    AddShortcutButton(buttonData);
                }
            }
            else
            {
                AddShortcutButton(buttonData);
            }
        }

        public void UpdatePollingList(string[] data)
        {
            config.PollingQ.Clear();
            for (int i = 0; i < data.Length; i++)
            {
                config.PollingQ.Rows.Add(data[i]);
            }
        }

        public void UpdateDevice(object[] newDeviceContent)
        {
            int count = config.Device.Count;
            if (count != 0)
            {
                bool found = false;
                for (int i = 0; i < count; i++)
                {
                    DataRow row = config.Device.Rows[i];

                    string device     = Convert.ToString(row[1]);
                    string newdevice  = Convert.ToString(newDeviceContent[1]);
                    string command    = Convert.ToString(row[2]);
                    string newCommand = Convert.ToString(newDeviceContent[2]);
                    if (( device == newdevice ) && ( command == newCommand ))
                    {
                        row.ItemArray = newDeviceContent;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    WriteDeviceConfig(newDeviceContent);
                }
            }
            else
            {
                WriteDeviceConfig(newDeviceContent);
            }
        }
        public void UpdateResponsePacketData(object[] newResponsePacketDataContent)
        {
            int count = config.ResponsePacketData.Count;
            if (count != 0)
            {
                 bool found = false;
                 for (int i = 0; i < count; i++)
                 {
                     DataRow row = config.ResponsePacketData.Rows[i];
                     int id = Convert.ToInt32(row[0]);
                     int Id = Convert.ToInt32(newResponsePacketDataContent[0]);
                     int bytePosition = Convert.ToInt32(row[2]);
                     int BytePosition = Convert.ToInt32(newResponsePacketDataContent[2]);
                     if((id == Id ) && ( bytePosition == BytePosition))
                     {
                        row.ItemArray = newResponsePacketDataContent;
                        found = true;
                        break;
                     }

                 }
                 if (!found)
                 {
                     WriteResponsePacketDataConfig(newResponsePacketDataContent);
                 }
            }
            else
            {
                WriteResponsePacketDataConfig(newResponsePacketDataContent);
            }
        }
        public void UpdateSendPacketData(object[] newSendPacketDataContent)
        {
            int count = config.SendPacketData.Count;
            if (count != 0)
            {
                bool found = false;
                for (int i = 0; i < count; i++)
                {
                    DataRow row = config.SendPacketData.Rows[i];
                    int id = Convert.ToInt32(row[0]);
                    int Id = Convert.ToInt32(newSendPacketDataContent[0]);
                    int bytePosition = Convert.ToInt32(row[2]);
                    int BytePosition = Convert.ToInt32(newSendPacketDataContent[2]);
                    if ((id == Id) && (bytePosition == BytePosition))
                    {
                        row.ItemArray = newSendPacketDataContent;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    WriteSendPacketDataConfig(newSendPacketDataContent);
                }
            }
            else
            {
                WriteSendPacketDataConfig(newSendPacketDataContent);
            }
        }

        public void UpdateRS232Settings(object[] new232SettingsContent)
        {
            int count = config.RS232Config.Count;
            if (count != 0)
            {
                DataRow row = config.RS232Config.Rows[0];
                row.ItemArray = new232SettingsContent;
            }
            else
            {
                AddNewRS232Setting(new232SettingsContent);
            }

        }
        #endregion

        #region Read
        #region RS232 Settings

        public object[] ReadRS232Config()
        {
            try
            {
                DataRow row = config.RS232Config.Rows[0];
                return row.ItemArray;
            }
            catch
            {
                return null;
            }
        }

        public int GetDeviceId(string deviceAddress , string command)
        {
            string filter = "Address = '" + deviceAddress + "' AND Command = '" + command + "'";
            config.Device.DefaultView.RowFilter = filter;
            try
            {
                return (int)config.Device.DefaultView[0].Row.ItemArray[0];
            }
            catch
            {
                return 0;
            }
        }

        public string[] GetPollingListData()
        {
            string [] polingList = new string[config.PollingQ.Count];
            for (int i = 0; i < polingList.Length; i++)
            {
                polingList[i] = config.PollingQ.Rows[i][0].ToString();
            }
            return polingList;
        }

        public ArrayList GetAvailableCommands(string deviceAddress)
        {
            string filter = "Address = '" + deviceAddress + "'";
            config.Device.DefaultView.RowFilter = filter;
            config.Device.DefaultView.Sort = "Command";
          
            ArrayList commandList = new ArrayList(config.Device.DefaultView.Count);
            for(int i = 0;i < config.Device.DefaultView.Count ; i++)
            {
                commandList.Add(config.Device.DefaultView[i][2]);
            }
            return commandList;
        }
        public string GetDeviceDescription(string deviceAddress , string command)
        {
            string filter = "Address = '" + deviceAddress + "' AND Command = '" + command + "'";
            config.Device.DefaultView.RowFilter = filter;
            if (config.Device.DefaultView.Count > 0)
            {
                return config.Device.DefaultView[0].Row.ItemArray[3].ToString();
            }
            return null;
        }

        public object [] ReadSendPacketData(int Id)
        {
            string filter = "Id =" + Id;
            config.SendPacketData.DefaultView.RowFilter = filter;
            object[] dataRows = new object[config.SendPacketData.DefaultView.Count];

            for (int i = 0; i < config.SendPacketData.DefaultView.Count; i++ )
            {
                dataRows[i] = config.SendPacketData.DefaultView[i].Row.ItemArray;
            }
            return dataRows;
        }
        public object[] ReadResponsePacketData(int Id)
        {
            string filter = "Id =" + Id;
            config.ResponsePacketData.DefaultView.RowFilter = filter;
            object[] dataRows = new object[config.ResponsePacketData.DefaultView.Count];

            for (int i = 0; i < config.ResponsePacketData.DefaultView.Count; i++)
            {
                dataRows[i] = config.ResponsePacketData.DefaultView[i].Row.ItemArray;
            }
            return dataRows;
        }
        
        public object[] ReadShortcutButton(int buttonId)
        {
            string filter = "ButtonId =" + buttonId;
            config.ShortCutButton.DefaultView.RowFilter = filter;
            if (config.ShortCutButton.DefaultView.Count > 0)
            {
                return config.ShortCutButton.DefaultView[0].Row.ItemArray;
            }
            return null;
        }
        public string ReadShortcutButtonName(int buttonId)
        {
            string filter = "ButtonId =" + buttonId;
            config.ShortCutButton.DefaultView.RowFilter = filter;
            if (config.ShortCutButton.DefaultView.Count > 0)
            {
                string buttonName = "";
                buttonName = config.ShortCutButton.DefaultView[0].Row.ItemArray[1].ToString();
                return buttonName;
            }
            return null;
        }

        #endregion
        #region Remove
        public bool RemoveCommand(string deviceAddress , string command)
        {
            int Id = GetDeviceId(deviceAddress, command);
            string filter = "Address = '" + deviceAddress + "' AND Command = '" + command + "'";
            config.Device.DefaultView.RowFilter = filter;
            for (int i = 0; i < config.Device.DefaultView.Count; i++ )
            {
                config.Device.DefaultView.Delete(i);
            }
                      
            RemoveResponsePackets(Id);
            RemoveSendPackets(Id);
            return true;
        }
        public bool RemoveResponsePackets(int Id)
        {
           
            string filter = "Id =" + Id;
            config.ResponsePacketData.DefaultView.RowFilter = filter;
            //config.ResponsePacketData.DefaultView.Count;
            for (int i = 0; i < config.ResponsePacketData.DefaultView.Count; i = i)
            {
                config.ResponsePacketData.DefaultView.Delete(i);

            }
            return true;
        }
        public bool RemoveSendPackets(int Id)
        {
            
            string filter = "Id =" + Id;
            config.SendPacketData.DefaultView.RowFilter = filter;
            //count = config.SendPacketData.DefaultView.Count;
            for (int i = 0; i < config.SendPacketData.DefaultView.Count; i = i)
            {
                config.SendPacketData.DefaultView.Delete(i);

            }
            return true;
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}
