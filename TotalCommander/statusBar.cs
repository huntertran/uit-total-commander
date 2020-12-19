using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TotalCommander
{
   public partial class Main : Form
   {
      public void ChangeStatusBar(ListViewItem item, ListView lv)
      {
         //int fileSize = 0;
         if (lv.SelectedItems.Count == 0)
         {
            counterStatus.Text = "No file/folder Selected";
            fileNameStatus.Text = "N/A";
            fileSizeStatus.Text = "N/A";
         }
         else if (lv.SelectedItems.Count == 1)
         {
            if (item.SubItems[1].Text == "Folder")
            {
               counterStatus.Text = lv.SelectedItems.Count.ToString() + " folder selected";
               fileNameStatus.Text = item.SubItems[0].Text;
               fileSizeStatus.Text = "N/A";
            }
            else
            {
               counterStatus.Text = lv.SelectedItems.Count.ToString() + " file selected";

               fileSizeStatus.Text = item.SubItems[1].Text;

               fileNameStatus.Text = item.SubItems[0].Text;
            }
         }
         else
         {
            int size = 0;
            int folderCount = 0;
            int fileCount = 0;

            ListView.SelectedListViewItemCollection selected = lv.SelectedItems;
            foreach (ListViewItem temp in selected)
            {
               if (temp.SubItems[1].Text == "Folder")
               {
                  folderCount++;
               }
               else
               {
                  fileCount++;
                  size = size + Convert.ToInt32(temp.SubItems[5].Text);
               }
            }

            fileSizeStatus.Text = size.ToString() + " MB";

            if (folderCount == 0)
            {
               counterStatus.Text = fileCount + " files selected";
            }
            else if (fileCount == 0)
            {
               counterStatus.Text = folderCount + " folders selected";
            }
            else
            {
               counterStatus.Text = folderCount + " folders and " + fileCount + " files selected";
            }

            fileNameStatus.Text = "Multiple items selected";
         }

      }
   }
}