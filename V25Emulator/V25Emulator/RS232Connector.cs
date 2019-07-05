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
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
using System.Collections;
//using CTM.Definitions;


namespace V25Emulator
{
    /// <summary>
    /// Summary description for RS232Connector.
    /// </summary>
    /// 
    public delegate void RecieveDataDelegate(byte[] recievedData);
    public class RS232Connector 
    {
        #region Fields

        #region Private

        private SerialPort serialPort;

        private bool connected = false;
        private int communicationPort = 1;
        private int bitsPerSecond = 9600;
        private int dataBits = 8;
        private System.IO.Ports.Parity parity = System.IO.Ports.Parity.None;
        private System.IO.Ports.StopBits stopBits = System.IO.Ports.StopBits.One;
        private int responseDelay = 50; // mS
        private int interCharGap = 0; // mS
        private RecieveDataDelegate recieveDataEvent;
        private string lastErrorMsg = "Normal";
        static AutoResetEvent autoEvent;
        private Queue commQueue = new Queue();

        #endregion

        #region Public
        public event SerialDataReceivedEventHandler DataReceived;
        #endregion

        #endregion

        #region Constructor

        public RS232Connector()
        {
        }

        #endregion

        #region Overrides

        // Get the response delay
        public int GetResponseDelay()
        {
            return responseDelay;
        }

        // Write the desired command string to communication port
        public void WritePort(string command)
        {
            if (connected)
            {
                
                if (interCharGap == 0)
                {
                    serialPort.Write(command);
                }
                else
                {
                    char[] message = command.ToCharArray();
                    for (int i = 0; i < message.Length; i++)
                    {
                        serialPort.Write(message, i, 1);
                        Thread.Sleep(interCharGap);
                    }
                }
                
            }
        }

        // Write the desired command bytes to communication port
        public void WritePort(byte[] command)
        {
            if (connected)
            {
               
                if (interCharGap == 0)
                {
                    serialPort.Write(command, 0, command.Length);
                }
                else
                {
                    for (int i = 0; i < command.Length; i++)
                    {
                        if (serialPort != null)
                        {
                            try
                            {
                                serialPort.Write(command, i, 1);
                                Thread.Sleep(interCharGap);
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Write the desired command string to communication port
        public byte [] GetResponse(string command)
        {
            lock (this)
            {
                WritePort(command);

                Thread.Sleep(responseDelay);

                return ReadPort();
            }
        }
        public void FlushCommanager()
        {
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
        }
        public byte [] GetResponse(byte[] command)
        {
            WritePort(command);

            Thread.Sleep(responseDelay);

            return ReadPort();
        }

        // Read a string of charactors from communication port
        public byte [] ReadPort()
        {
           // return serialPort.ReadExisting();
            byte[] responseData = new byte [128];
            int i = 0;
            try
            {
                while ((responseData[i] = (byte)serialPort.ReadByte()) != 0x0d)
                {
                    i++;
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            byte [] tempArray = new byte [i+1];
            for (int j = 0; j < i + 1; j++ )
            {
                tempArray[j] = responseData[j];
            }
            commQueue.Enqueue(tempArray);
            return tempArray;
        }

        private string AltName(string s)
        {
            string r = s.Trim();
            if (s.EndsWith(":")) s = s.Substring(0, s.Length - 1);
            if (s.StartsWith(@"\")) return s;
            return @"\\.\" + s;
        }

        // Init communication
        public bool Init(object[] settings)
        {
            if (settings != null)
            {
                communicationPort   = Convert.ToInt32(settings[0]);
                bitsPerSecond       = (int)settings[1];
                dataBits            = Convert.ToInt32(settings[2]);
                stopBits            = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), settings[3].ToString(), true);
                parity              = (System.IO.Ports.Parity)Enum.Parse(typeof(Parity), settings[4].ToString(), true);
                responseDelay       = Convert.ToInt32(settings[5]);
                interCharGap        = Convert.ToInt32(settings[6]);
            }

            if (!connected)
            {
                string portName = "COM" + communicationPort.ToString();
                serialPort = new SerialPort(portName, bitsPerSecond, parity, dataBits, stopBits);

                //serialPort.ReadTimeout = responseDelay;
                //serialPort.WriteTimeout = responseDelay;
                //serialPort.DtrEnable = true;
                //serialPort.RtsEnable = true;
                
                serialPort.WriteTimeout = Timeout.Infinite;
                serialPort.Encoding = System.Text.Encoding.ASCII;
               // serialPort.Handshake = Handshake.XOnXOff;
                serialPort.ReadTimeout = 500;
               // serialPort.DataReceived += new SerialDataReceivedEventHandler(portDataReceived);
                try
                {
                    serialPort.Open();
                    if (serialPort.IsOpen)
                    {
                        connected = true;
                    }
                    else
                    {
                        lastErrorMsg = "Cannot open Communication port: " + portName;
                    }
                }
                catch(Exception e)
                {
                   lastErrorMsg = "Cannot open Communication port: " + portName;
                }
               // serialPort.RtsEnable = true;
              //  Thread.Sleep(100);
             //   serialPort.RtsEnable = false;
            }
            return connected;
        }

        // Close communication port 
        public bool UnInit()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            connected = false;
            return true;
        }

        public string GetLastError()
        {
            return lastErrorMsg;
        }

        #endregion

        #region Methods

        #region Private
        #region Recieved Data
        private void portDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
           // autoEvent.Set();
           string response = serialPort.ReadExisting();
          // byte [] cmd = Encoding.ASCII.GetBytes(response);
               
            //byte [] = 
           recieveDataEvent(ReadPort());
        }
         #endregion
        #endregion

        #region Public

        #endregion

        #endregion
        public event RecieveDataDelegate RecieveDataEvent
        {
            add
            {
                recieveDataEvent += value;
            }
            remove
            {
                recieveDataEvent -= value;
            }
        }
        #region Properties

        #region Private

        #endregion

        #region Public

        #endregion

        #endregion

    }
}
