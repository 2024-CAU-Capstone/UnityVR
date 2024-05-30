namespace WindowsFormsApp
{
    partial class MailLogin
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            EmailLabel = new Label();
            PasswordLabel = new Label();
            EmailBox = new TextBox();
            PasswordBox = new TextBox();
            label1 = new Label();
            EmailInsert = new Button();
            SuspendLayout();
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("맑은 고딕", 11F);
            EmailLabel.Location = new Point(13, 42);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(46, 20);
            EmailLabel.TabIndex = 0;
            EmailLabel.Text = "Email";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("맑은 고딕", 11F);
            PasswordLabel.Location = new Point(13, 88);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(32, 20);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "PW";
            // 
            // EmailBox
            // 
            EmailBox.Location = new Point(65, 42);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(228, 23);
            EmailBox.TabIndex = 2;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(65, 88);
            PasswordBox.MaxLength = 32;
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(228, 23);
            PasswordBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            label1.Location = new Point(87, 10);
            label1.Name = "label1";
            label1.Size = new Size(159, 25);
            label1.TabIndex = 4;
            label1.Text = "이메일 계정 정보";
            // 
            // EmailInsert
            // 
            EmailInsert.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            EmailInsert.Location = new Point(118, 117);
            EmailInsert.Name = "EmailInsert";
            EmailInsert.Size = new Size(108, 32);
            EmailInsert.TabIndex = 5;
            EmailInsert.Text = "정보 입력";
            EmailInsert.UseVisualStyleBackColor = true;
            EmailInsert.Click += EmailInsert_Click;
            // 
            // MailLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 161);
            Controls.Add(EmailInsert);
            Controls.Add(label1);
            Controls.Add(PasswordBox);
            Controls.Add(EmailBox);
            Controls.Add(PasswordLabel);
            Controls.Add(EmailLabel);
            Name = "MailLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        private void EmailInsert_Click(object sender, EventArgs e)
        {
            bool result = handler.ConnectMail(EmailBox.Text, PasswordBox.Text);
            if (result)
            {
                Close();
            }
            else
            {
                EmailBox.ResetText();
                PasswordBox.ResetText();
            }
        }

        #endregion

        private Label EmailLabel;
        private Label PasswordLabel;
        private TextBox EmailBox;
        private TextBox PasswordBox;
        private Label label1;
        private Button EmailInsert;
    }
}
