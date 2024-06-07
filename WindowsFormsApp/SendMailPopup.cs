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
    public partial class SendMailPopup : Form
    {
        private MailHandler mailHandler;
        private FilePathTracker filePathTracker;
        public SendMailPopup(MailHandler mailHandler, FilePathTracker filePathTracker)
        {
            InitializeComponent();
            this.mailHandler = mailHandler;
            for (int i = 0; i < mailHandler.GetReceiverEmailList().Count; i++)
            {
                MailSelectionBox.Items.Add(mailHandler.GetReceiverEmailList()[i]);
            }

            this.filePathTracker = filePathTracker;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddNewMailButton_click(object sender, EventArgs e)
        {
            bool isInserted = this.mailHandler.AddReceiverEmail(NewMailAddress.Text);
            if (isInserted) MailSelectionBox.Items.Add(NewMailAddress.Text);
            NewMailAddress.ResetText();
        }

        private void SendMail_click(object sender, EventArgs e)
        {
            if (this.mailHandler.isConnectionInProgress)
            {
                MailNotLoaded mailNotLoaded = new MailNotLoaded();
                mailNotLoaded.Show();
                return;
            }
            List<string> result = new List<string>();
            if (MailSelectionBox.Items.Count > 0)
            {
                for (int i = 0; i < MailSelectionBox.CheckedItems.Count; i++)
                {
                    result.Add(MailSelectionBox.CheckedItems[i].ToString());
                }
            }
            this.mailHandler.SendMail(result, filePathTracker);
            Close();
        }
    }
}
