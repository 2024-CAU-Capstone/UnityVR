namespace WindowsFormsApp
{
    partial class ProgramPopUp
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
            checkedListBox1 = new CheckedListBox();
            CancelButton = new Button();
            CompleteButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 79);
            checkedListBox1.Margin = new Padding(3, 4, 3, 4);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(282, 361);
            checkedListBox1.TabIndex = 1;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(12, 484);
            CancelButton.Margin = new Padding(3, 4, 3, 4);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(104, 39);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "취소";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // CompleteButton
            // 
            CompleteButton.Location = new Point(190, 484);
            CompleteButton.Margin = new Padding(3, 4, 3, 4);
            CompleteButton.Name = "CompleteButton";
            CompleteButton.Size = new Size(104, 39);
            CompleteButton.TabIndex = 3;
            CompleteButton.Text = "완료";
            CompleteButton.UseVisualStyleBackColor = true;
            CompleteButton.Click += CompleteButton_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("굴림", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(55, 31);
            label1.Name = "label1";
            label1.Size = new Size(192, 19);
            label1.TabIndex = 5;
            label1.Text = "최근 실행된 프로그램";
            // 
            // ProgramPopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 562);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(CompleteButton);
            Controls.Add(checkedListBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProgramPopUp";
            Text = "ProgramPopUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CompleteButton;
        private System.Windows.Forms.Label label1;
    }
}