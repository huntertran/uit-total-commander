using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;
using IconHelper;

namespace TotalCommander
{
   public partial class Main : Form
   {

      #region Custom Variable

      public string path = "";
      public string path2 = "";

      public bool flagRename = false;
      public bool flagNewFolder = false;
      public bool flagListView1 = true;
      public bool flagListView2 = false;

      #endregion

      #region Show data to listView

      protected string FormatDate(DateTime dtDate)
      {
         //Get Date and Time in short Format
         string stringDate = "";
         stringDate = dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();

         return stringDate;
      }

      protected string FormatSize(Int64 lSize)
      {
         //Format number to KB
         string stringSize = "";
         NumberFormatInfo myNfi = new NumberFormatInfo();

         Int64 lKBSize = 0;

         if (lSize < 1024)
         {
            if (lSize == 0)
            {
               //zero byte
               stringSize = "0";
            }
            else
            {
               //less than 1K but not zero byte
               stringSize = "1";
            }
         }
         else
         {
            //convert to KB
            lKBSize = lSize / 1024;
            //format number with default format
            stringSize = lKBSize.ToString("n", myNfi);
            //remove decimal
            stringSize = stringSize.Replace(".00", "");
         }

         return stringSize + " KB";
      }

      protected string FormatSizeMB(Int64 lSize)
      {
         //Format size to MB
         if (lSize == 0)
            return "0";
         else
         {
            float lMBSize = lSize / 1048576;
            return lMBSize.ToString();
         }
      }

      private static DirectoryInfo GetRootDir(TreeNode parentNode)
      {
         char[] arr = { '\\' };
         string path = "";
         string[] nameList = parentNode.FullPath.Split(arr);
         string nodeName = nameList.GetValue(1).ToString();
         path += nodeName + "\\";

         for (int i = 2; i < nameList.Length; i++)
         {
            path += nameList[i] + "\\";
         }

         return new DirectoryInfo(path);
      }

      private void BrowseFolders(DirectoryInfo rootDir, ListView listView)
      {
         string[] listViewData = new string[5];

         foreach (DirectoryInfo dir in rootDir.GetDirectories())
         {
            // Write data to List View
            DirectoryInfo folder = new DirectoryInfo(dir.FullName);

            listViewData[0] = folder.Name;
            listViewData[1] = "Folder"; // "File Type Property
            listViewData[2] = folder.CreationTime.ToString(); //Time Created
            listViewData[3] = folder.LastWriteTime.ToString(); // Last Modified
            listViewData[4] = folder.FullName;

            int imageIndex = _iconListManager.AddFolderIcon();

            ListViewItem lvItemFolder = new ListViewItem(listViewData, imageIndex); //image index for folder is 5
            //lvItemFolder.ImageKey = "Folder";

            listView.Items.Add(lvItemFolder);
         }
      }

      private void BrowseFiles(string path, ListView lv)
      {
         string[] stringFiles = Directory.GetFiles(path);
         string stringFileName = null;
         string[] lvData = new string[6];

         DateTime dtCreateDate, dtModifiedDate;

         Int64 lFileSize = 0;

         foreach (string stringFile in stringFiles)
         {
            stringFileName = stringFile;

            FileInfo objFile = new FileInfo(stringFileName);

            lFileSize = objFile.Length;
            dtCreateDate = objFile.CreationTime;
            dtModifiedDate = objFile.LastWriteTime;

            //Write data to listView
            lvData[0] = GetPathName(stringFileName);
            lvData[1] = FormatSize(lFileSize);

            lvData[2] = FormatDate(dtCreateDate);
            lvData[3] = FormatDate(dtModifiedDate);

            lvData[4] = objFile.FullName.ToString();

            lvData[5] = FormatSizeMB(lFileSize);

            // Get icon for assigned file type in windows
            int imageIndex = _iconListManager.AddFileIcon(stringFile);
            ListViewItem lvItem = new ListViewItem(lvData, imageIndex);

            #region Show Assigned Icon

            // All Code was posted in Main.cs

            #endregion

            // Add to listView
            lv.Items.Add(lvItem);
         }
      }

