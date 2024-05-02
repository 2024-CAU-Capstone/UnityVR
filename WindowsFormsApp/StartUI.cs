using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class StartUI : Form
    {
        private List<Memo> MemoList;
        private List<Schedule> ScheduleList;
        private DateTime date;
        public StartUI()
        {
            InitializeComponent();
            InitStartUI();
        }

        private void InitStartUI()
        {
            MemoList = new List<Memo>();
            ScheduleList = new List<Schedule>();
            date = DateTime.Now;
            DateselectButton.Text = date.ToString("yy/MM/dd");
            LoadMemoAndSchedule();
        }

        private void MakeMomoUI()
        {
            for (int i = 0; i < 2; i++)//test
            {
                Button memoButton = new Button();
                memoButton.Text = "보안 문제 링크";
                memoButton.Location = new Point(370, 120 + i * 50);
                memoButton.Size = new Size(150, 30);
                memoButton.Click += new EventHandler(MemoListButton_Click);
                this.Controls.Add(memoButton);
            }
            //MemoList에 있는 메모들을 UI에 표시
            for (int i = 0; i < MemoList.Count; i++)
            {

            }
        }
        private void MakeScheduleUI()
        {
            //test
            for (int i = 0; i < 2; i++)
            {
                Label memoLabel = new Label();
                Button memoButton = new Button();
                memoLabel.Text = "07:00";
                memoLabel.Location = new Point(10, 120 + i * 50);
                memoLabel.Size = new Size(50, 15);
                memoButton.Text = "팀 정기 회의";
                memoButton.Location = new Point(10, 135 + i * 50);
                memoButton.Size = new Size(150, 30);
                memoButton.Click += new EventHandler(ScheduleListButton_Click);
                this.Controls.Add(memoLabel);
                this.Controls.Add(memoButton);
            }
            //ScheduleUI에 있는 메모들을 UI에 표시
            for (int i = 0; i < ScheduleList.Count; i++)
            {

            }
        }
        private void LoadMemoAndSchedule()
        {
            //MemoList와 ScheduleList를 불러옴
            MakeMomoUI();
            MakeScheduleUI();
        }

        private void ScheduleListButton_Click(object sender, EventArgs e)
        {
            //이미 만들어진 일정 내용 보여주기
        }
        private void MemoListButton_Click(object sender, EventArgs e)
        {
            //이미 만들어진 메모 내용 보여주기
        }

        private void MakeMemoButton_Click(object sender, EventArgs e)
        {
            //메모 만들기 창 띄우기
        }

        private void MakeScheduleButton_Click(object sender, EventArgs e)
        {
            //일정 만들기 창 띄우기
        }

        private void NextdayButton_Click(object sender, EventArgs e)
        {
            //다음 날짜로 이동
            date = date.AddDays(1);
            DateselectButton.Text = date.ToString("yy/MM/dd");
            DateselectButton.Update();
        }

        private void YesterdayButton_Click(object sender, EventArgs e)
        {
            //이전 날짜로 이동
            date = date.AddDays(-1);
            DateselectButton.Text = date.ToString("yy/MM/dd");
        }

        private void ExitProgram(object sender, FormClosingEventArgs e)
        {
            SaveMemoAndSchedule();
        }
        private void SaveMemoAndSchedule()
        {
            //MemoList와 ScheduleList를 저장

        }
    }
}
