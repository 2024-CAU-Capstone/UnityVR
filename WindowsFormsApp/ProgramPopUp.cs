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
        private List<ProcessInfo> ProcessList;

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
            ProcessList = PreserveProcess.GetWindowedProcesses();
            foreach (string program in ProgramList)
            {
                checkedListBox1.Items.Add(program);
            }
        }

        private void CompleteButton_Click_1(object sender, EventArgs e)
        {
            StringBuilder program = new StringBuilder();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    program.Append(checkedListBox1.Items[i].ToString());
                    program.Append(", ");
                    if (IsSchedule)
                    {
                        schedule.AddProgram(checkedListBox1.Items[i].ToString());
                        schedule.applicationName = program.ToString();
                        schedule.SetProcess(program.ToString());
                    }
                    else
                    {
                        memo.AddProgram(checkedListBox1.Items[i].ToString());
                        memo.AddProcess(ProcessList[i]);                      
                        memo.applicationName = program.ToString();
                        memo.SetProcess(program.ToString());
                    }                
                }
            }
            List<string> documents = DocumentExtract.OpenDocuments();
            foreach (string document in documents)
            {
                ProcessInfo doc = new ProcessInfo("word", document);
                if (IsSchedule)
                {
                    schedule.AddProcess(doc);
                    schedule.AddFile(document);
                }
                else
                {
                    memo.AddProcess(doc);
                    memo.AddFile(document);
                }
            }
            Close();
        }
    }
}
