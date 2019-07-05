using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;

namespace V25Emulator
{
    // Public delegate for notifing New Data Recieving
    public delegate void UpdateValuesEvent(ArrayList data);

    class V25Controller
    {
        #region Variables
        private string configFileName = "SystemConfig.xml";
        private DBManager dbMgr;
        private bool running		  = false; // Run Flag
        private ArrayList inQ         = new ArrayList();// The Command Queue
        private UpdateValuesEvent updateValueRecievedEvent;
        private Thread commThread;
        private ArrayList pollingList = new ArrayList(); //The Polling list
        private int lastIndex         = 0; // Iterator for Polling list
        private bool startPolling     = false;

        public RS232Connector commMgr;
        public RS232Settings rs232CommSettings;
        ManualResetEvent manualEvent;

        #endregion

        #region Methods
        public V25Controller()
        {
            manualEvent = new ManualResetEvent(false);
            
        }
        #region Public Methods

        #region Init /Uninit
        public bool Init()
        {
            
           // if (dbMgr.OpenConfig(configFileName))
            Object[] settings;
            if ( (settings  = dbMgr.ReadRS232Config()) != null)
            {
                rs232CommSettings = new RS232Settings(settings);
                commMgr           = new RS232Connector();
               // commMgr.Init(rs232CommSettings.ToArray());
            }
            else
            {
                rs232CommSettings = new RS232Settings();
                commMgr = new RS232Connector();
                
            }
            FillInitialPollingQ();
            if (running = commMgr.Init(rs232CommSettings.ToArray()))
            {
             commThread = new Thread(new ThreadStart(MainProcess));
             commThread.Name = "Communication Thread";
             commThread.Start();
            }
            
            //commMgr.RecieveDataEvent += new RecieveDataDelegate(TreatRecievedData);
            return running;
        }

        public void Uninit()
        {
            if (commThread != null)
            {
           //     commMgr.RecieveDataEvent -= new RecieveDataDelegate(TreatRecievedData);
                commMgr.UnInit();
                commThread.Abort();
                commThread.Join();
            }
        }

        #endregion

        public void StartComm()
        {
            manualEvent.Set();
            /* if (commThread.ThreadState == ThreadState.Unstarted)
            {
                commThread.Start();
            }
            else
                if(commThread.ThreadState == ThreadState.Suspended)
            {
                commThread.Resume();
            }*/
        }

        public void StopComm()
        {
            manualEvent.Reset();
            /*if (commThread.ThreadState == ThreadState.WaitSleepJoin)
            {
                commThread.Suspend();
            }*/
        }

        public ArrayList DecodeResponse(byte [] response)
        {
            //response.
            string deviceAddress    =  DecimalToBase((int)response[0], 16);
            ArrayList responseArray = new ArrayList();
            ArrayList decodedArray  = new ArrayList();
            if (response.Length > 3)
            {
                responseArray.Add("Read");
                responseArray.Add(deviceAddress);
                deviceAddress = "0x" + deviceAddress;
                switch (deviceAddress)
                {
                    case "0x10":
                        deviceAddress = DeviceAddresses.SmartBord.ToString();
                        break;
                    case "0x13":
                        deviceAddress = DeviceAddresses.BackPlane.ToString();
                        break;
                }
                string command = DecimalToBase((int)response[1], 16);

                responseArray.Add(command);
                command = "0x" + command;
                byte checkSum = CalculateCheckSome(response, response.Length - 2);
              //  if (checkSum == response[response.Length - 2]) /// check the check sum and verify the recieved data
                {
                    int id = dbMgr.GetDeviceId(deviceAddress, command);
                    object[] responseData = dbMgr.ReadResponsePacketData(id);
                    for (int i = 2; i < response.Length; i++)
                    {
                        responseArray.Add(DecimalToBase((int)response[i], 16));
                    }

                    for (int i = 0; i < responseData.Length; i++)
                    {
                        string byteDataTag = ((object[])responseData[i])[4].ToString();
                        if (byteDataTag == ByteDataTag.EightBitSingle.ToString())
                        {
                            int byteValue = (response[i] & 0x7f); // remove the 7 th bit
                            decodedArray.Add(byteValue);
                        }
                        else
                            if (byteDataTag == ByteDataTag.EightBitNibble.ToString() && (((object[])responseData[i + 1])[4].ToString()) == ByteDataTag.EightBitNibble.ToString())
                            {
                                int databyte = response[i] & 0x0f;
                                databyte     = databyte << 4;
                                int lsb      = response[i + 1] & 0x0f;
                                databyte     = databyte | lsb;
                                decodedArray.Add(databyte);
                                i++;
                            }
                    }
                }

                UpdateDataRecieved(responseArray);
            }
            return decodedArray;
        }