      private void BrowseFilesAndFolder(DirectoryInfo rootDir, ListView lv)
      {
         try
         {
            lv.Items.Clear();

            BrowseFolders(rootDir, lv);
            BrowseFiles(rootDir.FullName, lv);
         }
         catch(Exception e)
         {
            MessageBox.Show(e.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void PopulateFiles(TreeNode currentNode)
      {
         string[] listViewData = new string[5];

         InitListView();

         if (currentNode.SelectedImageIndex != 10) //if My Computer is not selected
         {
            // Check for path
            if (Directory.Exists(GetFullPath(currentNode.FullPath)) == false) // not exist
            {
               MessageBox.Show("Current folder or path: " + currentNode.ToString() + " not exist");
            }
            else
            {
               try
               {
                  DirectoryInfo rootDir = GetRootDir(currentNode);
                  if (flagListView1)
                  {
                     BrowseFilesAndFolder(rootDir, listView1);
                  }
                  else if (flagListView2)
                  {
                     BrowseFilesAndFolder(rootDir, listView2);
                  }
                  
               }
               catch (IOException)
               {
                  MessageBox.Show("Drive not exist", "Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               catch (UnauthorizedAccessException)
               {
                  MessageBox.Show("Unauthorized Access", "Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               catch (Exception e)
               {
                  MessageBox.Show(e.Message, "Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }

      }

      #endregion

      #region path Taking care

      public void UpdatePath()
      {
         listView1TextBox.Text = path;
         listView2TextBox.Text = path2;
      }

      #endregion

      #region event for listView

      private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         ListViewItem item = listView1.FocusedItem;
         string pathItem = item.SubItems[4].Text;

         if (item.SubItems[1].Text == "Folder")
         {
            //reserved for address bar
            address = pathItem + "\\";
         }

         try
         {
            FileInfo fi = new FileInfo(pathItem);

            if (fi.Exists)
            {
               Process.Start(pathItem);

               path = fi.DirectoryName;
               UpdatePath();
            }
            else
            {
               DirectoryInfo rootDir = new DirectoryInfo(pathItem + "\\");

               if (!rootDir.Exists)
               {
                  MessageBox.Show("Path not Valid", "Error", MessageBoxButtons.OK);
                  return;
               }

               BrowseFilesAndFolder(rootDir, listView1);
               path = pathItem;
               UpdatePath();
            }
         }//end try

         catch (Win32Exception)
         {
            MessageBox.Show("There is no associated program to open this file type", "Caution", MessageBoxButtons.OK);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK);
         }
      }

      private void listView1_MouseUp(object sender, MouseEventArgs e)
      {
         item = listView1.FocusedItem;
         ChangeStatusBar(item, listView1);

         if (e.Button == MouseButtons.Right)
         {
            if (this.listView1.SelectedItems.Count > 0)
            {
               fileContextMenuStrip.Show(listView1, e.Location);
            }
            else
            {
               globalContextMenuStrip.Show(listView1, e.Location);
            }
         }
      }

      private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         ListViewItem item = listView2.FocusedItem;
         string pathItem = item.SubItems[4].Text;

         if (item.SubItems[1].Text == "Folder")
         {
            //reserved for address bar
            address = pathItem + "\\";
         }

         try
         {
            FileInfo fi = new FileInfo(pathItem);

            if (fi.Exists)
            {
               Process.Start(pathItem);

               path2 = fi.DirectoryName;
               UpdatePath();
            }
            else
            {
               DirectoryInfo rootDir = new DirectoryInfo(pathItem + "\\");

               if (!rootDir.Exists)
               {
                  MessageBox.Show("Path not Valid", "Error", MessageBoxButtons.OK);
                  return;
               }

               BrowseFilesAndFolder(rootDir, listView2);
               path2 = pathItem;
               UpdatePath();
            }
         }//end try

         catch (Win32Exception)
         {
            MessageBox.Show("There is no associated program to open this file type", "Caution", MessageBoxButtons.OK);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK);
         }
      }

      private void listView2_MouseUp(object sender, MouseEventArgs e)
      {
         item = listView2.FocusedItem;
         ChangeStatusBar(item, listView2);

         if (e.Button == MouseButtons.Right)
         {
            if (this.listView2.SelectedItems.Count > 0)
            {
               fileContextMenuStrip.Show(listView2, e.Location);
            }
            else
            {
               globalContextMenuStrip.Show(listView2, e.Location);
            }
         }
      }

      private void listView1_Enter(object sender, EventArgs e)
      {
         flagListView1 = true;
         flagListView2 = false;
      }

      private void listView2_Enter(object sender, EventArgs e)
      {
         flagListView1 = false;
         flagListView2 = true;
      }

      #endregion
   }
}
