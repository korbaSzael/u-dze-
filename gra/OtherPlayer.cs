using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gra
{
    public partial class OtherPlayer : Form
    {
        public OtherPlayer()
        {
            InitializeComponent();
        }

        private void OtherPlayer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] plainBytes=Encoding.ASCII.GetBytes("to sobie zaszyfrujemy");
            byte[] plainKey= Encoding.ASCII.GetBytes("1234567890123456");
            SymmetricAlgorithm desObj=Rijndael.Create();
            desObj.Key = plainKey;
            desObj.Mode = CipherMode.CBC;
            desObj.Padding = PaddingMode.PKCS7;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,desObj.CreateEncryptor(),CryptoStreamMode.Write);
            cs.Write(plainBytes,0,plainBytes.Length);
            byte[] cipherBytes;
            cipherBytes= ms.ToArray();
            cs.Close();
            ms.Close();
            tbENCRYPTED.Text = Encoding.ASCII.GetString(cipherBytes);

            SymmetricAlgorithm desObj2 = Rijndael.Create();
            desObj2.Key = plainKey;
            desObj2.Mode = CipherMode.CBC;
            desObj2.Padding = PaddingMode.PKCS7;
            MemoryStream ms1 = new MemoryStream();
            CryptoStream cs1 = new CryptoStream(ms1, desObj2.CreateDecryptor(),CryptoStreamMode.Read);
            cs1.Read(cipherBytes,0,cipherBytes.Length);
            byte[] plainBytes2;
            plainBytes2 = ms1.ToArray();
            cs1.Close();
            ms1.Close();
            tbDECRYPTED.Text = Encoding.ASCII.GetString(plainBytes2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbDATA.Text=="") return;
            using (Rijndael myRijndael = Rijndael.Create())
            {
                myRijndael.Key = Encoding.ASCII.GetBytes("1234567890123456");
                myRijndael.IV = Encoding.ASCII.GetBytes("1234567890123456");
                byte[] encrypted = EncryptStringToBytes(tbDATA.Text, myRijndael.Key, myRijndael.IV);
                tbENCRYPTED.Text = Encoding.ASCII.GetString(encrypted);
                string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);
                tbDECRYPTED.Text = roundtrip;
            }
        }
        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)throw new ArgumentNullException("IV");
            string plaintext = null;
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        private void tbTFIND_Click(object sender, EventArgs e)
        {
            int index = 0;
            string temp = rtbFIND.Text;
            rtbFIND.Text = "";
            rtbFIND.Text = temp;
            while (index < rtbFIND.Text.LastIndexOf(tbFIND.Text))
            {
                rtbFIND.Find(tbFIND.Text, index, rtbFIND.TextLength, RichTextBoxFinds.None);
                //rtbFIND.SelectionBackColor = Color.Red;
                rtbFIND.SelectionColor = Color.Red;
                rtbFIND.SelectionFont = new Font("MV Boli", 12, FontStyle.Bold);
                index = rtbFIND.Text.IndexOf(tbFIND.Text, index) + 1;
            }
        }
        private void tbbFIND_Click(object sender, EventArgs e)
        {
            int index = 0;
            string temp = rtbFIND.Text;
            rtbFIND.Text = "";
            rtbFIND.Text = temp;
            while (index<rtbFIND.Text.LastIndexOf(tbFIND.Text))
            {
                rtbFIND.Find(tbFIND.Text,index,rtbFIND.TextLength,RichTextBoxFinds.None);
                //rtbFIND.SelectionBackColor = Color.Red;
                rtbFIND.SelectionColor = Color.Red;
                rtbFIND.SelectionFont = new Font("MV Boli", 12, FontStyle.Bold);
                index = rtbFIND.Text.IndexOf(tbFIND.Text,index)+1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = common.gamePath;
            openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbFIND.LoadFile(openFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = common.gamePath;
            saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbFIND.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }
    }
}