        public ArrayList DecodeResponse2(byte[] response)
        {
            string deviceAddress   = DecimalToBase((int)response[0], 16);
            ArrayList decodedArray = new ArrayList();
            deviceAddress          = "0x" + deviceAddress;
            
            switch (deviceAddress)
            {
                case "0x10":
                    deviceAddress = DeviceAddresses.SmartBord.ToString();
                    break;
                case "0x13":
                    deviceAddress = DeviceAddresses.BackPlane.ToString();
                    break;
            }
            string command = DecimalToBase((int)response[1], 16);
            command = "0x" + command;
           
                int id = dbMgr.GetDeviceId(deviceAddress, command);
                object[] responseData = dbMgr.ReadSendPacketData(id);
                
                for (int i = 0; i < responseData.Length; i++)
                {
                    string byteDataTag = ((object[])responseData[i])[4].ToString();
                    string eightBitNibble = ByteDataTag.EightBitNibble.ToString();
                    if (byteDataTag == ByteDataTag.EightBitSingle.ToString())
                    {
                        int byteValue = (response[i + 2] & 0x7f); // remove the 7 th bit
                        decodedArray.Add(byteValue);
                    }
                    else
                        if (byteDataTag == eightBitNibble && (((object[])responseData[i + 1])[4].ToString()) == eightBitNibble)
                        {
                            int databyte = response[i + 2] & 0x0f;
                            databyte     = databyte << 4;
                            int lsb      = response[i + 3] & 0x0f;
                            databyte     = databyte | lsb;
                            decodedArray.Add(databyte);
                            i++;
                        }
                }
            return decodedArray;
        }

        public string GetDataPacketDetails(string device, string command, string operation, string data)
        {
           
            switch (device)
            {
                case "10":
                    device = DeviceAddresses.SmartBord.ToString();
                    break;
                case "13":
                    device = DeviceAddresses.BackPlane.ToString();
                    break;
            }
            int id = dbMgr.GetDeviceId(device, "0x" + command);
            object[] dataPacketDetails;
            if (operation == "Read")
            {
                dataPacketDetails = dbMgr.ReadResponsePacketData(id);
            }
            else
            {
                dataPacketDetails = dbMgr.ReadSendPacketData(id);
            }
            string[] splitData = data.Split(new char[] { ' ' });
            string returnString = "";
            for (int i = 0; i < dataPacketDetails.Length; i++)
            {
                try
                {
                    string dataName = ((object[])dataPacketDetails[i])[3].ToString();
                    string intValue = Convert.ToUInt32(splitData[i + 1], 16).ToString();
                    string hexValue = " (0x" + splitData[i + 1] + ")";
                    returnString += dataName + " = " + intValue + hexValue + "\n";
                }
                catch
                {
                }
            }
            return returnString;
        }

        public void AddToPollingQueue(string device, string command, ArrayList dataBytes)
        {
            byte[] encodedBytes = EncodeDataBytes(device, command, dataBytes);
            if (encodedBytes != null)
            {
                byte[] cmd = new byte[encodedBytes.Length + 4];
                cmd[0]     = (byte)(int)Enum.Parse(typeof(DeviceAddresses), device);
                cmd[1]     = (byte)int.Parse(command, System.Globalization.NumberStyles.HexNumber); ;
                encodedBytes.CopyTo(cmd, 2);
                cmd[encodedBytes.Length + 2] = CalculateCheckSome(cmd, encodedBytes.Length + 2);
                cmd[encodedBytes.Length + 3] = 0x0D;
                pollingList.Add(cmd);
                SavePollingQ();
            }
        }

        public void AddToButton(string buttonId, string buttonText , string device , string command ,ArrayList dataBytes)
        {
            string[] buttonCMD = new string[3];
            buttonCMD[0] = buttonId;
            buttonCMD[1] = buttonText;
            buttonCMD[2] = device + "," + command;
            for (int i = 0; i < dataBytes.Count; i++)
            {
                buttonCMD[2] += "," + dataBytes[i].ToString();
            }
            dbMgr.UpdateShortcutButton(buttonCMD);
            dbMgr.SaveConfig();
        }

