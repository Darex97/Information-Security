using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFZI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRSA" in both code and config file together.
    [ServiceContract]
    public interface IRSA
    {
        [OperationContract]
        int Crypt(int M,int e, int N);

        [OperationContract]
        int Calculate(int startValue, int eksp , int N);

        [OperationContract]
        int Decrypt(int C, int d, int N);

        [OperationContract]
        int GetMinimalDivider(int a, int b);

        [OperationContract]
        void CryptBMP(String odredisni, String path, int e, int N);

        [OperationContract]
        void DecryptBMP(String odredisni, String path, int e, int N);
    }
}
