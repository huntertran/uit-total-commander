namespace zip1
{
    partial class frmGetPasswordToUnzip
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
         this.tbGetPasswordToUnzip = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.btGetPasswordToUnzip = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // tbGetPasswordToUnzip
         // 
         this.tbGetPasswordToUnzip.Location = new System.Drawing.Point(12, 25);
         this.tbGetPasswordToUnzip.Name = "tbGetPasswordToUnzip";
         this.tbGetPasswordToUnzip.Size = new System.Drawing.Size(228, 20);
         this.tbGetPasswordToUnzip.TabIndex = 0;
         this.tbGetPasswordToUnzip.UseSystemPasswordChar = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(114, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Please enter password";
         // 
         // btGetPasswordToUnzip
         // 
         this.btGetPasswordToUnzip.Location = new System.Drawing.Point(83, 51);
         this.btGetPasswordToUnzip.Name = "btGetPasswordToUnzip";
         this.btGetPasswordToUnzip.Size = new System.Drawing.Size(75, 23);
         this.btGetPasswordToUnzip.TabIndex = 2;
         this.btGetPasswordToUnzip.Text = "OK";
         this.btGetPasswordToUnzip.UseVisualStyleBackColor = true;
         this.btGetPasswordToUnzip.Click += new System.EventHandler(this.btGetPasswordToUnzip_Click);
         // 
         // frmGetPasswordToUnzip
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(251, 83);
         this.Controls.Add(this.btGetPasswordToUnzip);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.tbGetPasswordToUnzip);
         this.Name = "frmGetPasswordToUnzip";
         this.Text = "Enter Password";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbGetPasswordToUnzip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGetPasswordToUnzip;
    }
}