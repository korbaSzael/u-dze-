using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;
using System.Net;
using Ionic.Zip;
using System.IO;

namespace gra
{
    public partial class SendMail : Form
    {
        string email = "";
        string passw = "";
        public SendMail()
        {
            InitializeComponent();
        }

        private void SendMail_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = tbFROM.Text;
            passw = tbPASSWORD.Text;
            //MailMessage mail = new MailMessage(tbFROM.Text,tbTO.Text,tbSUBJECT.Text,rtbBODY.Text);
            MailMessage mail = new MailMessage(email,email,email,email);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            //smtpClient.Credentials = new NetworkCredential(tbUSERNAME.Text,tbPASSWORD.Text);
            smtpClient.Credentials = new NetworkCredential(email,passw);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            email = tbFROM.Text;
            passw = tbPASSWORD.Text;
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(email, passw),
                EnableSsl = true
            };
            client.Send(email,email, "test", "testbody");
        }
           
private void button3_Click(object sender, EventArgs e)
        {
            email = tbFROM.Text;
            passw = tbPASSWORD.Text;
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailFromAddress = email; //Sender Email Address  
            string password = passw; //Sender Password  
            string emailToAddress = email; //Receiver Email Address  
            string subject = "Hello";
            string body = "Hello, This is Email sending test using gmail.";
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            Focus();
        }

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
                zip.Save(Path.GetDirectoryName(filenames[0]) + "\\" + Path.GetFileNameWithoutExtension(filenames[0]) + ".zip");
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
