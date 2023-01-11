using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFZI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RSA" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RSA.svc or RSA.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [DataContract]
    public class RSA : IRSA
    {
        // Public key
       public int N;
       public int e;

        // Private key
       public int d;

        public RSA()
        {
           
        }
       

        public int Calculate(int startValue, int eksp , int N)
        {
            int retValue = startValue;

            for (int i = 1; i < eksp; i++)
            {
                retValue = (retValue * startValue) % N;
            }

            return retValue;
        }

        public int Crypt(int M, int e, int N)
        {
            return this.Calculate(M, e, N);
        }

        public void CryptBMP(String odredisni,String path, int e, int N)
        {
            FileStream fsr = System.IO.File.OpenRead(path);
            byte[] a = new byte[fsr.Length];
            fsr.Read(a, 0, Convert.ToInt32(fsr.Length));

            FileStream b = File.OpenWrite(odredisni + "\\EnkriptDekript " + DateTime.Now.Second + ".bmp");

            int pos = a[10] + 256 * (a[11] + 256 * (a[12] + 256 * a[13]));

            for (int i = 0; i < fsr.Length; i++)
            {
                if (i < pos)
                {
                    b.WriteByte(a[i]);
                }
                else
                {
                    byte res = 0;
                   
                        res = Convert.ToByte(this.Crypt(a[i], e, N));

                    b.WriteByte(res);
                }
            }

            b.Close();

        }

        public int Decrypt(int C, int d, int N)
        {
            return this.Calculate(C,d,N);
        }

        public void DecryptBMP(String odredisni,String path, int e, int N)
        {
            FileStream fsr = System.IO.File.OpenRead(path);
            byte[] a = new byte[fsr.Length];
            fsr.Read(a, 0, Convert.ToInt32(fsr.Length));

            FileStream b = File.OpenWrite(odredisni + "\\EnkriptDekript " + DateTime.Now.Second + ".bmp");

            int pos = a[10] + 256 * (a[11] + 256 * (a[12] + 256 * a[13]));

            for (int i = 0; i < fsr.Length; i++)
            {
                if (i < pos)
                {
                    b.WriteByte(a[i]);
                }
                else
                {
                    byte res = 0;

                    res = Convert.ToByte(this.Decrypt(a[i], e, N));

                    b.WriteByte(res);
                }
            }

            b.Close();

        }

        public int GetMinimalDivider(int a, int b)
        {
            if ((a % b) == 0)
            {
                return b;
            }
            else
            {
                a -= b;
                if (a > b)
                    return this.GetMinimalDivider(a, b);
                else
                    return this.GetMinimalDivider(b, a);
            }
        }
    }
}
