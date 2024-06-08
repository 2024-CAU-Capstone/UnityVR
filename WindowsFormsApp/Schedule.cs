using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp
{
    public partial class Schedule : Form, FilePathTracker
    {
        private StartUI startUI;
        private bool IsMake;

        public string detail;
        public string file;
        public string fileFullPath;
        public string time;
        public string applicationName;
        public int alarmTime;

        private List<string> LinkList;
        private List<string> ProgramList;
        private List<ProcessInfo> ProcessList;
        private List<Image> ScreenShotList;
        private List<string> ScreenShotSerial;

        private DateTime ScheduleTime;
        /////////////////////////////
        //unSaved
        private CheckBox[] screenCheckBox;
        public Schedule(StartUI startUI)
        {
            InitializeComponent();
            this.startUI = startUI;
            InitSchedule();
            InitComboBox();
        }

        public string BuildPath()
        {
            return @".\Schedule\" + detail;
        }

        private void InitSchedule()
        {
            ScreenShotList = new List<Image>();
            LinkList = new List<string>();
            ProgramList = new List<string>();
            ProcessList = new List<ProcessInfo>();
            ScreenShotSerial = new List<string>();
            detail = "no detail";
            file = "no file";
            fileFullPath = "no file";
            ScheduleTime = startUI.GetDate();
            MakeCheckBox();
            IsMake = true;
        }
        #region public method
        public void InitSchedule(Schedule saveSchedule)
        {
            detail = saveSchedule.detail;
            file = saveSchedule.file;
            fileFullPath = saveSchedule.fileFullPath;
            LinkList = saveSchedule.LinkList;
            ScreenShotList = saveSchedule.ScreenShotList;
            alarmTime = saveSchedule.alarmTime;
            time = saveSchedule.time;
            IsMake = false;
            /////////////////////////////
            MakeCheckBox();
            ShowLink();
            ContentText.Text = detail;
            maskedTextBox1.Text = time;
            fileName.Text = file;
            appName.Text = saveSchedule.applicationName;
            ScheduleTime = saveSchedule.ScheduleTime;
        }
        public void AddLink(string link) => LinkList.Add(link);
        public void AddProgram(string program) => ProgramList.Add(program);
        public void AddProcess(ProcessInfo process) => ProcessList.Add(process);
        public List<string> GetLinkList() => LinkList;
        public List<string> GetProgramList() => ProgramList;
        public List<Image> GetScreenShotList() => ScreenShotList;
        public List<string> GetScreenShotSerial() => ScreenShotSerial;
        public List<ProcessInfo> GetProcessList() => ProcessList;
        public void SetProcess(string process) => appName.Text = process;
        public void SetLinkList(List<string> linkList) => LinkList = linkList;
        public void SetProgramList(List<string> programList) => ProgramList = programList;
        public void SetProcessList(List<ProcessInfo> processList) => ProcessList = processList;
        public void SetScreenShotList(List<string> screenShotList)
        {
            ScreenShotList = new List<Image>();
            foreach (string bytes in screenShotList)
            {
                byte[] imageBytes = Convert.FromBase64String(bytes);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    ScreenShotList.Add(Bitmap.FromStream(ms));
                }
            }
        }
        public void SetScheduleTime(DateTime scheduleTime) => ScheduleTime = scheduleTime;
        public void SetIsMake(bool isMake) => IsMake = isMake;


        public void ShowLink()
        {
            for (int i = 0; i < LinkList.Count; i++)
            {
                LinkPopUpButton.Text += LinkList[i] + "  ";
            }
        }

        public DateTime GetScheduleTime() => ScheduleTime;

        #endregion
        private void InitComboBox()
        {
            comboBox.Items.Add("5분 전");
            comboBox.Items.Add("10분 전");
            comboBox.Items.Add("30분 전");
        }
        private void MakeCheckBox()
        {
            screenCheckBox = new CheckBox[Screen.AllScreens.Length];
            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                CheckBox CheckBox = new CheckBox();
                CheckBox.Text = "Screen " + (i + 1);
                CheckBox.Location = new Point(140 + i * 150, 120);
                CheckBox.Size = new Size(100, 30);
                if (ScreenShotList.Count > i)
                {
                    PictureBox picture = new PictureBox();
                    picture.Image = ScreenShotList[i];
                    picture.Location = new Point(130 + i * 150, 165);
                    picture.Size = new Size(100, 100);
                }
                Controls.Add(CheckBox);
                screenCheckBox[i] = CheckBox;
            }
        }

        private void TakeScreenShot()
        {
            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                if (screenCheckBox[i].Checked) continue;
                Rectangle rectangle = Screen.PrimaryScreen.Bounds;

                int bitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
                PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
                if (bitsPerPixel <= 16)
                {
                    pixelFormat = PixelFormat.Format16bppRgb565;
                }
                else if (bitsPerPixel <= 24)
                {
                    pixelFormat = PixelFormat.Format24bppRgb;
                }

                Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, pixelFormat);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, rectangle.Size);
                ScreenShotList.Add(bitmap);
                bitmap.Dispose();
            }
        }

        private void CompletedButton_Click(object sender, EventArgs e)
        {
            //작성 완료 버튼 - test ver           
            if (IsMake)
            {
                TakeScreenShot();
                DateTime date = Convert.ToDateTime(time);
                date = date.AddMinutes(-alarmTime);
                detail = ContentText.Text;
                startUI.AddSchedule(this);
                startUI.LoadMemoAndSchedule(startUI.GetDate());
                if(detail != null && time != null && alarmTime != 0)
                {
                    new ToastContentBuilder()
                    .AddText("일정 알림")
                    .AddText("일정 : " + detail)
                    .AddText("시간 : " + time)
                    .SetToastScenario(ToastScenario.Alarm)
                    .AddButton(new ToastButton()
                        .SetContent("확인")
                        .AddArgument("action", "viewConversation"))
                    .Schedule(date);
                }               
            }
            Close();
        }

        private void LinkPopUpButton_Click(object sender, EventArgs e)
        {
            //링크 버튼 클릭 시 링크 선택 창 띄우기
            PopUp popUp = new PopUp(this);
            popUp.Show();

        }

        private void SendMail_Click(object sender, EventArgs e)
        {
            SendMailPopup sendMailPopup = new SendMailPopup(this.startUI.mailHandler, this, true);
            sendMailPopup.Show();
        }

        private void FilePopUPButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "모든 파일(*.*)|*.*";
            openFileDialog.Title = "파일 선택";

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog.SafeFileName;
                fileFullPath = openFileDialog.FileName;
                fileName.Text = file;
            }
        }

        private void ApplicationButton_Click(object sender, EventArgs e)
        {
            ProgramPopUp programPopUp = new ProgramPopUp(this);
            programPopUp.Show();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox.SelectedItem.ToString())
            {
                case "5분 전":
                    alarmTime = 5;
                    break;
                case "10분 전":
                    alarmTime = 10;
                    break;
                case "30분 전":
                    alarmTime = 30;
                    break;
            }
        }

        private void maskedTextBox1TextChanged(object sender, EventArgs e)
        {
            time = maskedTextBox1.Text;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            
        }

    }
}
