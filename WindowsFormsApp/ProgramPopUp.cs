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
    public partial class ProgramPopUp : Form
    {
        private Schedule schedule;

        public ProgramPopUp(Schedule schedule)
        {
            InitializeComponent();
            this.schedule = schedule;
            InitPopUp();           
        }
        private void InitPopUp()
        {           
            GetProgramList();
            checkedListBox1.Items.Add("Link example A");
            checkedListBox1.Items.Add("Link example B");
        }
        private void GetProgramList()
        {
            //프로그램 목록을 받아오는 코드 추가 필요
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    //schedule.AddLink(checkedListBox1.CheckedItems[i].ToString());
                }
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
