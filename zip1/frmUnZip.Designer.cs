namespace zip1
{
    partial class frmUnZip
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
         this.btBrowserFileUnZip = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.btExtract = new System.Windows.Forms.Button();
         this.btLocationUnZip = new System.Windows.Forms.Button();
         this.openFileUnZip = new System.Windows.Forms.OpenFileDialog();
         this.btCancelUnzip = new System.Windows.Forms.Button();
         this.unzipFileTextBox = new System.Windows.Forms.TextBox();
         this.saveLocationTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(11, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(73, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "File to extract:";
         // 
         // btBrowserFileUnZip
         // 
         this.btBrowserFileUnZip.Location = new System.Drawing.Point(260, 19);
         this.btBrowserFileUnZip.Name = "btBrowserFileUnZip";
         this.btBrowserFileUnZip.Size = new System.Drawing.Size(83, 23);
         this.btBrowserFileUnZip.TabIndex = 2;
         this.btBrowserFileUnZip.Text = "Browse...";
         this.btBrowserFileUnZip.UseVisualStyleBackColor = true;
         this.btBrowserFileUnZip.Click += new System.EventHandler(this.btBrowserFileUnZip_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(11, 52);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(47, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Save to:";
         // 
         // btExtract
         // 
         this.btExtract.Location = new System.Drawing.Point(150, 90);
         this.btExtract.Name = "btExtract";
         this.btExtract.Size = new System.Drawing.Size(96, 27);
         this.btExtract.TabIndex = 5;
         this.btExtract.Text = "Extract";
         this.btExtract.UseVisualStyleBackColor = true;
         this.btExtract.Click += new System.EventHandler(this.btExtract_Click);
         // 
         // btLocationUnZip
         // 
         this.btLocationUnZip.Location = new System.Drawing.Point(260, 47);
         this.btLocationUnZip.Name = "btLocationUnZip";
         this.btLocationUnZip.Size = new System.Drawing.Size(83, 23);
         this.btLocationUnZip.TabIndex = 6;
         this.btLocationUnZip.Text = "Browse...";
         this.btLocationUnZip.UseVisualStyleBackColor = true;
         this.btLocationUnZip.Click += new System.EventHandler(this.btLocationUnZip_Click);
         // 
         // openFileUnZip
         // 
         this.openFileUnZip.FileName = "openFileUnZip";
         // 
         // btCancelUnzip
         // 
         this.btCancelUnzip.Location = new System.Drawing.Point(252, 90);
         this.btCancelUnzip.Name = "btCancelUnzip";
         this.btCancelUnzip.Size = new System.Drawing.Size(91, 27);
         this.btCancelUnzip.TabIndex = 8;
         this.btCancelUnzip.Text = "Cancel";
         this.btCancelUnzip.UseVisualStyleBackColor = true;
         this.btCancelUnzip.Click += new System.EventHandler(this.btCancelUnzip_Click);
         // 
         // unzipFileTextBox
         // 
         this.unzipFileTextBox.Location = new System.Drawing.Point(90, 21);
         this.unzipFileTextBox.Name = "unzipFileTextBox";
         this.unzipFileTextBox.Size = new System.Drawing.Size(161, 20);
         this.unzipFileTextBox.TabIndex = 9;
         // 
         // saveLocationTextBox
         // 
         this.saveLocationTextBox.Location = new System.Drawing.Point(90, 48);
         this.saveLocationTextBox.Name = "saveLocationTextBox";
         this.saveLocationTextBox.Size = new System.Drawing.Size(160, 20);
         this.saveLocationTextBox.TabIndex = 10;
         // 
         // frmUnZip
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(355, 127);
         this.Controls.Add(this.saveLocationTextBox);
         this.Controls.Add(this.unzipFileTextBox);
         this.Controls.Add(this.btCancelUnzip);
         this.Controls.Add(this.btLocationUnZip);
         this.Controls.Add(this.btExtract);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.btBrowserFileUnZip);
         this.Controls.Add(this.label1);
         this.Name = "frmUnZip";
         this.Text = "Extract file";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBrowserFileUnZip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btExtract;
        private System.Windows.Forms.Button btLocationUnZip;
        private System.Windows.Forms.OpenFileDialog openFileUnZip;
        private System.Windows.Forms.Button btCancelUnzip;
        private System.Windows.Forms.TextBox unzipFileTextBox;
        private System.Windows.Forms.TextBox saveLocationTextBox;
    }
}