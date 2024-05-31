namespace WindowsFormsApp
{
    partial class SendMailPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            NewMailAddress = new TextBox();
            AddNewMailButton = new Button();
            MailSelectionBox = new CheckedListBox();
            label3 = new Label();
            SendMail = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            label1.Location = new Point(63, 9);
            label1.Name = "label1";
            label1.Size = new Size(146, 28);
            label1.TabIndex = 0;
            label1.Text = "메일 주소 선택";
            
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(103, 19);
            label2.TabIndex = 1;
            label2.Text = "신규 메일 추가";
            
            // 
            // NewMailAddress
            // 
            NewMailAddress.Location = new Point(12, 72);
            NewMailAddress.Name = "NewMailAddress";
            NewMailAddress.Size = new Size(253, 23);
            NewMailAddress.TabIndex = 2;
            // 
            // AddNewMailButton
            // 
            AddNewMailButton.Location = new Point(190, 46);
            AddNewMailButton.Name = "AddNewMailButton";
            AddNewMailButton.Size = new Size(75, 23);
            AddNewMailButton.TabIndex = 3;
            AddNewMailButton.Text = "추가";
            AddNewMailButton.UseVisualStyleBackColor = true;
            AddNewMailButton.Click += AddNewMailButton_click;
            // 
            // MailSelectionBox
            // 
            MailSelectionBox.FormattingEnabled = true;
            MailSelectionBox.Location = new Point(12, 122);
            MailSelectionBox.Name = "MailSelectionBox";
            MailSelectionBox.Size = new Size(253, 292);
            MailSelectionBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            label3.Location = new Point(12, 101);
            label3.Name = "label3";
            label3.Size = new Size(70, 19);
            label3.TabIndex = 5;
            label3.Text = "메일 선택";
            // 
            // SendMail
            // 
            SendMail.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            SendMail.Location = new Point(12, 420);
            SendMail.Name = "SendMail";
            SendMail.Size = new Size(253, 32);
            SendMail.TabIndex = 6;
            SendMail.Text = "전송";
            SendMail.UseVisualStyleBackColor = true;
            SendMail.Click += SendMail_click;
            // 
            // SendMailPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 461);
            Controls.Add(SendMail);
            Controls.Add(label3);
            Controls.Add(MailSelectionBox);
            Controls.Add(AddNewMailButton);
            Controls.Add(NewMailAddress);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SendMailPopup";
            Text = "메일 전송";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox NewMailAddress;
        private Button AddNewMailButton;
        private CheckedListBox MailSelectionBox;
        private Label label3;
        private Button SendMail;
    }
}