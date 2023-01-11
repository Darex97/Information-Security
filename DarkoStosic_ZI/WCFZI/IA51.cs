using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFZI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IA51" in both code and config file together.
    [ServiceContract]
    public interface IA51
    {
        [OperationContract]
        bool LoadKey(ulong key);

        [OperationContract]
        bool LoadKeyParts(ulong xSeed, ulong ySeed, ulong zSeed);

        [OperationContract]
        bool LoadStepBits(byte[] xsb, byte[] ysb, byte[] zsb);

        [OperationContract]
        bool LoadVoteBits(byte xvb, byte yvb, byte zvb);

        [OperationContract]
        byte EncodeByte(byte number);

        [OperationContract]
        ushort Encode2Bytes(ushort number);

        [OperationContract]
        byte ByteArrayOfBitsToByte(byte[] ba);

        [OperationContract]
        byte[] ShiftRightAndInsert(byte[] array, byte insertValue);

        [OperationContract]
        byte[] FromUIntToByteArrayOfBits(byte[] array, uint seed);

        [OperationContract]
        void ResetRegisters();

        [OperationContract]
        bool IsInitialized();
    }
}