       /* public void SaveButton(string buttonId , string buttonText , byte [] cmd)
        {
            string[] buttonCMD = new string[3];
            buttonCMD[0] = buttonId;
            buttonCMD[1] = buttonText;
            if(cmd.Length > 0)
            {
               
                string data = "";
                data = cmd[0].ToString();
                for (int i = 1; i < cmd.Length; i++)
                {
                    data += "," + cmd[i].ToString();
                }
                buttonCMD[2] = data;
            }
            if (buttonCMD.Length > 2)
            {
                dbMgr.UpdateShortcutButton(buttonCMD);
                dbMgr.SaveConfig();
            }
        }*/
        public void SavePollingQ()
        {
            string[] pollingQ = new string[pollingList.Count];
            for (int i = 0; i < pollingList.Count; i++)
            {
                byte[] pollingCmd = (byte[])pollingList[i];
                if (pollingCmd.Length > 0)
                {
                    pollingQ[i] = pollingCmd[0].ToString();
                    for (int j = 1; j < pollingCmd.Length; j++)
                    {
                        pollingQ[i] += "," + pollingCmd[j].ToString();
                    }
                }
            }
            if (pollingQ.Length > 0) 
            {
                dbMgr.UpdatePollingList(pollingQ);
                dbMgr.SaveConfig();
            }
        }

        public void SendCMD(string device, string command, ArrayList dataBytes)
        {
            byte[] encodedBytes = EncodeDataBytes(device, command, dataBytes);
            if (encodedBytes != null)
            {
                byte[] cmd = new byte[encodedBytes.Length + 4];
                cmd[0]     = (byte)(int)Enum.Parse(typeof(DeviceAddresses), device);
                cmd[1]     = (byte)int.Parse(command, System.Globalization.NumberStyles.HexNumber); ;
                encodedBytes.CopyTo(cmd, 2);
                cmd[encodedBytes.Length + 2] = CalculateCheckSome(cmd, encodedBytes.Length + 2);
                cmd[encodedBytes.Length + 3] = 0x0D;
                inQ.Add(cmd);
            }
        }

        public byte CalculateCheckSome(byte[] data, int length)
        {
            byte checkSum = 0;
            for (int i = 0; i < length ; i++)
            {
                checkSum ^= data[i];
            }
            if ((checkSum & 0x80) != 0)    // if bit 7 is on, manipulate it into ckecksum
            {
                if ((checkSum & 0x01) != 0)  // if bit 0 is on, manipulate it into bit 3
                    checkSum ^= 0x08;        //
                checkSum >>= 1;              // eliminate bit 7 as we prepare for transmission
            }
            return (byte)(checkSum | 0x80);  // return checksum w/bit 7 on (non-0 return is success)
        }

        public byte[] EncodeDataBytes(string device, string command, ArrayList databytes)
        {
            try
            {
                int id = dbMgr.GetDeviceId(device, "0x" + command);
                
                object[] dataPacketDetails = dbMgr.ReadSendPacketData(id);
                byte[] encodedDataBytes    = new byte[dataPacketDetails.Length];
                int j = 0;
                for (int i = 0; i < dataPacketDetails.Length; i++)
                {
                    string byteDataTag = ((object[])dataPacketDetails[i])[4].ToString();
                    string eightBitSingle = ByteDataTag.EightBitSingle.ToString();
                    string eightBitNibble = ByteDataTag.EightBitNibble.ToString();
                    if (byteDataTag == eightBitSingle)
                    {
                        switch (command)
                        {
                            case "5B":
                                encodedDataBytes[i] = (byte)(Convert.ToInt32(databytes[j]) | 0xf0);
                                break;
                            case "5C":
                                encodedDataBytes[i] = (byte)(Convert.ToInt32(databytes[j]) | 0xf0);
                                break;
                            default:
                                encodedDataBytes[i] = (byte)(Convert.ToInt32(databytes[j]) | 0x80);
                                break;
                        }
                       
                        encodedDataBytes[i] = (byte)(Convert.ToInt32(databytes[j]) | 0x80);

                        j++;
                    }
                    else
                        if (byteDataTag == eightBitNibble && (((object[])dataPacketDetails[i + 1])[4].ToString()) == eightBitNibble)
                        {
                            byte tempByte           = Convert.ToByte(databytes[j]);
                            encodedDataBytes[i]     = (byte)(((((tempByte) & 0xf0) >> 4)) | 0xf0);
                            encodedDataBytes[i + 1] = (byte)((Convert.ToByte(databytes[j]) & 0x0f) | 0xf0);
                            i++;
                            j++;
                        }
                }
                //  

                return encodedDataBytes;
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Encode Error Exception");
            }
            return null;
        }

        public void UpdateDataRecieved(ArrayList data)
        {
            try
            {
                if (updateValueRecievedEvent != null)
                {

                    updateValueRecievedEvent(data);
                }
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Update Event Exception");
            }
        }

        public void StartPolling(bool start)
        {
            startPolling = start;
        }

        public void FillInitialPollingQ()
        {
            dbMgr = new DBManager();
            pollingList = new ArrayList();
            if (dbMgr.OpenConfig(configFileName))
            {
                string[] pollingQ = dbMgr.GetPollingListData();
                for (int i = 0; i < pollingQ.Length; i++)
                {
                    string[] pollingCmd = pollingQ[i].Split(new char[] { ',' });
                    byte[] cmd = new byte[pollingCmd.Length];
                    for (int j = 0; j < pollingCmd.Length; j++)
                    {
                        cmd[j] = Convert.ToByte(pollingCmd[j]);
                    }
                    pollingList.Add(cmd);
                }
            }
        }

