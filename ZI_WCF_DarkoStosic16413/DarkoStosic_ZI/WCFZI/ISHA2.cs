using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFZI
{
    public struct SHA2_CTX
    {
        public byte[] data;
        public uint datalen;
        public uint[] bitlen;
        public uint[] state;
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISHA2" in both code and config file together.
    [ServiceContract]
    public interface ISHA2
    {
        [OperationContract]
        void DBL_INT_ADD(ref uint a, ref uint b, uint c);

        [OperationContract]
        uint ROTLEFT(uint a, byte b);

        [OperationContract]
        uint ROTRIGHT(uint a, byte b);

        [OperationContract]
        uint CH(uint x, uint y, uint z);

        [OperationContract]
        uint MAJ(uint x, uint y, uint z);

        [OperationContract]
        uint EP0(uint x);

        [OperationContract]
        uint EP1(uint x);

        [OperationContract]
        uint SIG0(uint x);

        [OperationContract]
        uint SIG1(uint x);



        [OperationContract]
        void SHA2Transform(ref SHA2_CTX ctx, byte[] data);

        [OperationContract]
        void SHA2Init(ref SHA2_CTX ctx);

        [OperationContract]
        void SHA2Update(ref SHA2_CTX ctx, byte[] data, uint len);

        [OperationContract]
         void SHA2Final(ref SHA2_CTX ctx, byte[] hash);

        [OperationContract]
        string SHA2Calculate(string data);

        
    }
}
