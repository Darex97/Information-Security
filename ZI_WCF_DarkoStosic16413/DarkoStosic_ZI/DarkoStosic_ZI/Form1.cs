using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkoStosic_ZI.ServiceReference1;
using DarkoStosic_ZI.ServiceReference2;
using DarkoStosic_ZI.ServiceReference3;
using DarkoStosic_ZI.ServiceReference4;

namespace DarkoStosic_ZI
{
    public partial class Form1 : Form
    {
        PlayfairCipherClient playfairproxy;

        SHA2Client sha2proxy;
         
        public A51Client Koder { get; set; }
      
        public String OdredisniFolder { get; set; }

        public String textSha21 { get; set; }

        public String textSha22 { get; set; }

        public String pfcKey { get; set; }

        public String OdredisniFolderRsa { get; set; }

       // public String fileForParallel { get; set; }
        public int brFajlova { get; set; }
        public List<string> files { get; set; }

        public Bitmap image1 { get; set; }
        public bool Inicijalizacija { get; set; }
        public Form1()
        {
            InitializeComponent();

            playfairproxy = new PlayfairCipherClient();

            sha2proxy = new SHA2Client();

            
            brFajlova = 0;
            files = new List<string>();

            pfcKey = "";

            textSha21 = "";

            textSha22 = "";

            sha21.BackColor = Color.Red;

            sha22.BackColor = Color.Red;

            RSAinit.BackColor = Color.Red;

            PFCinit.BackColor = Color.Red;

            Koder = new A51Client();
            

            Inicijalizacija = false;
            incTbx.Text = "Not initialized";
            incTbx.BackColor = Color.Red;
        }
        /// A51 POCETAK
        private void Load_Key_Click(object sender, EventArgs e)
        {
            try
            {
                ulong xKey = uint.Parse(XPartTbx.Text);
                ulong yKey = uint.Parse(YPartTbx.Text);
                ulong zKey = uint.Parse(ZPartTbx.Text);

                if (xKey == 0 || yKey == 0 || zKey == 0)
                    throw new ArgumentNullException();
                Koder.LoadKeyParts(xKey, yKey, zKey);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Key Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Inicijalizacija = Koder.IsInitialized();
                if(Inicijalizacija)
                {
                    incTbx.Text = "Initialized";
                    incTbx.BackColor = Color.Green;
                }

            }
        }

        private void LoadWholeKey_Click(object sender, EventArgs e)
        {
            try
            {
                ulong key = ulong.Parse(LoadWholeKeyTb.Text);
                Koder.LoadKey(key);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Key Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Inicijalizacija = Koder.IsInitialized();
                if (Inicijalizacija)
                {
                    incTbx.Text = "Initialized";
                    incTbx.BackColor = Color.Green;
                }

            }
        }

        private void VoteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                byte xvb = byte.Parse(XVote.Value.ToString());
                byte yvb = byte.Parse(YVote.Value.ToString());
                byte zvb = byte.Parse(ZVote.Value.ToString());

