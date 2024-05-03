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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LinkPopUpButton = new System.Windows.Forms.Button();
            this.ContentText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FilePopUPButton = new System.Windows.Forms.Button();
            this.CompletedButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "내용 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "링크 : ";
            // 
            // LinkPopUpButton
            // 
            this.LinkPopUpButton.Location = new System.Drawing.Point(91, 50);
            this.LinkPopUpButton.Name = "LinkPopUpButton";
            this.LinkPopUpButton.Size = new System.Drawing.Size(383, 28);
            this.LinkPopUpButton.TabIndex = 2;
            this.LinkPopUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LinkPopUpButton.UseVisualStyleBackColor = true;
            this.LinkPopUpButton.Click += new System.EventHandler(this.LinkPopUpButton_Click);
            // 
            // ContentText
            // 
            this.ContentText.Location = new System.Drawing.Point(92, 9);
            this.ContentText.Name = "ContentText";
            this.ContentText.Size = new System.Drawing.Size(382, 21);
            this.ContentText.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "스크린샷 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(12, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "파일 추가 : ";
            // 
            // FilePopUPButton
            // 
            this.FilePopUPButton.Location = new System.Drawing.Point(140, 184);
            this.FilePopUPButton.Name = "FilePopUPButton";
            this.FilePopUPButton.Size = new System.Drawing.Size(127, 35);
            this.FilePopUPButton.TabIndex = 6;
            this.FilePopUPButton.Text = "파일 선택";
            this.FilePopUPButton.UseVisualStyleBackColor = true;
            this.FilePopUPButton.Click += new System.EventHandler(this.FilePopUPButton_Click);
            // 
            // CompletedButton
            // 
            this.CompletedButton.Location = new System.Drawing.Point(693, 191);
            this.CompletedButton.Name = "CompletedButton";
            this.CompletedButton.Size = new System.Drawing.Size(95, 34);
            this.CompletedButton.TabIndex = 7;
            this.CompletedButton.Text = "작성 완료";
            this.CompletedButton.UseVisualStyleBackColor = true;
            this.CompletedButton.Click += new System.EventHandler(this.CompletedButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(689, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "메모 추가";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(273, 195);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(0, 12);
            this.fileName.TabIndex = 9;
            // 
            // Memo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 237);
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
            this.Name = "Memo";
            this.Text = "Memo";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}