        #endregion

        #region Private Methods
        #region Main Process

        private void MainProcess()
        {
            int pollinInt = rs232CommSettings.PollingInterval;
            byte[] response;

            if (running )
            {
                commMgr.FlushCommanager();
                while (running)
                {
                    
                    byte[] cmd = GetNextOutboundCommand();
                    if (cmd != null)
                    {
                        response = commMgr.GetResponse(cmd);
                        //commMgr.WritePort(cmd);
                    }
                    else
                    {
                        response = commMgr.ReadPort();
                        System.Diagnostics.Debug.WriteLine(response.ToString());
                    }
                    if (response != null)
                    {
                        DecodeResponse(response);
                    }
                    Thread.Sleep(pollinInt);
                    
                }
            }
        }

        private void TreatRecievedData(byte[] cmd)
        {
          //  byte[] cmd1 = Encoding.ASCII.GetBytes(data);
            manualEvent.WaitOne();
          //  string [] response = data.Split(new char[] {'\r' });

            //for (int i = 0; i < response.Length; i++ )
            //{
            //    if (response[i].Length > 0)
            //    {
            //        response[i] += "\r"; 
            //    byte[] cmd = Encoding.ASCII.GetBytes(response[i]);
                //byte []  cmd = data.CopyTo(
               DecodeResponse(cmd);
            //    }
            //}
        }

        #endregion

        
        private string DecimalToBase(int iDec, int numbase)
        {
            const int base10    = 10;
            char[] cHexa        = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            int[] iHexaNumeric  = new int[] { 10, 11, 12, 13, 14, 15 };
            int[] iHexaIndices  = new int[] { 0, 1, 2, 3, 4, 5 };
            const int asciiDiff = 48;
            string strBin = "";
            int[] result = new int[32];
            int MaxBit = 32;
            for (; iDec > 0; iDec /= numbase)
            {
                int rem = iDec % numbase;
                result[--MaxBit] = rem;
            }
            for (int i = 0; i < result.Length; i++)
                if ((int)result.GetValue(i) >= base10)
                    strBin += cHexa[(int)result.GetValue(i) % base10];
                else
                    strBin += result.GetValue(i);
            strBin = strBin.TrimStart(new char[] { '0' });
            return strBin;
        }

        private byte [] GetNextOutboundCommand()
        {
            byte[] outboundCmd = null;
            // in Terminal mode we have to avoid in Q processing. Due to the async nature there may be few command in the input Q
            // when user requests terminal, which will get displayed on the terminal. To avoid this cut off in Q processing for main process thread 
            if (inQ.Count > 0)
            {
              
                    // Always remove the first element 
                    outboundCmd = (byte[])inQ[0];
                    inQ.RemoveAt(0);
               
            }
                else // Get the next polling command to send 
                {
                    if (pollingList.Count > 0 && startPolling)
                    {
                        outboundCmd = (byte []) pollingList[GetNextIndex()];
                    }
                }
          
                if (outboundCmd != null)
                {
                    ArrayList sendDataArray = new ArrayList();
                    sendDataArray.Add("Write");
                    for (int i = 0; i < outboundCmd.Length; i++ )
                    {
                        sendDataArray.Add(DecimalToBase(outboundCmd[i],16));
                    }
                    UpdateDataRecieved(sendDataArray);
                }
            return outboundCmd;
        }

        // Get next polling command
        private int GetNextIndex()
        {
            int index = lastIndex + 1;
            if (index > pollingList.Count - 1)
            {
                index = 0;
            }
            lastIndex = index;
            return index;
        }


        // Queue the command for sending
        private void Send(string msg)
        {
            // lock the Q before access
            lock (inQ.SyncRoot)
            {
                inQ.Add(msg + "\r");
            }
        }
        #endregion 
        
        #endregion

        #region Properties

        public event UpdateValuesEvent SubscribeToDataRecieved
        {
            add
            {
                updateValueRecievedEvent += value;
            }
            remove
            {
                updateValueRecievedEvent -= value;
            }
        }
        public string ConfigFilePath
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
        public ArrayList PollingList
        {
            set
            {
                pollingList = value;
            }
            get
            {
                return pollingList;
            }
        }
        public ThreadState CommThreadState
        {
            
            get
            {
                if (commThread != null)
                {
                    return commThread.ThreadState;
                }
                else
                {
                    return ThreadState.Unstarted;
                }
            }
        }
        #endregion
    }
}
