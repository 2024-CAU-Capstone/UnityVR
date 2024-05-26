using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class MailHandler
    {
        private string idValue;
        private string passwordValue;
        static readonly string mailTextFile = @"./mail.txt";
        private SmtpClient smtpClient = new SmtpClient();
        private ImapClient imapClient = new ImapClient();
        
        public List<string> receiverEmailList = new List<string>();

        public MailHandler() {
            ReadIdPasswordAddress();
        }

        private void ReadIdPasswordAddress()
        {

            if (File.Exists(mailTextFile))
            {
                string[] lines = File.ReadAllLines(mailTextFile);
                idValue = lines[0];
                passwordValue = lines[1];
                if (idValue.Contains("@"))
                    ConnectMail(idValue, passwordValue);
                for (int i = 2; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                        receiverEmailList.Add(lines[i]);
                }
            } 
            else
            {
                using (StreamWriter sw = File.CreateText(mailTextFile))
                {
                    sw.Write("/n/n");
                    idValue = "";
                    passwordValue = "";
                }
            }
        }

        public bool isAccountInfoInserted() { return idValue.Contains("@"); }

        public void ConnectMail(string setId, string setPw)
        {
            if (idValue.Contains("gmail.com"))
            {
                smtpClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate(setId, setPw);
                imapClient.Connect("imap.gmail.com", 993, true);
                imapClient.Authenticate(setId, setPw);
            }
            else if (idValue.Contains("naver.com"))
            {
                smtpClient.Connect("smtp.naver.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate(setId.Split("@")[0], setPw);
                imapClient.Connect("imap.naver.com", 993, true);
                imapClient.Authenticate(setId.Split("@")[0], setPw);
            }
        }

        public void DisconnectMail()
        {
            smtpClient.Disconnect(true);
            imapClient.Disconnect(true);
        }
    }
}
