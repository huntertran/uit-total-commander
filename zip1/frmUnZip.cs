using System;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;

namespace zip1
{
   public partial class frmUnZip : Form
   {

      public static string strGetPasswordToUnzip;
      string strLocationUnZip;
      string fileNameFull;

      public frmUnZip()
      {
         InitializeComponent();
         strLocationUnZip = "";
      }

      private void btBrowserFileUnZip_Click(object sender, EventArgs e)
      {
         OpenFileDialog open = new OpenFileDialog();
         open.ShowDialog();
         unzipFileTextBox.Text = Path.GetFileName(open.FileName.ToString());
         fileNameFull = open.FileName.ToString();
      }


      private void btLocationUnZip_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog fl = new FolderBrowserDialog();
         fl.ShowDialog();
         saveLocationTextBox.Text = fl.SelectedPath;
      }


      private void btExtract_Click(object sender, EventArgs e)
      {
         ZipFile unzip = ZipFile.Read(fileNameFull);
         strLocationUnZip = saveLocationTextBox.Text;

         if (strLocationUnZip == "")
         {
            MessageBox.Show("Please fill path to save file extract");
         }
         else
         {
            try
            {
               foreach (ZipEntry i in unzip)
               {
                  if (i.UsesEncryption)   // if filezip uses password
                  {
                     frmGetPasswordToUnzip frm = new frmGetPasswordToUnzip();
                     frm.ShowDialog();
                     i.ExtractWithPassword(strLocationUnZip, ExtractExistingFileAction.Throw, strGetPasswordToUnzip);
                  }
                  else
                  {
                     i.Extract(strLocationUnZip, ExtractExistingFileAction.Throw);
                  }
               }

               // if file is existing, show a message to announce
               //unzip.ExtractAll(strLocationUnZip, ExtractExistingFileAction.Throw);
               MessageBox.Show("Extract success!");
               this.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show("File name existed! Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void btCancelUnzip_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
