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


namespace V25Emulator
{
	/// <summary>
	/// Summary description for RS232Settings.
	/// </summary>
    /// 

    public enum BaudRate
    {
        BR_110 = 110,
        BR_300 = 300,
        BR_600 = 600,
        BR_1200 = 1200,
        BR_2400 = 2400,
        BR_4800 = 4800,
        BR_9600 = 9600,
        BR_14400 = 14400,
        BR_19200 = 19200,
        BR_38400 = 38400,
        BR_56000 = 56000,
        BR_57600 = 57600,
        BR_115200 = 115200,
        BR_128000 = 128000,
        BR_256000 = 256000,
    }

    public enum Parity
    {
        None = 0,
        Odd = 1,
        Even = 2,
        Mark = 3,
        Space = 4
    }

    public enum StopBits
    {
        One = 0,
        OnePointFive = 1,
        Two = 2,
        
    }

	public class RS232Settings 
	{
		#region Fields


		private int commPortID			= 1;
		private int baudRate			= (int)BaudRate.BR_19200;
		private int dataBits			= 8;
		private int parity				= (int)Parity.None;
		private int stopBits			= (int)StopBits.One;
        private int ResponseDelay       = 50;
        private int InterCharGap        = 5;

        private int pollingInterval     = 100;
		#endregion 

		#region Constructor

		public RS232Settings()
		{
			
			commPortID			= 1;
		}

		public RS232Settings(Object[] settings)
		{
			if(settings !=null)
			{
				
				CommunicationPort   = Convert.ToInt32(settings[0]);
				BitsPerSecond		= (BaudRate)Enum.Parse(typeof(BaudRate),settings[1].ToString());
				DataBits			= Convert.ToInt32(settings[2]);
				StopBits			= (StopBits)Enum.Parse(typeof(StopBits),settings[3].ToString());
				Parity				= (Parity)Enum.Parse(typeof(Parity),settings[4].ToString());
				ResponseDelay		= Convert.ToInt32(settings[5]);
				InterCharGap		= Convert.ToInt32(settings[6]);
                pollingInterval     = Convert.ToInt32(settings[7]);
			}
		}

		#endregion

		#region Methods

		#region Public

		public  object[] ToArray()
		{
			object[] content = new object[8];

					
			content[0]	 = CommunicationPort;
			content[1]	 = BitsPerSecond;		
			content[2]	 = DataBits;						
			content[3]	 = StopBits;			
			content[4]	 = Parity;
			content[5]	 = ResponseDelay;
			content[6]	 = InterCharGap;
            content[7]   = pollingInterval;
			return content;
		}

		#endregion
		
		#endregion

		#region Properties

		#region Public

		public int CommunicationPort
		{
			get
			{
				return commPortID;
			}
			set
			{
				commPortID = value;
			}
		}


		public BaudRate BitsPerSecond
		{
			get
			{
				return (BaudRate)baudRate;
			}
			set
			{
				baudRate = (int)value;
			}
		}


		public int DataBits
		{
			get
			{
				return dataBits;
			}
			set
			{
				dataBits = value;
			}
		}


		public Parity Parity
		{
			get
			{
				return (Parity)parity;
			}
			set
			{
				parity = (int)value;
			}
		}


		public StopBits StopBits
		{
			get
			{
				return (StopBits)stopBits;
			}
			set
			{
				stopBits = (int)value;
			}
		}
        public int PollingInterval
        {
            get
            {
                return pollingInterval;
            }
            set
            {
                pollingInterval = value;
            }
        }


		#endregion 

		#endregion


	}
}
