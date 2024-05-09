namespace WindowsFormsApp
{
    partial class Memo
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
            LinkPopUpButton = new Button();
            ContentText = new TextBox();
            label3 = new Label();
            label4 = new Label();
            FilePopUPButton = new Button();
            CompletedButton = new Button();
            label5 = new Label();
            fileName = new Label();
            ApplicationButton = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 0;
            label1.Text = "내용 : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(73, 21);
            label2.TabIndex = 1;
            label2.Text = "링크 : ";
            // 
            // LinkPopUpButton
            // 
            LinkPopUpButton.Location = new Point(91, 62);
            LinkPopUpButton.Margin = new Padding(3, 4, 3, 4);
            LinkPopUpButton.Name = "LinkPopUpButton";
            LinkPopUpButton.Size = new Size(383, 35);
            LinkPopUpButton.TabIndex = 2;
            LinkPopUpButton.TextImageRelation = TextImageRelation.ImageAboveText;
            LinkPopUpButton.UseVisualStyleBackColor = true;
            LinkPopUpButton.Click += LinkPopUpButton_Click;
            // 
            // ContentText
            // 
            ContentText.Location = new Point(92, 11);
            ContentText.Margin = new Padding(3, 4, 3, 4);
            ContentText.Name = "ContentText";
            ContentText.Size = new Size(382, 23);
            ContentText.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 4;
            label3.Text = "스크린샷 : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label4.Location = new Point(12, 234);
            label4.Name = "label4";
            label4.Size = new Size(122, 21);
            label4.TabIndex = 5;
            label4.Text = "파일 추가 : ";
            // 
            // FilePopUPButton
            // 
            FilePopUPButton.Location = new Point(140, 230);
            FilePopUPButton.Margin = new Padding(3, 4, 3, 4);
            FilePopUPButton.Name = "FilePopUPButton";
            FilePopUPButton.Size = new Size(127, 44);
            FilePopUPButton.TabIndex = 6;
            FilePopUPButton.Text = "파일 선택";
            FilePopUPButton.UseVisualStyleBackColor = true;
            FilePopUPButton.Click += FilePopUPButton_Click;
            // 
            // CompletedButton
            // 
            CompletedButton.Location = new Point(693, 316);
            CompletedButton.Margin = new Padding(3, 4, 3, 4);
            CompletedButton.Name = "CompletedButton";
            CompletedButton.Size = new Size(95, 42);
            CompletedButton.TabIndex = 7;
            CompletedButton.Text = "작성 완료";
            CompletedButton.UseVisualStyleBackColor = true;
            CompletedButton.Click += CompletedButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("굴림", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label5.Location = new Point(689, 11);
            label5.Name = "label5";
            label5.Size = new Size(106, 21);
            label5.TabIndex = 8;
            label5.Text = "메모 추가";
            // 
            // fileName
            // 
            fileName.AutoSize = true;
            fileName.Location = new Point(273, 244);
            fileName.Name = "fileName";
            fileName.Size = new Size(0, 15);
            fileName.TabIndex = 9;
            // 
            // ApplicationButton
            // 
            ApplicationButton.Location = new Point(226, 321);
            ApplicationButton.Name = "ApplicationButton";
            ApplicationButton.Size = new Size(127, 35);
            ApplicationButton.TabIndex = 23;
            ApplicationButton.Text = "앱 선택";
            ApplicationButton.UseVisualStyleBackColor = true;
            ApplicationButton.Click += ApplicationButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label6.Location = new Point(14, 324);
            label6.Name = "label6";
            label6.Size = new Size(206, 21);
            label6.TabIndex = 22;
            label6.Text = "어플리케이션 지정 : ";
            // 
            // Memo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 371);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "Memo";
            Text = "Memo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LinkPopUpButton;
        private System.Windows.Forms.TextBox ContentText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button FilePopUPButton;
        private System.Windows.Forms.Button CompletedButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label fileName;
        private Button ApplicationButton;
        private Label label6;
    }
}