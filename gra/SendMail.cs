using System;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;
using EASendMail;
using System.Collections.Generic;

namespace gra
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        private void SendMail_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpMail thisMail = new SmtpMail("TryIt");
            EASendMail.SmtpClient thisServer = new EASendMail.SmtpClient();
            foreach (string attachment in attachments)
            {
                thisMail.AddAttachment(attachment);
            }
            thisMail.From = tbFROM.Text;
            thisMail.To = tbTO.Text;
            thisMail.Subject = tbSUBJECT.Text;
            thisMail.TextBody = tbMESSAGE.Text;
            SmtpServer orThisServer = new SmtpServer("smtp.gmail.com");
            orThisServer.Port = 465;
            orThisServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
            orThisServer.User = tbFROM.Text;
            orThisServer.Password = tbPASSWORD.Text;
            try
            {
                thisServer.SendMail(orThisServer, thisMail);
                btnSEND.Text = "DONE";
            }
            catch (Exception ex)
            {
                tbMESSAGE.Text = ex.Message;
                btnSEND.Text = "FAILED";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
           
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            Focus();
        }
        List<string> attachments = new List<string>();
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string lastDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(Path.GetDirectoryName(filenames[0]));
            using (ZipFile zip = new ZipFile())
            {
                foreach (string filename in filenames)
                {
                    zip.AddFile(Path.GetFileName(filename));
                }
                string filePath = Path.GetDirectoryName(filenames[0]) + "\\" + Path.GetFileNameWithoutExtension(filenames[0]) + ".zip";
                zip.Save(filePath);
                attachments.Add(filePath);
            }
            Directory.SetCurrentDirectory(Path.GetPathRoot(lastDirectory));
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            using (ZipFile zip = ZipFile.Read(filenames[0]))
            {
                zip.ExtractAll(Path.GetDirectoryName(filenames[0]));
            }
        }
    }
}
