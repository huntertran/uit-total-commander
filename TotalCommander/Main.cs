using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.InteropServices;
using Shell32;
using IconHelper;
using zip1;

namespace TotalCommander
{
   public partial class Main : Form
   {

      #region for showing Icon in listView

      private ImageList _smallImageList = new ImageList();
      private ImageList _largeImageList = new ImageList();
      private IconListManager _iconListManager;

      #endregion

      public Main()
      {
         InitializeComponent();
         PopulateDriveList();

         #region for showing Icon in listView

         _smallImageList.ColorDepth = ColorDepth.Depth32Bit;
         _largeImageList.ColorDepth = ColorDepth.Depth32Bit;

         _smallImageList.ImageSize = new System.Drawing.Size(16, 16);
         _largeImageList.ImageSize = new System.Drawing.Size(32, 32);

         _iconListManager = new IconListManager(_smallImageList, _largeImageList);

         listView1.SmallImageList = _smallImageList;
         listView1.LargeImageList = _largeImageList;

         listView2.SmallImageList = _smallImageList;
         listView2.LargeImageList = _largeImageList;

         #endregion

         UpdatePath();
      }

      #region ControlButton

      #region Utilites and Help

      private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         AboutForm f = new AboutForm();
         f.Show();
      }

      private void contactMeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ContactMeForm f = new ContactMeForm();
         f.Show();
      }

      private void moreButton_Click(object sender, EventArgs e)
      {
         MoreForm f = new MoreForm();
         f.Show();
      }

      private void cmdButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\cmd.exe", "cd /D C:/");
      }

      private void msconfigButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\msconfig.exe");
      }

      private void taskmgrButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\taskmgr.exe");
      }

      private void winverButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\winver.exe");
      }

      private void diagButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\dxdiag.exe");
      }

      #endregion

      #region Main Control

      private void upButton_Click(object sender, EventArgs e)
      {
         try
         {
            if (flagListView1)
            {
               if (path.Length != 3 && path != "My Computer") //Check if this is the root computer dir
               {
                  //Get Parent dir
                  string parent = FileSystem.GetParentPath(path);

                  //Update path
                  path = parent;

                  //Set up address
                  address = path + "\\";

                  //Show current dir into listView
                  //path declared in listView1.cs
                  string[] array = path.Split('\\');
                  string name = array[array.Length - 1];

                  DirectoryInfo rootDir = new DirectoryInfo(parent);
                  BrowseFilesAndFolder(rootDir, listView1);

                  UpdatePath();
               }
               else if (path.Length == 3)
               {
                  path = "My Computer";
                  //Set up address
                  address = path;

                  UpdatePath();
               }
               else if (path == "My Computer")
               {
                  MessageBox.Show("Cannot go to higher folder. This is the root", "Information",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }
            else
            {
               if (path2.Length != 3 && path2 != "My Computer") //Check if this is the root computer dir
               {
                  //Get Parent dir
                  string parent = FileSystem.GetParentPath(path2);

                  //Update path
                  path2 = parent;

                  //Set up address
                  address = path2 + "\\";

                  //Show current dir into listView
                  //path declared in listView1.cs
                  string[] array = path2.Split('\\');
                  string name = array[array.Length - 1];

                  DirectoryInfo rootDir = new DirectoryInfo(parent);
                  BrowseFilesAndFolder(rootDir, listView2);

                  UpdatePath();
               }
               else if (path2.Length == 3)
               {
                  path2 = "My Computer";
                  //Set up address
                  address = path2;

                  UpdatePath();
               }
               else if (path2 == "My Computer")
               {
                  MessageBox.Show("Cannot go to higher folder. This is the root", "Information",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void reloadButton_Click(object sender, EventArgs e)
      {
         PopulateDriveList();
      }

      private void backButton_Click(object sender, EventArgs e)
      {
         MessageBox.Show("Back function seems tobe not neccessary. Function under development", "Sorry!",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void newTextButton_Click(object sender, EventArgs e)
      {
         FileStream fs = null;
         int number = 0;
         string fileName = "New Text";
         string fileExtension = ".txt";
         string fileLocation = "";
         string parentPath = "";

         if (flagListView1)
         {
            //parentPath = FileSystem.GetParentPath(path);
            fileLocation = path + "\\" + fileName + fileExtension;

            while (File.Exists(fileLocation))
            {
               number++;
               string fileNumber = "[" + number.ToString() + "]";
               fileLocation = path + "\\" + fileName + fileNumber + fileExtension;
            }

            using (fs = File.Create(fileLocation))
            { }

            BrowseFilesAndFolder(new DirectoryInfo(path), listView1);
         }
         else
         {
            //parentPath = FileSystem.GetParentPath(path2);
            fileLocation = path + "\\" + fileName + fileExtension;

            while (File.Exists(fileLocation))
            {
               number++;
               string fileNumber = "[" + number.ToString() + "]";
               fileLocation = path + "\\" + fileName + fileNumber + fileExtension;
            }

            using (fs = File.Create(fileLocation))
            { }

            BrowseFilesAndFolder(new DirectoryInfo(path2), listView2);
         }
      }

      private void zipButton_Click(object sender, EventArgs e)
      {
         Form frm = new zip1.frmZip();
         frm.Show();
      }

      private void unZipButton_Click(object sender, EventArgs e)
      {
         Form frm = new zip1.frmUnZip();
         frm.Show();
      }

      #endregion

      #region View Control

      private void directRenameCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         if (directRenameCheckBox.Checked == true)
         {
            directRenameCheckBox.Text = "Disable Direct Rename";
            listView1.LabelEdit = true;
            listView2.LabelEdit = true;
         }
         else
         {
            directRenameCheckBox.Text = "Enable Direct Rename";
            listView1.LabelEdit = false;
            listView2.LabelEdit = false;
         }
      }

      private void listView1_BeforeLabelEdit(object sender, LabelEditEventArgs e)
      {
         flagRename = true;
      }

      private void viewLayoutComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (flagListView1)
         {
            switch (viewLayoutComboBox.SelectedIndex)
            {
               case 0: //Large Icon layout
                  listView1.View = View.LargeIcon;
                  break;
               case 1: //List layout
                  listView1.View = View.List;
                  break;
               case 2: //Details Layout
                  listView1.View = View.Details;
                  break;
            }
         }
         else
         {
            switch (viewLayoutComboBox.SelectedIndex)
            {
               case 0: //Large Icon layout
                  listView2.View = View.LargeIcon;
                  break;
               case 1: //List layout
                  listView2.View = View.List;
                  break;
               case 2: //Details Layout
                  listView2.View = View.Details;
                  break;
            }
         }
      }

      #endregion

      #endregion

      #region File and Global Context Menu Tool Strip

      #region Custom Variable

      public bool flagCopy;
      public bool flagMove;
      public bool flagDir;
      public string sourceDir;
      public string sourceFile;
      public string strDestDir;
      public string strDest;
      public string itemName;
      public string address;
      public ListViewItem item = new ListViewItem();

      #endregion

      #region File Context Menu Tool Strip

      private void renameToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
         {
            flagRename = true;
            listView1.LabelEdit = true;
            listView1.SelectedItems[0].BeginEdit();
         }
         else
         {
            flagRename = true;
            listView2.LabelEdit = true;
            listView2.SelectedItems[0].BeginEdit();
         }
      }

      private void copyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         flagCopy = true;
         flagMove = false;

         try
         {
            if (flagListView1)
            {
               if (listView1.Focused) //Copy from listView
               {
                  if (listView1.SelectedItems.Count != 1)
                  {
                     MessageBox.Show("Copy multiple items is under development. Use Windows Explorer instead", "Sorry!");
                     System.Diagnostics.Process.Start("%windir%\\explorer.exe", path);
                  }
                  else
                  {
                     item = listView1.FocusedItem;

                     if (item.SubItems[1].Text == "Folder") //Copy Folder
                     {
                        flagDir = true; //Turn on flagDir
                        itemName = item.Text;
                        sourceDir = item.SubItems[4].Text;
                     }
                     else //Copy File
                     {
                        flagDir = false;
                        itemName = item.Text;
                        sourceFile = item.SubItems[4].Text;
                     }
                     pasteToolStripMenuItem.Enabled = true;
                  }
               }
            }
            else
            {
               if (listView2.Focused) //Copy from listView
               {
                  if (listView2.SelectedItems.Count != 1)
                  {
                     MessageBox.Show("Copy multiple items is under development. Use Windows Explorer instead", "Sorry!");
                     System.Diagnostics.Process.Start(@"C:\Windows\explorer.exe", path2);
                  }
                  else
                  {
                     item = listView2.FocusedItem;

                     if (item.SubItems[1].Text == "Folder") //Copy Folder
                     {
                        flagDir = true; //Turn on flagDir
                        itemName = item.Text;
                        sourceDir = item.SubItems[4].Text;
                     }
                     else //Copy File
                     {
                        flagDir = false;
                        itemName = item.Text;
                        sourceFile = item.SubItems[4].Text;
                     }
                     pasteToolStripMenuItem.Enabled = true;
                  }
               }
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void cutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         flagCopy = false;
         flagMove = true;

         if (flagListView1)
         {
            try
            {
               if (listView1.Focused) //Copy from listView
               {
                  if (listView1.SelectedItems.Count != 1)
                  {
                     MessageBox.Show("Cut multiple items is under development. Use Windows Explorer instead", "Sorry!");
                     System.Diagnostics.Process.Start(@"C:\Windows\explorer.exe", path);
                  }
                  else
                  {
                     item = listView1.FocusedItem;
                     item.ForeColor = Color.LightGray;

                     if (item.SubItems[1].Text.Trim() == "Folder") //Copy Folder
                     {
                        flagDir = true;

                        itemName = item.Text;
                        sourceDir = path + "\\" + itemName;
                     }
                     else //Copy File
                     {
                        flagDir = false;
                        itemName = item.Text;
                        sourceFile = path + "\\" + itemName;
                     }
                     pasteToolStripMenuItem.Enabled = true;
                  }
               }
            }

            catch (Exception ex)
            {
               ShowError(ex);
            }
         }
         else
         {
            try
            {
               if (listView2.Focused) //Copy from listView
               {
                  if (listView2.SelectedItems.Count != 1)
                  {
                     MessageBox.Show("Cut multiple items is under development. Use Windows Explorer instead", "Sorry!");
                     System.Diagnostics.Process.Start(@"C:\Windows\explorer.exe", path);
                  }
                  else
                  {
                     item = listView2.FocusedItem;
                     item.ForeColor = Color.LightGray;

                     if (item.SubItems[1].Text.Trim() == "Folder") //Copy Folder
                     {
                        flagDir = true;

                        itemName = item.Text;
                        sourceDir = path2 + "\\" + itemName;
                     }
                     else //Copy File
                     {
                        flagDir = false;
                        itemName = item.Text;
                        sourceFile = path2 + "\\" + itemName;
                     }
                     pasteToolStripMenuItem.Enabled = true;
                  }
               }
            }
            catch (Exception ex)
            {
               ShowError(ex);
            }
         }
      }

      private void DeleteItem(ListViewItem item, ListView lv)
      {
         try
         {
            string pathItem = item.SubItems[4].Text;
            if (item.SubItems[1].Text == "Folder")
            {
               DirectoryInfo dir = new DirectoryInfo(pathItem);
               if (!dir.Exists) // dir not exist
               {
                  MessageBox.Show("Error: Path not exist", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
               else
               {
                  DialogResult d = MessageBox.Show(
                     "Warning: Are you sure to delete folder" + item.Text.ToString(),
                     "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1);
                  if (d == DialogResult.Yes)
                  {
                     dir.Delete(true);
                  }
                  else
                     return;
                  if (flagListView1)
                  {
                     BrowseFilesAndFolder(dir.Parent, listView1);
                  }
                  else
                  {
                     BrowseFilesAndFolder(dir.Parent, listView2);
                  }
               }
            }
            else
            {
               FileInfo file = new FileInfo(pathItem);
               if (!file.Exists) //file not exist
               {
                  MessageBox.Show("Error: Path not exist", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
               else
               {
                  DialogResult d = MessageBox.Show(
                     "Warning: Are you sure to delete file" + item.Text.ToString(),
                     "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1);
                  if (d == DialogResult.Yes)
                  {
                     file.Delete();
                  }
                  else
                     return;

                  DirectoryInfo browseFile = new DirectoryInfo(address);
                  if (flagListView1)
                  {
                     BrowseFilesAndFolder(browseFile, listView1);
                  }
                  else
                  {
                     BrowseFilesAndFolder(browseFile, listView2);
                  }
               }
            }
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }
      }

      private void DeleteCommand(object sender, EventArgs e, ListView lv)
      {
         try
         {
            if (lv.Focused) //Deleted in listView
            {
               ListViewItem item = new ListViewItem();
               item = lv.FocusedItem;
               DeleteItem(item, lv);
            }
            else // Delete in treeView
            {
               //Code is being build
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
         {
            DeleteCommand(sender, e, listView1);
         }
         else
         {
            DeleteCommand(sender, e, listView2);
         }
      }

      private void createShorcutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //item = listView1.FocusedItem;
         //string name = item.SubItems[0].Text;

         //Shell32.Shell shl = new Shell32.ShellClass();
         //StreamWriter sw = new StreamWriter(address + "\\" + ".lnk", false);
         //sw.Close();

         //Shell32.ShellLinkObject lnk 
      }

      #region for showing properties dialog

      [DllImport("shell32.dll", CharSet = CharSet.Auto)]
      static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
      public struct SHELLEXECUTEINFO
      {
         public int cbSize;
         public uint fMask;
         public IntPtr hwnd;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpVerb;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpFile;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpParameters;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpDirectory;
         public int nShow;
         public IntPtr hInstApp;
         public IntPtr lpIDList;
         [MarshalAs(UnmanagedType.LPTStr)]
         public string lpClass;
         public IntPtr hkeyClass;
         public uint dwHotKey;
         public IntPtr hIcon;
         public IntPtr hProcess;
      }

      private const int SW_SHOW = 5;
      private const uint SEE_MASK_INVOKEIDLIST = 12;

      public static void ShowFileProperties(string Filename)
      {
         SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
         info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
         info.lpVerb = "properties";
         info.lpFile = Filename;
         info.nShow = SW_SHOW;
         info.fMask = SEE_MASK_INVOKEIDLIST;
         ShellExecuteEx(ref info);
      }

      private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ShowFileProperties(item.SubItems[4].Text);
      }

      #endregion

      #endregion

      #region Global Context Menu Tool Strip

      private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if (flagListView1)
               strDestDir = path;
            else
               strDestDir = path2;


            strDest = strDestDir + "\\" + itemName;

            if (flagCopy) //Check if Copy command is executed
            {
               if (flagDir) //Paste Folder
               {
                  FileSystem.CopyDirectory(sourceDir, strDestDir);
               }
               else //Paste File
               {
                  FileSystem.CopyFile(sourceFile, strDest);
               }
            }
            else if (flagMove) //Move Command is executed
            {
               if (flagDir) //Move Dir
               {
                  FileSystem.MoveDirectory(sourceDir, strDest);
                  //Directory.Move(sourceDir, strDest);
               }
               else //Move File
               {
                  FileSystem.MoveFile(sourceFile, strDest);
                  //File.Move(sourceFile, strDest);
               }
            }
            else
            {
               MessageBox.Show("Nothing to Paste", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }

         DirectoryInfo dir = new DirectoryInfo(path);
         BrowseFilesAndFolder(dir, listView1);
         dir = new DirectoryInfo(path2);
         BrowseFilesAndFolder(dir, listView2);

      }

      private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
      {
         flagNewFolder = true;

         ListViewItem item = new ListViewItem();
         item.Text = "New Folder";

         if (flagListView1)
         {
            listView1.LabelEdit = true;

            listView1.Items.Add(item);
         }
         else
         {
            listView2.LabelEdit = true;

            listView2.Items.Add(item);
         }

         //Assign Image for the new Folder
         //item.ImageKey = "folder";

         //Rename Item
         item.BeginEdit();
      }

      private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
            listView1.View = View.LargeIcon;
         else
            listView2.View = View.LargeIcon;
      }

      private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
            listView1.View = View.SmallIcon;
         else
            listView2.View = View.SmallIcon;
      }

      private void listToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
            listView1.View = View.List;
         else
            listView2.View = View.List;
      }

      private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
            listView1.View = View.Details;
         else
            listView2.View = View.Details;
      }

      private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
         {
            listView1.MultiSelect = true;
            foreach (ListViewItem item in listView1.Items)
            {
               item.Selected = true;
            }
         }
         else
         {
            listView2.MultiSelect = true;
            foreach (ListViewItem item in listView2.Items)
            {
               item.Selected = true;
            }
         }
      }

      #endregion

      //These lines of code both use in File Context Menu Tool Strip
      //and Global Context Menu Tool Strip
      private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
      {
         string pathNewFolder = path + "\\" + e.Label;
         DirectoryInfo rootDir = new DirectoryInfo(path);

         if (e.Label == null)
         {
            pathNewFolder = path + "\\New Folder";
         }

         if (flagNewFolder)
         {
            if (!FileSystem.DirectoryExists(pathNewFolder))
            {
               FileSystem.CreateDirectory(pathNewFolder);

               BrowseFilesAndFolder(rootDir, listView1);
               e.CancelEdit = true;
            }
            else
            {
               MessageBox.Show("Folder name " + e.Label + " already existed",
                  "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         else if (flagRename)
         {
            try
            {
               ListViewItem current = listView1.FocusedItem;

               string currentPath = current.SubItems[4].Text;
               if (e.Label == null)
               {
                  return;
               }

               FileInfo fi = new FileInfo(currentPath);
               if (fi.Exists)
               {
                  FileSystem.RenameFile(currentPath, e.Label);

                  DirectoryInfo folder = new DirectoryInfo(fi.DirectoryName);
                  BrowseFilesAndFolder(folder, listView1);
                  e.CancelEdit = true;
               }
               else
               {
                  FileSystem.RenameDirectory(currentPath, e.Label);
                  string parent = FileSystem.GetParentPath(currentPath);

                  DirectoryInfo tempRootDir = new DirectoryInfo(parent);
                  BrowseFilesAndFolder(tempRootDir, listView1);
                  e.CancelEdit = true;
               }
            }
            catch (IOException)
            {
               MessageBox.Show("Folder or File is already existed",
                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
               ShowError(ex);
            }
         }

         flagNewFolder = false;
         flagRename = false;

         if (!directRenameCheckBox.Checked)
         {
            listView1.LabelEdit = false;
         }

      }

      private void listView2_AfterLabelEdit(object sender, LabelEditEventArgs e)
      {
         string pathNewFolder = path + "\\" + e.Label;
         DirectoryInfo rootDir = new DirectoryInfo(path);

         if (e.Label == null)
         {
            pathNewFolder = path + "\\New Folder";
         }

         if (flagNewFolder)
         {
            if (!FileSystem.DirectoryExists(pathNewFolder))
            {
               FileSystem.CreateDirectory(pathNewFolder);

               BrowseFilesAndFolder(rootDir, listView2);
               e.CancelEdit = true;
            }
            else
            {
               MessageBox.Show("Folder name " + e.Label + " already existed",
                  "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         else if (flagRename)
         {
            try
            {
               ListViewItem current = listView2.FocusedItem;

               string currentPath = current.SubItems[4].Text;
               if (e.Label == null)
               {
                  return;
               }

               FileInfo fi = new FileInfo(currentPath);
               if (fi.Exists)
               {
                  FileSystem.RenameFile(currentPath, e.Label);

                  DirectoryInfo folder = new DirectoryInfo(fi.DirectoryName);
                  BrowseFilesAndFolder(folder, listView2);
                  e.CancelEdit = true;
               }
               else
               {
                  FileSystem.RenameDirectory(currentPath, e.Label);
                  string parent = FileSystem.GetParentPath(currentPath);

                  DirectoryInfo tempRootDir = new DirectoryInfo(parent);
                  BrowseFilesAndFolder(tempRootDir, listView2);
                  e.CancelEdit = true;
               }
            }
            catch (IOException)
            {
               MessageBox.Show("Folder or File is already existed",
                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
               ShowError(ex);
            }
         }

         flagNewFolder = false;
         flagRename = false;

         if (!directRenameCheckBox.Checked)
         {
            listView2.LabelEdit = false;
         }
      }
      #endregion

      #region Error and Information MessageBox

      private static void ShowError(Exception ex)
      {
         MessageBox.Show("Error: " + ex.Message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private static void ShowErrorPath()
      {
         MessageBox.Show("Path not exist", "Error Path",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      #endregion

      #region Menu

      #region View Menu

      private void largeIconToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         if (flagListView1)
            listView1.View = View.LargeIcon;
         else
            listView2.View = View.LargeIcon;
      }

      private void detailsToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         if (flagListView1)
            listView1.View = View.List;
         else
            listView2.View = View.List;
      }

      private void detailToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (flagListView1)
            listView1.View = View.Details;
         else
            listView2.View = View.Details;
      }

      private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (statusBarToolStripMenuItem.Checked == true)
         {
            statusBarToolStripMenuItem.Checked = false;
            statusStrip1.Visible = false;
         }
         else
         {
            statusBarToolStripMenuItem.Checked = true;
            statusStrip1.Visible = true;
         }
      }

      private void leftPanelRadioButton_CheckedChanged(object sender, EventArgs e)
      {
         if (leftPanelRadioButton.Checked)
         {
            flagListView1 = true;
            flagListView2 = false;
         }
         else
         {
            flagListView1 = false;
            flagListView2 = true;
         }
      }

      #endregion

      #endregion

   }
}
