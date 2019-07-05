using System;
using System.Collections.Generic;
using System.Text;

namespace V25Emulator
{

    public enum CodeTag
    {
        AddressMSB = 0,
        AddressLSB = 1,
        DataMSB    = 2,
        DataLSB    = 3,
        MotorDirection = 4,
    }
    public enum DeviceAddresses
    {
          SmartBord  = 0x10,
          BackPlane  = 0x13,
    }
    public enum ByteDataTag
    {
        EightBitSingle,
        EightBitNibble,
    }
    public enum DataType
    {
        Address = 0,
        Data    = 1,
        Other   = 2,
    }
    //class Definitions
    //{
    //}
}
