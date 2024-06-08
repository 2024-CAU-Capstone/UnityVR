using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using Microsoft.Office.Interop.Word;
using MimeKit;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
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
        private StartUI startUI;

        private List<string> receiverEmailList = new List<string>();

        public MailHandler(StartUI startUI) {
            ReadIdPasswordAddress();
            this.startUI = startUI;
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
                else
                    isConnectionInProgress = false;
            } 
            else
            {
                using (StreamWriter sw = File.CreateText(mailTextFile))
                {
                    string tmpSeconds = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                    sw.Write(tmpSeconds + "\n\n\n");
                    idValue = "";
                    passwordValue = "";
                    isConnectionInProgress = false;
                }
            }
        }

        private void ChangeTime()
        {
            if (File.Exists(mailTextFile))
            {
                string tmpSeconds = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                string[] lines = File.ReadAllLines (mailTextFile);
                lines[0] = tmpSeconds;
                File.WriteAllLines(mailTextFile, lines);
            }
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
                if (!isInitial)
                {
                    await smtpClient.DisconnectAsync(true);
                    await imapClient.DisconnectAsync(true);
                }
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
                isConnectionInProgress = false;
                return;
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

        public async void GetEmails()
        {
            if (!imapClient.IsConnected)
            {
                MailLogin mailLogin = new MailLogin(this);
                mailLogin.Show();
                return;
            }
            await imapClient.Inbox.OpenAsync(MailKit.FolderAccess.ReadOnly);
            int countEmail = 0;
            var query = MailKit.Search.SearchQuery.DeliveredAfter(lastUpdatedDate); 
            var uids = imapClient.Inbox.Search(query);
            foreach ( var u in uids )
            {
                MimeMessage mime = await imapClient.Inbox.GetMessageAsync(u);
                if (mime.Subject.Contains("[윈도우 스냅샷]"))
                    { GetEmail(mime); countEmail++; }
            }
            if (countEmail > 0)
                ChangeTime();
            startUI.RestartApplication();
        }

        public void GetEmail(MimeMessage message)
        {
            bool isSchedule;
            foreach(MimeEntity attachment in message.Attachments )
            {
                var filename = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                if (filename.Contains("window_snapshot_program")) continue;
                if (!filename.Contains("_zip.zip.png")) continue;
                string fileRoute = @".\" + filename;
                using (var stream = File.Create(fileRoute))
                {
                    if (attachment is MessagePart)
                    {
                        var part = (MessagePart)attachment;
                        part.Message.WriteTo(stream);
                    } else
                    {
                        var part = (MimePart) attachment;
                        part.Content.DecodeTo(stream);
                    }
                    if (filename.Contains("schedule")) isSchedule = true;
                    else isSchedule = false;
                }
                File.Move(fileRoute, fileRoute.Replace(".png", ""));
                if (isSchedule)
                {
                    try { ZipFile.ExtractToDirectory(fileRoute.Replace(".png", ""), @".\Schedule"); }
                    catch (IOException e)
                    {
                        File.Delete(fileRoute.Replace(".png", ""));
                        return;
                    }

                }
                else
                {
                    try { ZipFile.ExtractToDirectory(fileRoute.Replace(".png", ""), @".\Memo"); }
                    catch (IOException e)
                    {
                        File.Delete(fileRoute.Replace(".png", ""));
                        return;
                    }
                }
                File.Delete(fileRoute.Replace(".png", ""));
            }
        }

        public async void SendMail(List<string> mailsToSend, FilePathTracker filePathTracker, bool isSchedule)
        {
            if (!smtpClient.IsConnected)
            {
                MailLogin mailLogin = new MailLogin(this);
                mailLogin.Show();
                return;
            }
            if (!File.Exists(filePathTracker.BuildPath())) return;
            if (!isConnectedToServer)
            {
                MailLogin mailLogin = new MailLogin(this);
                mailLogin.Show();
                return;
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(this.idValue.Split("@")[0], this.idValue));
            message.Subject = "[윈도우 스냅샷] " + Path.GetFileName(filePathTracker.BuildPath());
            var builder = new BodyBuilder();
            for (int i = 0; i < mailsToSend.Count; i++)
            {
                message.To.Add(new MailboxAddress(mailsToSend[i].Split("@")[0], mailsToSend[i]));
            }
            await System.Threading.Tasks.Task.Run(() => this.zipHelper.CreateFromDirectory(filePathTracker.BuildPath(), isSchedule));
            builder.TextBody = "기존에 설치된 프로그램이 없으실 경우,\n" +
                "window_snapshot_program 파일 png 확장자 지운 후 실행 부탁드립니다.";
            File.Move(@".\window_snapshot_program.zip", @".\window_snapshot_program.zip.png");
            if (isSchedule)
            {
                File.Move(@".\schedule_zip.zip", @".\schedule_zip.zip.png");
            }
            else
            {
                File.Move(@".\memo_zip.zip", @".\memo_zip.zip.png");
            }
            builder.Attachments.Add(@".\window_snapshot_program.zip.png");
            if (isSchedule)
                builder.Attachments.Add(@".\schedule_zip.zip.png");
            else 
                builder.Attachments.Add(@".\memo_zip.zip.png");
            message.Body = builder.ToMessageBody();
            await smtpClient.SendAsync(message);
            File.Delete(@".\window_snapshot_program.zip.png");
            if (isSchedule)
            {
                File.Delete(@".\schedule_zip.zip.png");
            }
            else
            {
                File.Delete(@".\memo_zip.zip.png");
            }
            
            return;
        }

        public void DisconnectMail()
        {
            if (smtpClient.IsConnected) smtpClient.Disconnect(true);
            if (imapClient.IsConnected) imapClient.Disconnect(true);
        }
    }
}
