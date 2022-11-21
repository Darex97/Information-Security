using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkoStosic_ZI
{
    public partial class Form1 : Form
    {//Treba se popravi ili izbrise ovo za veliki kljuc
        public A51 Koder { get; set; }

        public String OdredisniFolder { get; set; }

        public bool Inicijalizacija { get; set; }
        public Form1()
        {
            InitializeComponent();

            Koder = new A51();
            Inicijalizacija = false;
            incTbx.Text = "Not initialized";
            incTbx.BackColor = Color.Red;
        }

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
    }
}
