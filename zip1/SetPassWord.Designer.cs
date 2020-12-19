namespace zip1
{
    partial class SetPassWord
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
         this.tbPassword = new System.Windows.Forms.TextBox();
         this.tbConfirmPassword = new System.Windows.Forms.TextBox();
         this.okButton = new System.Windows.Forms.Button();
         this.noteLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(19, 33);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(56, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Password:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(19, 71);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(45, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Confirm:";
         // 
         // tbPassword
         // 
         this.tbPassword.Location = new System.Drawing.Point(81, 30);
         this.tbPassword.Name = "tbPassword";
         this.tbPassword.PasswordChar = '•';
         this.tbPassword.Size = new System.Drawing.Size(163, 20);
         this.tbPassword.TabIndex = 2;
         // 
         // tbConfirmPassword
         // 
         this.tbConfirmPassword.Location = new System.Drawing.Point(81, 68);
         this.tbConfirmPassword.Name = "tbConfirmPassword";
         this.tbConfirmPassword.PasswordChar = '•';
         this.tbConfirmPassword.Size = new System.Drawing.Size(163, 20);
         this.tbConfirmPassword.TabIndex = 3;
         this.tbConfirmPassword.TextChanged += new System.EventHandler(this.tbConfirmPassword_TextChanged);
         // 
         // okButton
         // 
         this.okButton.Location = new System.Drawing.Point(135, 141);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(109, 28);
         this.okButton.TabIndex = 5;
         this.okButton.Text = "OK";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.okButton_Click);
         // 
         // noteLabel
         // 
         this.noteLabel.AutoSize = true;
         this.noteLabel.Location = new System.Drawing.Point(19, 104);
         this.noteLabel.Name = "noteLabel";
         this.noteLabel.Size = new System.Drawing.Size(33, 13);
         this.noteLabel.TabIndex = 4;
         this.noteLabel.Text = "Note:";
         // 
         // SetPassWord
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(264, 177);
         this.Controls.Add(this.okButton);
         this.Controls.Add(this.noteLabel);
         this.Controls.Add(this.tbConfirmPassword);
         this.Controls.Add(this.tbPassword);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Name = "SetPassWord";
         this.Text = "Enter Password";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label noteLabel;
    }
}