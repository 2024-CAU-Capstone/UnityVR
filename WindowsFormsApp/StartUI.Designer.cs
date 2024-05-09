namespace WindowsFormsApp
{
    partial class StartUI
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            YesterdayButton = new Button();
            NextdayButton = new Button();
            MakeMemoButton = new Button();
            MakeScheduleButton = new Button();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // YesterdayButton
            // 
            YesterdayButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            YesterdayButton.BackgroundImage = Properties.Resources.LeftArrow;
            YesterdayButton.BackgroundImageLayout = ImageLayout.Stretch;
            YesterdayButton.Location = new Point(12, 9);
            YesterdayButton.Margin = new Padding(3, 4, 3, 4);
            YesterdayButton.Name = "YesterdayButton";
            YesterdayButton.Size = new Size(34, 42);
            YesterdayButton.TabIndex = 0;
            YesterdayButton.UseVisualStyleBackColor = true;
            YesterdayButton.Click += YesterdayButton_Click;
            // 
            // NextdayButton
            // 
            NextdayButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            NextdayButton.BackgroundImage = Properties.Resources.RightArrow;
            NextdayButton.BackgroundImageLayout = ImageLayout.Stretch;
            NextdayButton.Location = new Point(235, 9);
            NextdayButton.Margin = new Padding(3, 4, 3, 4);
            NextdayButton.Name = "NextdayButton";
            NextdayButton.Size = new Size(34, 41);
            NextdayButton.TabIndex = 1;
            NextdayButton.UseVisualStyleBackColor = true;
            NextdayButton.Click += NextdayButton_Click;
            // 
            // MakeMemoButton
            // 
            MakeMemoButton.Location = new Point(692, 15);
            MakeMemoButton.Margin = new Padding(3, 4, 3, 4);
            MakeMemoButton.Name = "MakeMemoButton";
            MakeMemoButton.Size = new Size(96, 41);
            MakeMemoButton.TabIndex = 4;
            MakeMemoButton.Text = "메모 만들기";
            MakeMemoButton.UseVisualStyleBackColor = true;
            MakeMemoButton.Click += MakeMemoButton_Click;
            // 
            // MakeScheduleButton
            // 
            MakeScheduleButton.Location = new Point(692, 84);
            MakeScheduleButton.Margin = new Padding(3, 4, 3, 4);
            MakeScheduleButton.Name = "MakeScheduleButton";
            MakeScheduleButton.Size = new Size(96, 41);
            MakeScheduleButton.TabIndex = 5;
            MakeScheduleButton.Text = "일정 만들기";
            MakeScheduleButton.UseVisualStyleBackColor = true;
            MakeScheduleButton.Click += MakeScheduleButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("굴림", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(369, 93);
            label1.Name = "label1";
            label1.Size = new Size(110, 19);
            label1.TabIndex = 6;
            label1.Text = "미정리 메모";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("굴림", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(47, 19);
            label2.TabIndex = 7;
            label2.Text = "일정";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(51, 17);
            dateTimePicker1.Margin = new Padding(2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(179, 23);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // StartUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 338);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MakeScheduleButton);
            Controls.Add(MakeMemoButton);
            Controls.Add(NextdayButton);
            Controls.Add(YesterdayButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StartUI";
            Text = "Memo";
            FormClosing += ExitProgram;
            Load += StartUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button YesterdayButton;
        private System.Windows.Forms.Button NextdayButton;
        private System.Windows.Forms.Button MakeMemoButton;
        private System.Windows.Forms.Button MakeScheduleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

