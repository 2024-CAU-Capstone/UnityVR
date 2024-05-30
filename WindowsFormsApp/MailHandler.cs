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
            arrLine[0] = setId;
            arrLine[1] = setPwd;
            this.idValue = setId;
            this.passwordValue = setPwd;
            File.WriteAllLines(mailTextFile, arrLine);
        }

        public void DisconnectMail()
        {
            smtpClient.Disconnect(true);
            imapClient.Disconnect(true);
        }
    }
}
