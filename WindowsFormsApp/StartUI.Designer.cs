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
            this.YesterdayButton.Location = new System.Drawing.Point(15, 18);
            this.YesterdayButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.YesterdayButton.Name = "YesterdayButton";
            this.YesterdayButton.Size = new System.Drawing.Size(44, 57);
            this.YesterdayButton.TabIndex = 0;
            this.YesterdayButton.UseVisualStyleBackColor = true;
            this.YesterdayButton.Click += new System.EventHandler(this.YesterdayButton_Click);
            // 
            // NextdayButton
            // 
            this.NextdayButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextdayButton.BackgroundImage = global::WindowsFormsApp.Properties.Resources.RightArrow;
            this.NextdayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextdayButton.Location = new System.Drawing.Point(201, 18);
            this.NextdayButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NextdayButton.Name = "NextdayButton";
            this.NextdayButton.Size = new System.Drawing.Size(44, 55);
            this.NextdayButton.TabIndex = 1;
            this.NextdayButton.UseVisualStyleBackColor = true;
            this.NextdayButton.Click += new System.EventHandler(this.NextdayButton_Click);
            // 
            // DateselectButton
            // 
            this.DateselectButton.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DateselectButton.Location = new System.Drawing.Point(63, 18);
            this.DateselectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DateselectButton.Name = "DateselectButton";
            this.DateselectButton.Size = new System.Drawing.Size(130, 55);
            this.DateselectButton.TabIndex = 2;
            this.DateselectButton.Text = "24/04/09";
            this.DateselectButton.UseVisualStyleBackColor = true;
            // 
            // MakeMemoButton
            // 
            this.MakeMemoButton.Location = new System.Drawing.Point(890, 20);
            this.MakeMemoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MakeMemoButton.Name = "MakeMemoButton";
            this.MakeMemoButton.Size = new System.Drawing.Size(123, 55);
            this.MakeMemoButton.TabIndex = 4;
            this.MakeMemoButton.Text = "메모 만들기";
            this.MakeMemoButton.UseVisualStyleBackColor = true;
            this.MakeMemoButton.Click += new System.EventHandler(this.MakeMemoButton_Click);
            // 
            // MakeScheduleButton
            // 
            this.MakeScheduleButton.Location = new System.Drawing.Point(890, 112);
            this.MakeScheduleButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MakeScheduleButton.Name = "MakeScheduleButton";
            this.MakeScheduleButton.Size = new System.Drawing.Size(123, 55);
            this.MakeScheduleButton.TabIndex = 5;
            this.MakeScheduleButton.Text = "일정 만들기";
            this.MakeScheduleButton.UseVisualStyleBackColor = true;
            this.MakeScheduleButton.Click += new System.EventHandler(this.MakeScheduleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(474, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "미정리 메모";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(15, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "일정";
            // 
            // StartUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 750);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MakeScheduleButton);
            this.Controls.Add(this.MakeMemoButton);
            this.Controls.Add(this.DateselectButton);
            this.Controls.Add(this.NextdayButton);
            this.Controls.Add(this.YesterdayButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StartUI";
            this.Text = "Memo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitProgram);
            this.Load += new System.EventHandler(this.StartUI_Load);
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

