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
            fileName = new Label();
            label5 = new Label();
            CompletedButton = new Button();
            FilePopUPButton = new Button();
            label4 = new Label();
            label3 = new Label();
            ContentText = new TextBox();
            LinkPopUpButton = new Button();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            ApplicationButton = new Button();
            comboBox = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            LoadButton = new Button();
            SendMail = new Button();
            SuspendLayout();
            // 
            // fileName
            // 
            fileName.AutoSize = true;
            fileName.Location = new Point(285, 211);
            fileName.Name = "fileName";
            fileName.Size = new Size(0, 15);
            fileName.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("굴림", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label5.Location = new Point(624, 9);
            label5.Name = "label5";
            label5.Size = new Size(106, 21);
            label5.TabIndex = 18;
            label5.Text = "일정 추가";
            // 
            // CompletedButton
            // 
            CompletedButton.Location = new Point(635, 286);
            CompletedButton.Name = "CompletedButton";
            CompletedButton.Size = new Size(95, 34);
            CompletedButton.TabIndex = 17;
            CompletedButton.Text = "작성 완료";
            CompletedButton.UseVisualStyleBackColor = true;
            CompletedButton.Click += CompletedButton_Click;
            // 
            // FilePopUPButton
            // 
            FilePopUPButton.Location = new Point(152, 200);
            FilePopUPButton.Name = "FilePopUPButton";
            FilePopUPButton.Size = new Size(127, 35);
            FilePopUPButton.TabIndex = 16;
            FilePopUPButton.Text = "파일 선택";
            FilePopUPButton.UseVisualStyleBackColor = true;
            FilePopUPButton.Click += FilePopUPButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label4.Location = new Point(23, 199);
            label4.Name = "label4";
            label4.Size = new Size(122, 21);
            label4.TabIndex = 15;
            label4.Text = "파일 추가 : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label3.Location = new Point(23, 123);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 14;
            label3.Text = "스크린샷 : ";
            // 
            // ContentText
            // 
            ContentText.Location = new Point(91, 14);
            ContentText.Name = "ContentText";
            ContentText.Size = new Size(382, 23);
            ContentText.TabIndex = 13;
            // 
            // LinkPopUpButton
            // 
            LinkPopUpButton.Location = new Point(90, 55);
            LinkPopUpButton.Name = "LinkPopUpButton";
            LinkPopUpButton.Size = new Size(383, 28);
            LinkPopUpButton.TabIndex = 12;
            LinkPopUpButton.TextImageRelation = TextImageRelation.ImageAboveText;
            LinkPopUpButton.UseVisualStyleBackColor = true;
            LinkPopUpButton.Click += LinkPopUpButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(-249, 63);
            label2.Name = "label2";
            label2.Size = new Size(73, 21);
            label2.TabIndex = 11;
            label2.Text = "링크 : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(-249, 22);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 10;
            label1.Text = "내용 : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label6.Location = new Point(23, 286);
            label6.Name = "label6";
            label6.Size = new Size(206, 21);
            label6.TabIndex = 20;
            label6.Text = "어플리케이션 지정 : ";
            // 
            // ApplicationButton
            // 
            ApplicationButton.Location = new Point(235, 283);
            ApplicationButton.Name = "ApplicationButton";
            ApplicationButton.Size = new Size(127, 35);
            ApplicationButton.TabIndex = 21;
            ApplicationButton.Text = "앱 선택";
            ApplicationButton.UseVisualStyleBackColor = true;
            ApplicationButton.Click += ApplicationButton_Click;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(628, 86);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(102, 23);
            comboBox.TabIndex = 23;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label8.Location = new Point(12, 55);
            label8.Name = "label8";
            label8.Size = new Size(73, 21);
            label8.TabIndex = 25;
            label8.Text = "링크 : ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label9.Location = new Point(12, 14);
            label9.Name = "label9";
            label9.Size = new Size(73, 21);
            label9.TabIndex = 24;
            label9.Text = "내용 : ";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(630, 53);
            maskedTextBox1.Mask = "90시90분";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(100, 23);
            maskedTextBox1.TabIndex = 27;
            maskedTextBox1.TextAlign = HorizontalAlignment.Center;
            maskedTextBox1.ValidatingType = typeof(DateTime);
            maskedTextBox1.TextChanged += maskedTextBox1TextChanged;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(534, 286);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(95, 34);
            LoadButton.TabIndex = 28;
            LoadButton.Text = "복구";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // SendMail
            // 
            SendMail.Location = new Point(630, 178);
            SendMail.Margin = new Padding(3, 4, 3, 4);
            SendMail.Name = "SendMail";
            SendMail.Size = new Size(95, 42);
            SendMail.TabIndex = 29;
            SendMail.Text = "메일 전송";
            SendMail.UseVisualStyleBackColor = true;
            // 
            // Schedule
            // 
            ClientSize = new Size(742, 332);
            Controls.Add(SendMail);
            Controls.Add(LoadButton);
            Controls.Add(maskedTextBox1);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(comboBox);
            Controls.Add(ApplicationButton);
            Controls.Add(label6);
            Controls.Add(fileName);
            Controls.Add(label5);
            Controls.Add(CompletedButton);
            Controls.Add(FilePopUPButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(ContentText);
            Controls.Add(LinkPopUpButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Schedule";
            ResumeLayout(false);
            PerformLayout();
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
        private Button ApplicationButton;
        private ComboBox comboBox;
        private Label label8;
        private Label label9;
        private MaskedTextBox maskedTextBox1;
        private Button LoadButton;
        private Button SendMail;
    }
}