                Koder.LoadVoteBits(xvb, yvb, zvb);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vote Bits Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Inicijalizacija = Koder.IsInitialized();
                if (Inicijalizacija)
                {
                    incTbx.Text = "Initialized";
                    incTbx.BackColor = Color.Green;
                }

            }
        }

        private void LoadXorBits_Click(object sender, EventArgs e)
        {
            try
            {
                //Check for valid inputs, empty, bad format etc.
                if (XXorBits.Text.Trim() == "" ||
                    YXorBits.Text.Trim() == "" ||
                    ZXorBits.Text.Trim() == "")
                    throw new FormatException();

                String[] xStepBitsString = XXorBits.Text.Split(' ');
                String[] yStepBitsString = YXorBits.Text.Split(' ');
                String[] zStepBitsString = ZXorBits.Text.Split(' ');

                // Filter duplicates, check each entry for bounds

                List<byte> xXorBits = new List<byte>();
                List<byte> yXorBits = new List<byte>();
                List<byte> zXorBits = new List<byte>();

                foreach (var sb in xStepBitsString)
                {
                    xXorBits.Add(byte.Parse(sb));
                }
                foreach (var sb in yStepBitsString)
                {
                    yXorBits.Add(byte.Parse(sb));
                }
                foreach (var sb in zStepBitsString)
                {
                    zXorBits.Add(byte.Parse(sb));
                }

                Koder.LoadStepBits(
                        xXorBits.ToArray(),
                        yXorBits.ToArray(),
                        zXorBits.ToArray()
                    );


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xor Bits Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                Inicijalizacija = Koder.IsInitialized();
                if (Inicijalizacija)
                {
                    incTbx.Text = "Initialized";
                    incTbx.BackColor = Color.Green;
                }


            }
        }

        public void Encode(String path, bool ChooseOutput = false)
        {

            String fileContents = string.Empty;
            String fileContentsUTF = string.Empty;

            String encodedFileContents = string.Empty;
            String encodedFileContentsUTF = string.Empty;

            using (StreamReader reader = new StreamReader(path))
            {

                int character = reader.Read();
                int encodedCharacter;
                while (character != -1)
                {
                    encodedCharacter = (int)Koder.Encode2Bytes((ushort)character);

                    fileContents += character;
                    encodedFileContents += encodedCharacter;

                    fileContentsUTF += char.ConvertFromUtf32(character);
                    encodedFileContentsUTF += char.ConvertFromUtf32(encodedCharacter);

                    character = reader.Read();
                }
            }
           

            String encodedFilePath = string.Empty;
            if (ChooseOutput)

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    // sfd.Filter = "(*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.Filter = "(*.txt)|*.txt";
                    if (sfd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(sfd.FileName))
                        encodedFilePath = sfd.FileName;
                    else
                        return;
                }

            else
            {
                String filename = Path.GetFileNameWithoutExtension(path) + "Encoded" + Path.GetExtension(path);
                encodedFilePath = Path.Combine(OdredisniFolder, filename);
                if (File.Exists(encodedFilePath))
                    File.Delete(encodedFilePath);
            }


            using (StreamWriter saveStream = new StreamWriter(encodedFilePath))
            {
                saveStream.Write(encodedFileContentsUTF);
            }

            Koder.ResetRegisters();

        }

        private void EncodeBtn_Click(object sender, EventArgs e)
        {
            if (Inicijalizacija == false)
            {
                MessageBox.Show("Parameters not initialized");
                return;
            }
                
            if (OdredisniFolder == null)
            {
                MessageBox.Show("Output folder not initialized");
                return;
            }
                

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
                    Encode(ofd.FileName);
            }
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            if (Inicijalizacija == false)
            {
                MessageBox.Show("Parameters not initialized");
                return;
            }

            if (OdredisniFolder == null)
            {
                MessageBox.Show("Output folder not initialized");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
                    Encode(ofd.FileName, ChooseOutput: true);
            }
        }

        private void OutputBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {

                    OdredisniFolder = fbd.SelectedPath;
                   
                    
                }
            }
        }



        /// A51 KRAJ
        /// 
        /// PlayfairCypher POCETAK



        private void PlayfairEncript_Click(object sender, EventArgs e)
        {
            
            string kriptovaniText = playfairproxy.Encipher(PlayfairText.Text, pfcKey).ToString();
            PlayfairOutput.Text = kriptovaniText;
        }

        private void PlayfairDecript_Click(object sender, EventArgs e)
        {
            string dekriptovaniText = playfairproxy.Decipher(PlayfairText.Text, pfcKey).ToString();
            PlayfairOutput.Text = dekriptovaniText;
        }
        private void PfcEncodeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length == 0)
                    {
                        return;
                    }
                    string contents = File.ReadAllText(ofd.FileName);
                    string kriptovaniText = playfairproxy.Encipher(contents, pfcKey).ToString();
                    string encodedFileName = Path.GetFileNameWithoutExtension(ofd.FileName) + "EncodedPFC.txt";
                    string encodedFilePath = Path.Combine(Path.GetDirectoryName(ofd.FileName), encodedFileName);
                    File.WriteAllText(encodedFilePath, kriptovaniText);
                }
            }
        }

        private void PfcDecodeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length == 0)
                    {
                        return;
                    }
                    string contents = File.ReadAllText(ofd.FileName);
                    string dekriptovaniText = playfairproxy.Decipher(contents, pfcKey).ToString();
                    string encodedFileName = Path.GetFileNameWithoutExtension(ofd.FileName) + "Decoded.txt";
                    string encodedFilePath = Path.Combine(Path.GetDirectoryName(ofd.FileName), encodedFileName);
                    File.WriteAllText(encodedFilePath, dekriptovaniText);
                }
            }

        }
        private void loadPFCkey_Click(object sender, EventArgs e)
        {
            pfcKey = PlayfairKey.Text;
            PFCinit.Text = "Initialized";
            PFCinit.BackColor = Color.Green;
        }

        /// PlayfairCYpher KRAJ
        /// 

        ///RSA pocetak

        private void GenerateRSA_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(this.p.Text);
            int q = Convert.ToInt32(this.q.Text);
            int rsaN = p * q;
            RSAClient rsa = new RSAClient();
            this.N.Text = (rsaN).ToString();

            int rsaE = 1;

            try
            {
                rsaE = Convert.ToInt32(this.e.Text);
            }
            catch
            {
                rsaE = 1;
            }

            if (rsaE == 1 || rsa.GetMinimalDivider((p - 1) * (q - 1), rsaE) > 1)
            {
                if (rsaE == 1)
                    rsaE = 3;
                while (rsa.GetMinimalDivider((p - 1) * (q - 1), rsaE) > 1)
                {
                    rsaE++;
                }
            }

            this.e.Text = rsaE.ToString();
            int rsaD = 1;

            while ((rsaD * rsaE) % ((p - 1) * (q - 1)) != 1)
            {
                rsaD++;
            }

            this.d.Text = rsaD.ToString();
            RSAinit.Text = "Initialized";
            RSAinit.BackColor = Color.Green;
        }

        private void EncriptRSA_Click(object sender, EventArgs e)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(this.textRSA.Text);
            RSAClient rsa = new RSAClient();
            
            int N = System.Convert.ToInt32(this.N.Text);
            int E = System.Convert.ToInt32(this.e.Text);

            string outstr = "";
            foreach (byte b in inputBytes)
            {
                int res = rsa.Crypt(b,E,N);
                outstr += res.ToString() + " ";
            }

            this.EDRSA.Text = outstr;
        }

        private void DecriptRSA_Click(object sender, EventArgs e)
        {
            string[] codes = this.textRSA.Text.Split(' ');

            RSAClient rsa = new RSAClient();
            int D = System.Convert.ToInt32(this.d.Text);
            int N = System.Convert.ToInt32(this.N.Text);
            string output = "";
            foreach (string s in codes)
            {
                int C = 0;
                try
                {
                    C = System.Convert.ToInt32(s);
                }
                catch
                {
                    C = 1;
                }
                C = rsa.Decrypt(C, D, N);
                output += System.Convert.ToChar(C);
            }

            this.EDRSA.Text = output;
        }

        private void RsaBmpEncript_Click(object sender, EventArgs e)
        {
         

                
               using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
                    {
                        
                        EncodeDecodeBmp(ofd.FileName,false);
                    
                    }
                }

            
        }

        ///BMP slike 
        public void EncodeDecodeBmp(String path,bool DorE)
        {
            

 

            RSAClient rsa = new RSAClient();


            int N = System.Convert.ToInt32(this.N.Text);
            int E = System.Convert.ToInt32(this.e.Text);
            int D = System.Convert.ToInt32(this.d.Text);


            if (DorE)
                rsa.DecryptBMP(OdredisniFolderRsa,path, D, N);
            else
                rsa.CryptBMP(OdredisniFolderRsa,path, E, N);

               

        }

        private void RSABMPOutput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {

                    OdredisniFolderRsa = fbd.SelectedPath;


                }
            }
        }

        private void RsaBmpDecript_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
                {

                    EncodeDecodeBmp(ofd.FileName, true);

                }
            }
        }
        //BMP END
        //FILE START
        private void RSAEncodeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length == 0)
                    {
                        return;
                    }
                    string contents = File.ReadAllText(ofd.FileName);
                    ////
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(contents);
                    RSAClient rsa = new RSAClient();

                    int N = System.Convert.ToInt32(this.N.Text);
                    int E = System.Convert.ToInt32(this.e.Text);

                    string outstr = "";
                    foreach (byte b in inputBytes)
                    {
                        int res = rsa.Crypt(b, E, N);
                        outstr += res.ToString() + " ";
                    }

                    

                    ////
                    string encodedFileName = Path.GetFileNameWithoutExtension(ofd.FileName) + "EncodedRSA.txt";
                    string encodedFilePath = Path.Combine(Path.GetDirectoryName(ofd.FileName), encodedFileName);
                    File.WriteAllText(encodedFilePath, outstr);
                }
            }
        }

        private void RSADecodeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length == 0)
                    {
                        return;
                    }
                    string contents = File.ReadAllText(ofd.FileName);
                    ////
                    string[] codes = contents.Split(' ');

                    RSAClient rsa = new RSAClient();
                    int D = System.Convert.ToInt32(this.d.Text);
                    int N = System.Convert.ToInt32(this.N.Text);
                    string output = "";
                    foreach (string s in codes)
                    {
                        int C = 0;
                        try
                        {
                            C = System.Convert.ToInt32(s);
                        }
                        catch
                        {
                            C = 1;
                        }
                        C = rsa.Decrypt(C, D, N);
                        output += System.Convert.ToChar(C);
                    }

                    



                    ////
                    string encodedFileName = Path.GetFileNameWithoutExtension(ofd.FileName) + "Decoded.txt";
                    string encodedFilePath = Path.Combine(Path.GetDirectoryName(ofd.FileName), encodedFileName);
                    File.WriteAllText(encodedFilePath, output);
                }
            }
        }
        //FILE END
        //Paralelna enkripcija

        private void AddFileFOrParallelRSA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length == 0)
                    {
                        return;
                    }
                    
                    files.Add(ofd.FileName);
                    brFajlova++;
                    brojFajlova.Text = Convert.ToString(brFajlova);





                }
            }
        }

        private void ParallelEncriptRSA_Click(object sender, EventArgs e)
        {
            if(brFajlova == 0)
            {
                return;
            }
            String[] str = files.ToArray();
            Parallel.For(0, str.Length,
                index=>
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        
                            string contents = File.ReadAllText(str[index]);
                            ////
                            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(contents);
                            RSAClient rsa = new RSAClient();

                            int N = System.Convert.ToInt32(this.N.Text);
                            int E = System.Convert.ToInt32(this.e.Text);

                            string outstr = "";
                            foreach (byte b in inputBytes)
                            {
                                int res = rsa.Crypt(b, E, N);
                                outstr += res.ToString() + " ";
                            }



                            ////
                            string encodedFileName = Path.GetFileNameWithoutExtension(str[index]) + "EncodedRSA.txt";
                            string encodedFilePath = Path.Combine(Path.GetDirectoryName(str[index]), encodedFileName);
                            File.WriteAllText(encodedFilePath, outstr);
                        
                    }

                });
        }


        //Kraj paralelne enkripcije
        ///RSA KRAJ
        ///SHA2 Pocetak
        private void btn1Sha2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length == 0) 
                    {
                        return;
                    }
                    textSha21 = File.ReadAllText(ofd.FileName);
                    sha21.Text = "Initialized";
                    sha21.BackColor = Color.Green;
                }
            }
        }

        private void btn2Sha2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length == 0) 
                    {
                        return;
                    }
                    textSha22 = File.ReadAllText(ofd.FileName);
                    sha22.Text = "Initialized";
                    sha22.BackColor = Color.Green;
                }
            }
        }

        private void Sha2Uporedi_Click(object sender, EventArgs e)
        {
            SHA2Client sha2 = new SHA2Client();

            if (textSha21 == "" || textSha22 == "")
            {
                return;
            }

            if (sha2proxy.SHA2Calculate(textSha21) == sha2proxy.SHA2Calculate(textSha22))
            {
                MessageBox.Show("Equal");
            }
            else
            {
                MessageBox.Show("Not equal");
            }
        }



        ///SHA Kraj
        ///
        private void brojFajlova_Click(object sender, EventArgs e)
        {
            //nepotrebno
        }

       
    }
}
