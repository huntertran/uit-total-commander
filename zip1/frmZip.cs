using System;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;

namespace zip1
{
   public partial class frmZip : Form
   {
      public static int count;
      public static string strFileName; // string stores file name

      public frmZip()
      {
         InitializeComponent();
         SetButtonState();
      }

      private void SetButtonState()
      {
         tbLocation.Enabled = false;
         tbFileNameZip.Enabled = false;
         btDeleteZip.Enabled = false;

         btSetPasswordZip.Enabled = false;
         btBrowserToSaveZip.Enabled = false;
         btZip.Enabled = false;
      }

      private void btBrowserZip_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog fd = new FolderBrowserDialog();
         if (fd.ShowDialog() == DialogResult.OK)
         {
            lbListZip.Items.Add(fd.SelectedPath);

            //Enable function
            btDeleteZip.Enabled = true;
            tbLocation.Enabled = true;
            btBrowserToSaveZip.Enabled = true;
            btSetPasswordZip.Enabled = true;
            btZip.Enabled = true;

         }
      }

      private void btBrowserFileZip_Click(object sender, EventArgs e)
      {
         OpenFileDialog of = new OpenFileDialog();
         if (of.ShowDialog() == DialogResult.OK)
         {
            lbListZip.Items.Add(of.FileName.ToString());

            //Enable function
            btDeleteZip.Enabled = true;
            tbLocation.Enabled = true;
            btBrowserToSaveZip.Enabled = true;
            btSetPasswordZip.Enabled = true;
            btZip.Enabled = true;
         }
      }

      private void btDeleteZip_Click(object sender, EventArgs e)
      {
         lbListZip.Items.RemoveAt(lbListZip.SelectedIndex);
         if (lbListZip.Items.Count == 0)
         {
            tbLocation.Enabled = false;
            btBrowserToSaveZip.Enabled = false;
            btSetPasswordZip.Enabled = false;
            btZip.Enabled = false;
         }
      }

      private void btCancelZip_Click(object sender, EventArgs e)
      {
         frmZip.ActiveForm.Close();
      }

      private void btSetPasswordZip_Click(object sender, EventArgs e)
      {
         Form frm = new zip1.SetPassWord();
         frm.Show();
      }

      private void btOK_Click(object sender, EventArgs e)
      {
         ZipFile arrZip = new ZipFile();


         if (lbListZip.Items.Count == 0)    //check if there is something to zip
         {
            MessageBox.Show("Please choose file(s) or folder(s) need to archive","Notice",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            tbFileNameZip.Enabled = false;
            tbLocation.Enabled = false;
         }
         else
            if (tbLocation.Text == "")   // check if location is empty
            {
               MessageBox.Show("Empty Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               tbFileNameZip.Enabled = false;
            }
            else
            {
               if (!Directory.Exists(tbLocation.Text)) //check: is location right?
                  MessageBox.Show("Save location not existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               else
               {
                  tbFileNameZip.Enabled = true;

                  if (tbFileNameZip.Text == "")// third, check: Is name's archived file empty?
                  {
                     MessageBox.Show("Enter file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
                  else
                  {
                     if (File.Exists(tbLocation.Text + "\\" + tbFileNameZip.Text + ".zip")) // check: was file name exist?
                        MessageBox.Show("File name existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     else
                     {
                        if (SetPassWord.strPassword != "")  // check: if password isn't empty, set password for file zip
                        {
                           arrZip.Password = SetPassWord.strPassword;
                        }

                        foreach (string i in lbListZip.Items) // add file or folder need zip
                        {
                           try
                           {
                              arrZip.AddDirectory(i);
                           }
                           catch
                           {
                              arrZip.AddFile(i);
                           }
                        }
                        arrZip.Save(tbLocation.Text + "\\" + tbFileNameZip.Text + ".zip");
                        MessageBox.Show("Zip successed!");
                        this.Close();
                     }
                  }
               }
            }
      }

      private void btBrowserToSaveZip_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog flLocationZip = new FolderBrowserDialog();
         if (flLocationZip.ShowDialog() == DialogResult.OK)
         {
            tbLocation.Text = flLocationZip.SelectedPath;
            if (tbLocation.Text != "")
               tbFileNameZip.Enabled = true;
         }
      }
   }
}