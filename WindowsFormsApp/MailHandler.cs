using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
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
        private bool isSmtpEnabled = false;
        
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
                    "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
                idValue = lines[1];
                passwordValue = lines[2];
                for (int i = 3; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                        receiverEmailList.Add(lines[i]);
                }
                if (idValue.Contains("@"))
                    ConnectMail(idValue, passwordValue);
            } 
            else
            {
                using (StreamWriter sw = File.CreateText(mailTextFile))
                {
                    string tmpSeconds = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    sw.Write(tmpSeconds + "\n\n\n");
                    idValue = "";
                    passwordValue = "";
                }
            }
        }

        public bool IsConnected() 
        {
            if (smtpClient.IsConnected && imapClient.IsConnected)
            {
                return true;
            }
            return false;
        }

        public bool ConnectMail(string setId, string setPw)
        {
            if (!setId.Contains("@naver.com")) return false;
            if (idValue.Contains("@naver.com"))
            {
                try
                {
                    smtpClient.Disconnect(true);
                    imapClient.Disconnect(true);
                    Thread.Sleep(1000);
                    smtpClient = new SmtpClient();
                    imapClient = new ImapClient();
                    smtpClient.ConnectAsync("smtp.naver.com", 465,
                            MailKit.Security.SecureSocketOptions.SslOnConnect);
                    smtpClient.AuthenticateAsync(setId.Split("@")[0], setPw);
                    imapClient.ConnectAsync("imap.naver.com", 993, true);
                    imapClient.AuthenticateAsync(setId.Split("@")[0], setPw);
                    isSmtpEnabled = false;

                }
                catch (MailKit.Security.AuthenticationException ex) { throw; return false; }
            }
            IdPasswordUpdate(setId, setPw);
            if (receiverEmailList.Count == 0) AddReceiverEmail(setId);

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
            arrLine[arrLine.Length - 1] += "\n" + address;
            File.WriteAllLines(mailTextFile, arrLine);
            return true;
        }

        public List<string> GetReceiverEmailList()
        {
            return receiverEmailList;
        }

        public void GetEmails()
        {
            return;
            try
            {
                if (!isSmtpEnabled)
                    smtpClient.AuthenticateAsync(this.idValue, this.passwordValue);
            }
            catch(MailKit.Security.AuthenticationException ex)
            {
                MailLogin mailLogin = new MailLogin(this);
                mailLogin.Show();
                return;
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Windows_Scheduler", this.idValue));
            message.To.Add(new MailboxAddress("Windows_Scheduler", this.idValue));
            message.Subject = DateTime.Now.ToString();
            message.Body = new MimeKit.TextPart("text");
            smtpClient.SendAsync(message);
            isSmtpEnabled = true;
            return;
        }

        public void SendMail(List<string> mailsToSend)
        {
            try
            {
                if (!isSmtpEnabled)
                    smtpClient.AuthenticateAsync(this.idValue, this.passwordValue);
            }
            catch (MailKit.Security.AuthenticationException ex)
            {
                MailLogin mailLogin = new MailLogin(this);
                mailLogin.Show();
                return;
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Windows_Scheduler", this.idValue));
            message.Subject = DateTime.Now.ToString();
            message.Body = new MimeKit.TextPart("text");
            for (int i = 0; i < mailsToSend.Count; i++)
            {
                message.To.Add(new MailboxAddress("Windows_Scheduler", mailsToSend[i]));
            }
            smtpClient.SendAsync(message);
            isSmtpEnabled = true;
            return;
        }

        public void DisconnectMail()
        {
            if (smtpClient.IsConnected) smtpClient.Disconnect(true);
            if (imapClient.IsConnected) imapClient.Disconnect(true);
        }
    }
}
