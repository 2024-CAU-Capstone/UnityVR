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
        private Memo memo;
        private bool IsSchedule;
        private List<string> ProgramList;

        public ProgramPopUp(Schedule schedule)
        {
            InitializeComponent();
            this.schedule = schedule;
            IsSchedule = true;
            InitPopUp();
        }
        public ProgramPopUp(Memo memo)
        {
            InitializeComponent();
            this.memo = memo;
            IsSchedule = false;
            InitPopUp();
        }
        private void InitPopUp()
        {           
            GetProgramList();
        }
        private void GetProgramList()
        {
            ProgramList = PreserveProcess.RetrieveProcessNames();
            foreach (string program in ProgramList)
            {
                checkedListBox1.Items.Add(program);
            }
        }

        private void CompleteButton_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (IsSchedule)
                    {
                        schedule.AddProgram(checkedListBox1.CheckedItems[i].ToString());
                    }
                    else
                    {
                        memo.AddProgram(checkedListBox1.CheckedItems[i].ToString());
                    }                
                }
            }
            Close();
        }
    }
}
