namespace zip1
{
    partial class frmZip
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
         this.lbListZip = new System.Windows.Forms.ListBox();
         this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
         this.btBrowserFolderZip = new System.Windows.Forms.Button();
         this.btDeleteZip = new System.Windows.Forms.Button();
         this.btCancelZip = new System.Windows.Forms.Button();
         this.btZip = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.tbLocation = new System.Windows.Forms.TextBox();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.btBrowserFileZip = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.tbFileNameZip = new System.Windows.Forms.TextBox();
         this.btSetPasswordZip = new System.Windows.Forms.Button();
         this.btBrowserToSaveZip = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lbListZip
         // 
         this.lbListZip.FormattingEnabled = true;
         this.lbListZip.Location = new System.Drawing.Point(15, 26);
         this.lbListZip.Name = "lbListZip";
         this.lbListZip.Size = new System.Drawing.Size(199, 264);
         this.lbListZip.TabIndex = 0;
         // 
         // btBrowserFolderZip
         // 
         this.btBrowserFolderZip.Location = new System.Drawing.Point(220, 26);
         this.btBrowserFolderZip.Name = "btBrowserFolderZip";
         this.btBrowserFolderZip.Size = new System.Drawing.Size(93, 23);
         this.btBrowserFolderZip.TabIndex = 1;
         this.btBrowserFolderZip.Text = "Browse Folder...";
         this.btBrowserFolderZip.UseVisualStyleBackColor = true;
         this.btBrowserFolderZip.Click += new System.EventHandler(this.btBrowserZip_Click);
         // 
         // btDeleteZip
         // 
         this.btDeleteZip.Location = new System.Drawing.Point(220, 84);
         this.btDeleteZip.Name = "btDeleteZip";
         this.btDeleteZip.Size = new System.Drawing.Size(93, 23);
         this.btDeleteZip.TabIndex = 2;
         this.btDeleteZip.Text = "Delete";
         this.btDeleteZip.UseVisualStyleBackColor = true;
         this.btDeleteZip.Click += new System.EventHandler(this.btDeleteZip_Click);
         // 
         // btCancelZip
         // 
         this.btCancelZip.Location = new System.Drawing.Point(220, 360);
         this.btCancelZip.Name = "btCancelZip";
         this.btCancelZip.Size = new System.Drawing.Size(93, 23);
         this.btCancelZip.TabIndex = 3;
         this.btCancelZip.Text = "Cancel";
         this.btCancelZip.UseVisualStyleBackColor = true;
         this.btCancelZip.Click += new System.EventHandler(this.btCancelZip_Click);
         // 
         // btZip
         // 
         this.btZip.Location = new System.Drawing.Point(121, 360);
         this.btZip.Name = "btZip";
         this.btZip.Size = new System.Drawing.Size(93, 23);
         this.btZip.TabIndex = 4;
         this.btZip.Text = "OK";
         this.btZip.UseVisualStyleBackColor = true;
         this.btZip.Click += new System.EventHandler(this.btOK_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(175, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "List of Files and Folder added to Zip";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 302);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(72, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "Save location";
         // 
         // tbLocation
         // 
         this.tbLocation.Location = new System.Drawing.Point(15, 318);
         this.tbLocation.Name = "tbLocation";
         this.tbLocation.Size = new System.Drawing.Size(199, 20);
         this.tbLocation.TabIndex = 7;
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.FileName = "openFileDialog1";
         // 
         // btBrowserFileZip
         // 
         this.btBrowserFileZip.Location = new System.Drawing.Point(220, 55);
         this.btBrowserFileZip.Name = "btBrowserFileZip";
         this.btBrowserFileZip.Size = new System.Drawing.Size(93, 23);
         this.btBrowserFileZip.TabIndex = 8;
         this.btBrowserFileZip.Text = "Browse File...";
         this.btBrowserFileZip.UseVisualStyleBackColor = true;
         this.btBrowserFileZip.Click += new System.EventHandler(this.btBrowserFileZip_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 344);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(52, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "File name";
         // 
         // tbFileNameZip
         // 
         this.tbFileNameZip.Location = new System.Drawing.Point(15, 360);
         this.tbFileNameZip.Name = "tbFileNameZip";
         this.tbFileNameZip.Size = new System.Drawing.Size(100, 20);
         this.tbFileNameZip.TabIndex = 11;
         // 
         // btSetPasswordZip
         // 
         this.btSetPasswordZip.Location = new System.Drawing.Point(220, 113);
         this.btSetPasswordZip.Name = "btSetPasswordZip";
         this.btSetPasswordZip.Size = new System.Drawing.Size(93, 25);
         this.btSetPasswordZip.TabIndex = 12;
         this.btSetPasswordZip.Text = "Set password...";
         this.btSetPasswordZip.UseVisualStyleBackColor = true;
         this.btSetPasswordZip.Click += new System.EventHandler(this.btSetPasswordZip_Click);
         // 
         // btBrowserToSaveZip
         // 
         this.btBrowserToSaveZip.Location = new System.Drawing.Point(220, 315);
         this.btBrowserToSaveZip.Name = "btBrowserToSaveZip";
         this.btBrowserToSaveZip.Size = new System.Drawing.Size(93, 23);
         this.btBrowserToSaveZip.TabIndex = 13;
         this.btBrowserToSaveZip.Text = "Browse...";
         this.btBrowserToSaveZip.UseVisualStyleBackColor = true;
         this.btBrowserToSaveZip.Click += new System.EventHandler(this.btBrowserToSaveZip_Click);
         // 
         // frmZip
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(329, 392);
         this.Controls.Add(this.btBrowserToSaveZip);
         this.Controls.Add(this.btSetPasswordZip);
         this.Controls.Add(this.tbFileNameZip);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.btBrowserFileZip);
         this.Controls.Add(this.tbLocation);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btZip);
         this.Controls.Add(this.btCancelZip);
         this.Controls.Add(this.btDeleteZip);
         this.Controls.Add(this.btBrowserFolderZip);
         this.Controls.Add(this.lbListZip);
         this.Name = "frmZip";
         this.Text = "Zip";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbListZip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btBrowserFolderZip;
        private System.Windows.Forms.Button btDeleteZip;
        private System.Windows.Forms.Button btCancelZip;
        private System.Windows.Forms.Button btZip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btBrowserFileZip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFileNameZip;
        private System.Windows.Forms.Button btSetPasswordZip;
        private System.Windows.Forms.Button btBrowserToSaveZip;
    }
}