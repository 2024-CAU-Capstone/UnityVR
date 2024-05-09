using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class PopUp : Form
    {
        private Memo memo;
        private Schedule schedule;
        private bool IsSchedule;

        public PopUp(Memo memo)
        {
            InitializeComponent();
            this.memo = memo;
            IsSchedule = false;
            InitPopUp();
        }
        public PopUp(Schedule schedule)
        {
            InitializeComponent();
            this.schedule = schedule;
            IsSchedule = true;
            InitPopUp();
        }

        private void InitPopUp()
        {
            GetLinkList();
            checkedListBox1.Items.Add("Link example A");
            checkedListBox1.Items.Add("Link example B");
        }

        protected void GetLinkList()
        {
            //링크 목록을 받아오는 코드 추가 필요
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if(!IsSchedule)
            {
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        memo.AddLink(checkedListBox1.CheckedItems[i].ToString());
                    }
                }
                memo.ShowLink();
            }
            else
            {
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        schedule.AddLink(checkedListBox1.CheckedItems[i].ToString());
                    }
                }
                schedule.ShowLink();
            }
           
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
