using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        public int alarmTime;

        private List<string> LinkList;
        private List<string> ProgramList;
        private List<ProcessInfo> ProcessList;
        private List<Image> ScreenShotList;

        private DateTime ScheduleTime;
        public Schedule(StartUI startUI)
        {
            InitializeComponent();
            this.startUI = startUI;
            InitSchedule();
            InitComboBox();
        }

        private void InitSchedule()
        {
            ScreenShotList = new List<Image>();
            LinkList = new List<string>();
            ProgramList = new List<string>();
            ProcessList = new List<ProcessInfo>();
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
            ShowLink();
            ContentText.Text = detail;
            maskedTextBox1.Text = time;
            fileName.Text = file;
            ScheduleTime = saveSchedule.ScheduleTime;
        }
        public void AddLink(string link) => LinkList.Add(link);
        public void AddProgram(string program) => ProgramList.Add(program);
        public void AddProcess(ProcessInfo process) => ProcessList.Add(process);
        public List<string> GetLinkList() => LinkList;
        public List<string> GetProgramList() => ProgramList;
        public List<Image> GetScreenShotList() => ScreenShotList;
        public List<ProcessInfo> GetProcessList() => ProcessList;
        public void SetLinkList(List<string> linkList) => LinkList = linkList;
        public void SetProgramList(List<string> programList) => ProgramList = programList;
        public void SetScreenShotList(List<Image> screenShotList) => ScreenShotList = screenShotList;
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
            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                CheckBox screenCheckBox = new CheckBox();
                screenCheckBox.Text = "Screen " + (i + 1);
                screenCheckBox.Location = new Point(140 + i * 150, 120);
                screenCheckBox.Size = new Size(100, 30);
                this.Controls.Add(screenCheckBox);
            }
        }

        private void TakeScreenShot()
        {
            /*
            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                Bitmap bitmap = new Bitmap(screens[i].Bounds.Width, screens[i].Bounds.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                Image img = Clipboard.GetImage();

                graphics.CopyFromScreen(screens[i].Bounds.X, screens[i].Bounds.Y, 0, 0, screens[i].Bounds.Size);
                Clipboard.SetImage(bitmap);
                graphics.Dispose();
                ScreenShotList.Add(img);
            }
            */
        }

        private void CompletedButton_Click(object sender, EventArgs e)
        {
            //작성 완료 버튼 - test ver           
            if (IsMake)
            {
                DateTime date = Convert.ToDateTime(time);
                date = date.AddMinutes(-alarmTime);
                detail = ContentText.Text;
                startUI.AddSchedule(this);
                startUI.LoadMemoAndSchedule(startUI.GetDate());
                new ToastContentBuilder()
                    .AddText("일정 알림")
                    .AddText("일정 : " + detail)
                    .AddText("시간 : " + time)
                    .SetToastScenario(ToastScenario.Alarm)
                    .Schedule(date);

            }
            Close();
        }

        private void LinkPopUpButton_Click(object sender, EventArgs e)
        {
            //링크 버튼 클릭 시 링크 선택 창 띄우기
            PopUp popUp = new PopUp(this);
            popUp.Show();

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

        public string BuildPath()
        {
            return @".\" + detail;
        }
    }
}
