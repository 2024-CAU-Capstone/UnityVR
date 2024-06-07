using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp
{
    public partial class Memo : Form, FilePathTracker
    {
        private StartUI startUI;
        private bool IsMake;
        public string detail;
        public string file;
        public string fileFullPath;
        public string applicationName;
        private List<string> LinkList;
        private List<string> ProgramList;
        private List<ProcessInfo> ProcessList;
        private List<Image> ScreenShotList;
        private DateTime MemoTime;
        private List<string> ScreenShotSerial;
        /////////////////////////////
        //unSaved
        private CheckBox[] screenCheckBox;

        public Memo(StartUI startUI)
        {
            InitializeComponent();
            this.startUI = startUI;
            InitMemo();
        }

        private void InitMemo()
        {
            ScreenShotList = new List<Image>();
            LinkList = new List<string>();
            ProgramList = new List<string>();
            ProcessList = new List<ProcessInfo>();
            detail = "no detail";
            file = "no file";
            fileFullPath = "no file";
            MemoTime = startUI.GetDate();
            MakeCheckBox();
            IsMake = true;
            ScreenShotSerial = new List<string>();
        }
        public void InitMemo(Memo savedmemo)
        {
            detail = savedmemo.detail;
            file = savedmemo.file;
            fileFullPath = savedmemo.fileFullPath;
            LinkList = savedmemo.LinkList;
            ScreenShotList = savedmemo.ScreenShotList;
            MemoTime = savedmemo.MemoTime;
            IsMake = false;
            ProcessList = savedmemo.ProcessList;
            appName.Text = savedmemo.appName.Text;
            applicationName = savedmemo.applicationName;
            /////////////////////////////
            MakeCheckBox();
            ShowLink();
            ContentText.Text = detail;
            fileName.Text = file;          
            appName.Text = applicationName;
        }
        public void AddLink(string link) => LinkList.Add(link);
        public void AddProgram(string program) => ProgramList.Add(program);
        public void AddProcess(ProcessInfo process) => ProcessList.Add(process);
        public DateTime GetMemoTime() => MemoTime;
        public List<string> GetLinkList() => LinkList;
        public List<string> GetProgramList() => ProgramList;
        public List<Image> GetScreenShotList() => ScreenShotList;
        public List<ProcessInfo> GetProcessList() => ProcessList;
        public List<string> GetScreenShotSerial() => ScreenShotSerial;
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
        public void SetMemoTime(DateTime memoTime) => MemoTime = memoTime;
        public void SetIsMake(bool isMake) => IsMake = isMake;
        public void ShowLink()
        {
            for (int i = 0; i < LinkList.Count; i++)
            {
                LinkPopUpButton.Text += LinkList[i] + "  ";
            }
        }

        private void MakeCheckBox()
        {
            screenCheckBox = new CheckBox[Screen.AllScreens.Length];
            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                CheckBox CheckBox = new CheckBox();                            
                CheckBox.Text = "Screen " + (i + 1);
                CheckBox.Location = new Point(130 + i * 150, 135);
                CheckBox.Size = new Size(100, 30);
                Debug.WriteLine(ScreenShotList.Count);
                if (ScreenShotList.Count > i)
                {
                    PictureBox picture = new PictureBox();
                    picture.Image = ScreenShotList[i];
                    picture.Location = new Point(130 + i * 150, 165);
                    picture.Size = new Size(100, 100);
                }
                this.Controls.Add(CheckBox);
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
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ScreenShotSerial.Add(Convert.ToBase64String(ms.ToArray()));
                ScreenShotList.Add(bitmap);               
                //bitmap.Dispose();
            }
            Debug.WriteLine("ScreenShotCount: " + ScreenShotList.Count);
        }

        private void CompletedButton_Click(object sender, EventArgs e)
        {
            //작성 완료 버튼 - test ver
            if (IsMake)
            {
                TakeScreenShot();
                detail = ContentText.Text;
                startUI.AddMemo(this);
                startUI.LoadMemoAndSchedule(startUI.GetDate());
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

        private void SendMailButton_Click(object sender, EventArgs e)
        {
            SendMailPopup sendMailPopup = new SendMailPopup(this.startUI.mailHandler, this);
            sendMailPopup.Show();
        }

        public string BuildPath()
        {
            return @".\Memo\" + detail;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Alt | Keys.R))
            {
                foreach (ProcessInfo processInfo in ProcessList)
                {
                    processInfo.Run();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
