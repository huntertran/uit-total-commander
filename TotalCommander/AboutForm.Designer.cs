namespace TotalCommander
{
   partial class AboutForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.programNameLabel = new System.Windows.Forms.Label();
         this.versionLabel = new System.Windows.Forms.Label();
         this.infoLabel = new System.Windows.Forms.Label();
         this.licenseGroupBox = new System.Windows.Forms.GroupBox();
         this.licenseName = new System.Windows.Forms.Label();
         this.noticeTextBox = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.licenseGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::TotalCommander.Properties.Resources.TotalCommander;
         this.pictureBox1.Location = new System.Drawing.Point(12, 12);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(126, 127);
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         // 
         // programNameLabel
         // 
         this.programNameLabel.AutoSize = true;
         this.programNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.programNameLabel.ForeColor = System.Drawing.SystemColors.Info;
         this.programNameLabel.Location = new System.Drawing.Point(151, 13);
         this.programNameLabel.Name = "programNameLabel";
         this.programNameLabel.Size = new System.Drawing.Size(345, 31);
         this.programNameLabel.TabIndex = 1;
         this.programNameLabel.Text = "Total Commander - Rebuild";
         // 
         // versionLabel
         // 
         this.versionLabel.AutoSize = true;
         this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.versionLabel.ForeColor = System.Drawing.SystemColors.Info;
         this.versionLabel.Location = new System.Drawing.Point(153, 58);
         this.versionLabel.Name = "versionLabel";
         this.versionLabel.Size = new System.Drawing.Size(110, 24);
         this.versionLabel.TabIndex = 2;
         this.versionLabel.Text = "Version: 1.0";
         // 
         // infoLabel
         // 
         this.infoLabel.AutoSize = true;
         this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.infoLabel.ForeColor = System.Drawing.SystemColors.Info;
         this.infoLabel.Location = new System.Drawing.Point(153, 99);
         this.infoLabel.Name = "infoLabel";
         this.infoLabel.Size = new System.Drawing.Size(265, 40);
         this.infoLabel.TabIndex = 3;
         this.infoLabel.Text = "WINP1.C24 Final Projects\r\nUniversity of Information Technology";
         // 
         // licenseGroupBox
         // 
         this.licenseGroupBox.Controls.Add(this.licenseName);
         this.licenseGroupBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
         this.licenseGroupBox.Location = new System.Drawing.Point(12, 152);
         this.licenseGroupBox.Name = "licenseGroupBox";
         this.licenseGroupBox.Size = new System.Drawing.Size(171, 54);
         this.licenseGroupBox.TabIndex = 4;
         this.licenseGroupBox.TabStop = false;
         this.licenseGroupBox.Text = "This product is licensed to";
         // 
         // licenseName
         // 
         this.licenseName.AutoSize = true;
         this.licenseName.Location = new System.Drawing.Point(6, 25);
         this.licenseName.Name = "licenseName";
         this.licenseName.Size = new System.Drawing.Size(95, 13);
         this.licenseName.TabIndex = 0;
         this.licenseName.Text = "Phan Nguyệt Minh";
         // 
         // noticeTextBox
         // 
         this.noticeTextBox.Location = new System.Drawing.Point(204, 152);
         this.noticeTextBox.Multiline = true;
         this.noticeTextBox.Name = "noticeTextBox";
         this.noticeTextBox.ReadOnly = true;
         this.noticeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.noticeTextBox.Size = new System.Drawing.Size(291, 54);
         this.noticeTextBox.TabIndex = 5;
         this.noticeTextBox.Text = resources.GetString("noticeTextBox.Text");
         // 
         // AboutForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.ClientSize = new System.Drawing.Size(507, 226);
         this.Controls.Add(this.noticeTextBox);
         this.Controls.Add(this.licenseGroupBox);
         this.Controls.Add(this.infoLabel);
         this.Controls.Add(this.versionLabel);
         this.Controls.Add(this.programNameLabel);
         this.Controls.Add(this.pictureBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AboutForm";
         this.Text = "About Program";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.licenseGroupBox.ResumeLayout(false);
         this.licenseGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label programNameLabel;
      private System.Windows.Forms.Label versionLabel;
      private System.Windows.Forms.Label infoLabel;
      private System.Windows.Forms.GroupBox licenseGroupBox;
      private System.Windows.Forms.Label licenseName;
      private System.Windows.Forms.TextBox noticeTextBox;
   }
}