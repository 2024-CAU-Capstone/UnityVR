using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media.TextFormatting;

namespace WindowsFormsApp
{
    public class MailHandler
    {
        private string idValue;
        private string passwordValue;
        static readonly string mailTextFile = @"./mail.txt";
        private DateTime lastUpdatedDate;
        private SmtpClient smtpClient = new SmtpClient();
        private ImapClient imapClient = new ImapClient();
        
        private List<string> receiverEmailList = new List<string>();

        public MailHandler() {
            ReadIdPasswordAddress();
        }

        private void ReadIdPasswordAddress()
        {

            if (File.Exists(mailTextFile))
            {
                string[] lines = File.ReadAllLines(mailTextFile);
                this.lastUpdatedDate = DateTime.ParseExact(lines[0], 
                    "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                idValue = lines[1];
                passwordValue = lines[2];
                if (idValue.Contains("@"))
                    ConnectMail(idValue, passwordValue);
                for (int i = 3; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                        receiverEmailList.Add(lines[i]);
                }
            } 
            else
            {
                using (StreamWriter sw = File.CreateText(mailTextFile))
                {
                    string tmpSeconds = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy HH:mm:ss");
                    sw.Write(tmpSeconds + "\n\n\n");
                    idValue = "";
                    passwordValue = "";
                }
            }
        }

        public bool IsConnected() 
        {
            if (smtpClient.IsConnected && imapClient.IsConnected)
                return true;
            return ConnectMail(this.idValue, this.passwordValue);
        }

        public bool ConnectMail(string setId, string setPw)
        {
            if (!(setId.Contains("@gmail.com") || setId.Contains("@naver.com"))) return false;
            if (idValue.Contains("@gmail.com"))
            {
                smtpClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                imapClient.Connect("imap.gmail.com", 993, true);
                try
                {
                    smtpClient.Authenticate(setId, setPw);
                    imapClient.Authenticate(setId, setPw);
                } catch (MailKit.Security.AuthenticationException ex) { return false; }
            }
            else if (idValue.Contains("@naver.com"))
            {
                smtpClient.Connect("smtp.naver.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                imapClient.Connect("imap.naver.com", 993, true);
                try
                {
                    smtpClient.Authenticate(setId.Split("@")[0], setPw);
                    imapClient.Authenticate(setId.Split("@")[0], setPw);
                }
                catch (MailKit.Security.AuthenticationException ex) { return false; }
            }
            IdPasswordUpdate(setId, setPw);
            return true;
            
        }
        private void IdPasswordUpdate(string setId, string setPwd)
        {
            string[] arrLine = File.ReadAllLines(mailTextFile);
            arrLine[1] = setId;
            arrLine[2] = setPwd;
            this.idValue = setId;
            this.passwordValue = setPwd;
            File.WriteAllLines(mailTextFile, arrLine);
        }

        public bool AddReceiverEmail(string address)
        {
            if (!address.Contains("@")) return false;
            receiverEmailList.Add(address);
            string[] arrLine = File.ReadAllLines(mailTextFile);
            arrLine[arrLine.Length - 1] = address + "\n";
            File.WriteAllLines(mailTextFile, arrLine);
            return true;
        }

        public List<string> GetReceiverEmailList()
        {
            return receiverEmailList;
        }

        public void GetEmails()
        {
            System.Diagnostics.Debug.WriteLine("get email");
            return;
        }

        public void SendMail(FilePathTracker filePathTracker)
        {
            System.Diagnostics.Debug.WriteLine(filePathTracker.BuildPath());
        }

        public void DisconnectMail()
        {
            if (smtpClient.IsConnected) smtpClient.Disconnect(true);
            if (imapClient.IsConnected) imapClient.Disconnect(true);
        }
    }
}
