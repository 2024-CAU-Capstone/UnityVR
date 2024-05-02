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
            this.YesterdayButton = new System.Windows.Forms.Button();
            this.NextdayButton = new System.Windows.Forms.Button();
            this.DateselectButton = new System.Windows.Forms.Button();
            this.MakeMemoButton = new System.Windows.Forms.Button();
            this.MakeScheduleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // YesterdayButton
            // 
            this.YesterdayButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.YesterdayButton.BackgroundImage = global::WindowsFormsApp.Properties.Resources.LeftArrow;
            this.YesterdayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YesterdayButton.Location = new System.Drawing.Point(12, 11);
            this.YesterdayButton.Name = "YesterdayButton";
            this.YesterdayButton.Size = new System.Drawing.Size(34, 34);
            this.YesterdayButton.TabIndex = 0;
            this.YesterdayButton.UseVisualStyleBackColor = true;
            this.YesterdayButton.Click += new System.EventHandler(this.YesterdayButton_Click);
            // 
            // NextdayButton
            // 
            this.NextdayButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextdayButton.BackgroundImage = global::WindowsFormsApp.Properties.Resources.RightArrow;
            this.NextdayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextdayButton.Location = new System.Drawing.Point(156, 11);
            this.NextdayButton.Name = "NextdayButton";
            this.NextdayButton.Size = new System.Drawing.Size(34, 33);
            this.NextdayButton.TabIndex = 1;
            this.NextdayButton.UseVisualStyleBackColor = true;
            this.NextdayButton.Click += new System.EventHandler(this.NextdayButton_Click);
            // 
            // DateselectButton
            // 
            this.DateselectButton.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DateselectButton.Location = new System.Drawing.Point(49, 11);
            this.DateselectButton.Name = "DateselectButton";
            this.DateselectButton.Size = new System.Drawing.Size(101, 33);
            this.DateselectButton.TabIndex = 2;
            this.DateselectButton.Text = "24/04/09";
            this.DateselectButton.UseVisualStyleBackColor = true;
            // 
            // MakeMemoButton
            // 
            this.MakeMemoButton.Location = new System.Drawing.Point(692, 12);
            this.MakeMemoButton.Name = "MakeMemoButton";
            this.MakeMemoButton.Size = new System.Drawing.Size(96, 33);
            this.MakeMemoButton.TabIndex = 4;
            this.MakeMemoButton.Text = "메모 만들기";
            this.MakeMemoButton.UseVisualStyleBackColor = true;
            this.MakeMemoButton.Click += new System.EventHandler(this.MakeMemoButton_Click);
            // 
            // MakeScheduleButton
            // 
            this.MakeScheduleButton.Location = new System.Drawing.Point(692, 67);
            this.MakeScheduleButton.Name = "MakeScheduleButton";
            this.MakeScheduleButton.Size = new System.Drawing.Size(96, 33);
            this.MakeScheduleButton.TabIndex = 5;
            this.MakeScheduleButton.Text = "일정 만들기";
            this.MakeScheduleButton.UseVisualStyleBackColor = true;
            this.MakeScheduleButton.Click += new System.EventHandler(this.MakeScheduleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(369, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "미정리 메모";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "일정";
            // 
            // StartUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MakeScheduleButton);
            this.Controls.Add(this.MakeMemoButton);
            this.Controls.Add(this.DateselectButton);
            this.Controls.Add(this.NextdayButton);
            this.Controls.Add(this.YesterdayButton);
            this.Name = "StartUI";
            this.Text = "Memo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitProgram);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button YesterdayButton;
        private System.Windows.Forms.Button NextdayButton;
        private System.Windows.Forms.Button DateselectButton;
        private System.Windows.Forms.Button MakeMemoButton;
        private System.Windows.Forms.Button MakeScheduleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

