using System.Windows.Forms;

namespace WindowsFormsApp
{
    partial class Schedule : Form
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
            this.fileName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CompletedButton = new System.Windows.Forms.Button();
            this.FilePopUPButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ContentText = new System.Windows.Forms.TextBox();
            this.LinkPopUpButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(208, 195);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(0, 12);
            this.fileName.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(624, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "일정 추가";
            // 
            // CompletedButton
            // 
            this.CompletedButton.Location = new System.Drawing.Point(635, 286);
            this.CompletedButton.Name = "CompletedButton";
            this.CompletedButton.Size = new System.Drawing.Size(95, 34);
            this.CompletedButton.TabIndex = 17;
            this.CompletedButton.Text = "작성 완료";
            this.CompletedButton.UseVisualStyleBackColor = true;
            this.CompletedButton.Click += new System.EventHandler(this.CompletedButton_Click);
            // 
            // FilePopUPButton
            // 
            this.FilePopUPButton.Location = new System.Drawing.Point(151, 196);
            this.FilePopUPButton.Name = "FilePopUPButton";
            this.FilePopUPButton.Size = new System.Drawing.Size(127, 35);
            this.FilePopUPButton.TabIndex = 16;
            this.FilePopUPButton.Text = "파일 선택";
            this.FilePopUPButton.UseVisualStyleBackColor = true;
            this.FilePopUPButton.Click += new System.EventHandler(this.FilePopUPButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(23, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "파일 추가 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(23, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "스크린샷 : ";
            // 
            // ContentText
            // 
            this.ContentText.Location = new System.Drawing.Point(91, 14);
            this.ContentText.Name = "ContentText";
            this.ContentText.Size = new System.Drawing.Size(382, 21);
            this.ContentText.TabIndex = 13;
            // 
            // LinkPopUpButton
            // 
            this.LinkPopUpButton.Location = new System.Drawing.Point(90, 55);
            this.LinkPopUpButton.Name = "LinkPopUpButton";
            this.LinkPopUpButton.Size = new System.Drawing.Size(383, 28);
            this.LinkPopUpButton.TabIndex = 12;
            this.LinkPopUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LinkPopUpButton.UseVisualStyleBackColor = true;
            this.LinkPopUpButton.Click += new System.EventHandler(this.LinkPopUpButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(-249, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "링크 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(-249, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "내용 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(23, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 21);
            this.label6.TabIndex = 20;
            this.label6.Text = "어플리케이션 지정 : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 35);
            this.button1.TabIndex = 21;
            this.button1.Text = "앱 선택";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(628, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(102, 20);
            this.comboBox1.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(12, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 25;
            this.label8.Text = "링크 : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(12, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 24;
            this.label9.Text = "내용 : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(628, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 26;
            // 
            // Schedule
            // 
            this.ClientSize = new System.Drawing.Size(742, 332);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CompletedButton);
            this.Controls.Add(this.FilePopUPButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ContentText);
            this.Controls.Add(this.LinkPopUpButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Schedule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label fileName;
        private Label label5;
        private Button CompletedButton;
        private Button FilePopUPButton;
        private Label label4;
        private Label label3;
        private TextBox ContentText;
        private Button LinkPopUpButton;
        private Label label2;
        private Label label1;
        private Label label6;
        private Button button1;
        private ComboBox comboBox1;
        private Label label8;
        private Label label9;
        private TextBox textBox1;
    }
}