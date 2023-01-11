using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFZI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPlayfairCipher
    {

        [OperationContract]
        int Mod(int a, int b);

        [OperationContract]
        List<int> FindAllOccurrences(string str, char value);

        [OperationContract]
        string RemoveAllDuplicates(string str, List<int> indexes);

        [OperationContract]
        char[][] GenerateKeySquare(string key);

        [OperationContract]
        void GetPosition(ref char[][] keySquare, char ch, ref int row, ref int col);

        [OperationContract]
        char[] SameRow(ref char[][] keySquare, int row, int col1, int col2, int encipher);

        [OperationContract]
        char[] SameColumn(ref char[][] keySquare, int col, int row1, int row2, int encipher);


        [OperationContract]
        char[] SameRowColumn(ref char[][] keySquare, int row, int col, int encipher);


        [OperationContract]
        char[] DifferentRowColumn(ref char[][] keySquare, int row1, int col1, int row2, int col2);

        [OperationContract]
        string RemoveOtherChars(string input);

        [OperationContract]
        string AdjustOutput(string input, string output);

        [OperationContract]
        string Cipher(string input, string key, bool encipher);

        [OperationContract]
        string Encipher(string input, string key);

        [OperationContract]

        string Decipher(string input, string key);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
