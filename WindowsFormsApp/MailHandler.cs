using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media.TextFormatting;

namespace WindowsFormsApp
{
    public class MailHandler
    {
        public bool isConnectionInProgress = true;

        private string idValue;
        private string passwordValue;
        static readonly string mailTextFile = @"./mail.txt";
        private DateTime lastUpdatedDate;
        private SmtpClient smtpClient = new SmtpClient();
        private ImapClient imapClient = new ImapClient();
        private bool isConnectedToServer = false;
        private ZipHelper zipHelper = new ZipHelper();

        private List<string> receiverEmailList = new List<string>();

        public MailHandler() {
            ReadIdPasswordAddress();
            zipHelper.CreateFromDirectory(@".\Memo\임시", false);
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

        public async void ConnectMail(string setId, string setPw, 
            bool isInitial=true, MailLogin mailLogin=null)
        {
            if (!setId.Contains("@outlook.com"))
            {
                isConnectionInProgress = false;
                return;
            }
            try
            {
                isConnectedToServer = false;
                isConnectionInProgress = true;
                smtpClient = new SmtpClient();
                imapClient = new ImapClient();
                await smtpClient.ConnectAsync("smtp-mail.outlook.com", 587,
                        MailKit.Security.SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(setId, setPw);
                await imapClient.ConnectAsync("outlook.office365.com", 993, true);
                await imapClient.AuthenticateAsync(setId, setPw);
                isConnectionInProgress = false;
                isConnectedToServer = true;
                if (!isInitial)
                {
                    mailLogin.EmailInsertResult(true);
                }
                IdPasswordUpdate(setId, setPw);
            }
            catch (MailKit.Security.AuthenticationException ex)
            {
                if (!isInitial)
                {
                    mailLogin.EmailInsertResult(false);
                }
            }
            if (!receiverEmailList.Contains(setId)) AddReceiverEmail(setId);
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
            imapClient.Inbox.Open(MailKit.FolderAccess.ReadOnly);
            var query = MailKit.Search.SearchQuery.DeliveredAfter(lastUpdatedDate)
                .And(MailKit.Search.SearchQuery.SubjectContains("Azure"));
            var uids = imapClient.Inbox.Search(query);
            foreach ( var u in uids )
            {
                var get_temp = imapClient.Inbox.GetMessage(u);
            }
        }

        public async void SendMail(List<string> mailsToSend, FilePathTracker filePathTracker, bool isSchedule)
        {
            try
            {
               // if (!isSmtpEnabled)
                 //   smtpClient.AuthenticateAsync(this.idValue, this.passwordValue);
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
            await Task.Run(() => this.zipHelper.CreateFromDirectory(filePathTracker.BuildPath(), isSchedule));
            await smtpClient.SendAsync(message);
            return;
        }

        public void DisconnectMail()
        {
            if (smtpClient.IsConnected) smtpClient.Disconnect(true);
            if (imapClient.IsConnected) imapClient.Disconnect(true);
        }
    }
}
