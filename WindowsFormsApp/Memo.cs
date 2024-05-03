using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp
{
    public partial class Memo : Form
    {
        private StartUI startUI;

        private string detail;
        private string file;
        private string fileFullPath;

        private List<string> LinkList;
        private List<Image> ScreenShotList;
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
            detail = "no detail";
            file = "no file";
            fileFullPath = "no file";
            MakeCheckBox();
        }
        public void InitMemo(Memo savedmemo)
        {
            detail = savedmemo.detail;
            file = savedmemo.file;
            fileFullPath = savedmemo.fileFullPath;
            LinkList = savedmemo.LinkList;
            ScreenShotList = savedmemo.ScreenShotList;
            ContentText.Text = detail;
            fileName.Text = file;
        }
        public void AddLink(string link) => LinkList.Add(link);

        public void ShowLink()
        {
            for (int i = 0; i < LinkList.Count - 1; i++)
            {
                LinkPopUpButton.Text += LinkList[i] + " and ";
            }
            LinkPopUpButton.Text += LinkList[LinkList.Count - 1];
        }

        private void MakeCheckBox()
        {
            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                CheckBox screenCheckBox = new CheckBox();
                screenCheckBox.Text = "Screen " + (i + 1);
                screenCheckBox.Location = new Point(130 + i * 150, 110);
                screenCheckBox.Size = new Size(100, 30);
                this.Controls.Add(screenCheckBox);
            }
        }

        private void TakeScreenShot()
        {
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
        }

        private void CompletedButton_Click(object sender, EventArgs e)
        {
            //작성 완료 버튼 - test ver
            detail = ContentText.Text;
            startUI.AddMemo(this);
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
    }
}
