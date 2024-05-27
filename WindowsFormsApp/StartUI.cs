using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Windows.Win32.UI.Input.KeyboardAndMouse;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace WindowsFormsApp
{
    public partial class StartUI : Form
    {
        private List<Memo> MemoList;
        private List<Schedule> ScheduleList;
        private DateTime date;
        KeyboardHook hook;

        public StartUI()
        {
            InitializeComponent();
            InitStartUI();
            hook = new KeyboardHook();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(HOT_KEY_MODIFIERS.MOD_CONTROL | HOT_KEY_MODIFIERS.MOD_ALT, (uint)Keys.F12);
            hook.RegisterHotKey(HOT_KEY_MODIFIERS.MOD_CONTROL | HOT_KEY_MODIFIERS.MOD_ALT, (uint)Keys.F11);
            hook.RegisterHotKey(HOT_KEY_MODIFIERS.MOD_CONTROL | HOT_KEY_MODIFIERS.MOD_SHIFT, (uint)Keys.B);
        }
        #region public method
        public void AddMemo(Memo memo) => MemoList.Add(memo);
        public void AddSchedule(Schedule schedule) => ScheduleList.Add(schedule);
        public DateTime GetDate() => date;
        public void LoadMemoAndSchedule(DateTime date)
        {
            //날짜에 맞는 MemoList와 ScheduleList를 불러옴
            MakeMomoUI();
            MakeScheduleUI();
        }
        #endregion

        private void InitStartUI()
        {
            MemoList = new List<Memo>();
            ScheduleList = new List<Schedule>();
            date = DateTime.Now;
            ObjectSerialization objs = new ObjectSerialization(MemoList, ScheduleList);
            objs.LoadData(this);
            LoadMemoAndSchedule(date);
        }

        private void MakeMomoUI()
        {
            if(MemoList.Count == 0) return;
            int count = 0;
            for (int i = 0; i < MemoList.Count; i++)//test
            {
                if (MemoList[i].GetMemoTime().DayOfYear != date.DayOfYear)
                {
                    continue;
                }

                Button memoButton = new Button();
                Memo memo = MemoList[i];
                memoButton.Text = MemoList[i].detail;
                memoButton.Location = new Point(370, 120 + count * 50);
                memoButton.Size = new Size(150, 30);
                memoButton.Click += (sender, e) => { MemoListButton_Click(memo); };
                this.Controls.Add(memoButton);
                count++;
            }
            //MemoList에 있는 메모들을 UI에 표시
            for (int i = 0; i < MemoList.Count; i++)
            {

            }
        }
        private void MakeScheduleUI()
        {
            //test
            if (ScheduleList.Count == 0) return;
            int count = 0;
            for (int i = 0; i < ScheduleList.Count; i++)
            {
                
                if (ScheduleList[i].GetScheduleTime().DayOfYear != date.DayOfYear)
                {
                    continue;
                }
                
                Label memoLabel = new Label();
                Button memoButton = new Button();
                Schedule schedule = ScheduleList[i];
                memoLabel.Text = ScheduleList[i].time;
                memoLabel.Location = new Point(10, 120 + count * 50);
                memoLabel.Size = new Size(70, 15);
                memoButton.Text = ScheduleList[i].detail;
                memoButton.Location = new Point(10, 135 + count * 50);
                memoButton.Size = new Size(150, 30);
                Debug.WriteLine(count);
                memoButton.Click += (sender, e) => { ScheduleListButton_Click(schedule); };
                Debug.WriteLine("After: " + count);
                this.Controls.Add(memoLabel);
                this.Controls.Add(memoButton);
                count++;
            }
            //ScheduleUI에 있는 메모들을 UI에 표시
            for (int i = 0; i < ScheduleList.Count; i++)
            {

            }
        }
        
        #region Button Event
        private void ScheduleListButton_Click(Schedule schedule)
        {
            if (schedule != null)
            {
                Schedule NewSchedule = new Schedule(this);
                NewSchedule.InitSchedule(schedule);
                NewSchedule.Show();
            }
            else MessageBox.Show("해당 일정이 없습니다.");
        }
        private void MemoListButton_Click(Memo memo)
        {
            //이미 만들어진 메모 내용 보여주기
            if (memo != null)
            {
                Memo Newmemo = new Memo(this);
                Newmemo.InitMemo(memo);
                Newmemo.Show();
            }
            else MessageBox.Show("해당 메모가 없습니다.");
        }

        private void MakeMemoButton_Click(object sender, EventArgs e)
        {
            //메모 만들기 창 띄우기
            Memo memo = new Memo(this);
            memo.Show();

        }

        private void MakeScheduleButton_Click(object sender, EventArgs e)
        {
            //일정 만들기 창 띄우기
            Schedule schedule = new Schedule(this);
            schedule.Show();
        }

        private void NextdayButton_Click(object sender, EventArgs e)
        {
            //다음 날짜로 이동
            date = date.AddDays(1);
            dateTimePicker1.Value = date;
            LoadMemoAndSchedule(date);
        }

        private void YesterdayButton_Click(object sender, EventArgs e)
        {
            //이전 날짜로 이동
            date = date.AddDays(-1);
            dateTimePicker1.Value = date;
            LoadMemoAndSchedule(date);
        }

        private void ExitProgram(object sender, FormClosingEventArgs e)
        {
            SaveMemoAndSchedule();
        }
        #endregion
        private void SaveMemoAndSchedule()
        {
            //MemoList와 ScheduleList를 저장
        }

        private void StartUI_Load(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            LoadMemoAndSchedule(date);
        }

        #region Keyboard Shortcut Definition
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Key == (uint)Keys.F11)
            {
                Memo memo = new Memo(this);
                memo.Show();
                PInvoke.ShowWindow(new HWND(this.Handle), SHOW_WINDOW_CMD.SW_MINIMIZE);
            }
            else if (e.Key.ToString() == "F12")
            {
                Schedule schedule = new Schedule(this);
                schedule.Show();
            }
            else if (e.Key == (uint)Keys.B)
            {
                List<string> urls = BrowserUrlExtract.OpenUrls();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                ObjectSerialization objs = new ObjectSerialization(MemoList, ScheduleList);
                objs.SaveData();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
