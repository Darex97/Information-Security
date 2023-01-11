using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFZI
{
    public class CFB
    {

        public static byte[] Encrypt(byte[] plaintext, byte[] key, byte[] iv)
        {
           
            int blockSize = 8;
            

            
            byte[] ciphertext = new byte[plaintext.Length];

            
            byte[] feedback = new byte[iv.Length];
            Array.Copy(iv, feedback, iv.Length);

            
            for (int i = 0; i < plaintext.Length; i += blockSize)
            {
                
                byte[] keystream = GenerateKeystream(key, feedback);

                
                for (int j = 0; j < blockSize; j++)
                {
                    ciphertext[i + j] = (byte)(plaintext[i + j] ^ keystream[j]);
                }

                
                Array.Copy(ciphertext, i, feedback, 0, blockSize);
            }

           
            return ciphertext;


        }

        public static byte[] Decrypt(byte[] ciphertext, byte[] key, byte[] iv)
        {
            
            
            int blockSize = 8;
            

            
            byte[] plaintext = new byte[ciphertext.Length];

            
            byte[] feedback = new byte[iv.Length];
            Array.Copy(iv, feedback, iv.Length);

            
            for (int i = 0; i < ciphertext.Length; i += blockSize)
            {
                
                byte[] keystream = GenerateKeystream(key, feedback);

                
                for (int j = 0; j < blockSize; j++)
                {
                    plaintext[i + j] = (byte)(ciphertext[i + j] ^ keystream[j]);
                }

                
                Array.Copy(ciphertext, i, feedback, 0, blockSize);
            }

            
            return plaintext;
        }

        public static byte[] GenerateKeystream(byte[] key, byte[] feedback)
        {
            // Generate the keystream block using the A5/1 stream cipher.
            return null;
        }
    }
}
    