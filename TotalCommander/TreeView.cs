using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Globalization;

namespace TotalCommander
{
   public partial class Main : Form
   {

      #region Custom Variable of TreeView

      private TreeNode currentSelected;

      #endregion

      #region TreeView

      //This procedure populate the treeView with Drive List
      private void PopulateDriveList()
      {
         TreeNode nodeTreeNode;
         int imageIndex = 0; // Icon when showing node
         int selectIndex = 0; // Icon when node is selected

         //The code below must be in that order (Removable = 2, LocalDisk = 3,...), or it will not work because of wrong index
         const int Removable = 2;
         const int LocalDisk = 3;
         const int Network = 4;
         const int CD = 5;

         // Set cursor to WaitCursor
         this.Cursor = Cursors.WaitCursor;

         // Clear treeView
         treeView.Nodes.Clear();
         // Set first node to "My Computer" node, no child, imageIndex = 10
         nodeTreeNode = new TreeNode("My Computer", 10, 10);
         treeView.Nodes.Add(nodeTreeNode);

         // Set node collection
         TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;

         // Get Drive List
         ManagementObjectCollection querryCollection = getDrives();
         foreach (ManagementObject mo in querryCollection)
         {
            switch(int.Parse(mo["DriveType"].ToString()))
            {
               case Removable:
                  imageIndex = 11;
                  selectIndex = 11;
                  break;
               case LocalDisk:
                  imageIndex = 1;
                  selectIndex = 1;
                  break;
               case CD:
                  imageIndex = 2;
                  selectIndex = 2;
                  break;
               case Network:
                  imageIndex = 4;
                  selectIndex = 4;
                  break;
               default:
                  imageIndex = 5;
                  selectIndex = 12;
                  break;
            }

            // Create new drive node
            nodeTreeNode = new TreeNode(mo["Name"].ToString() + "\\", imageIndex, selectIndex);

            // Add new Node
            nodeCollection.Add(nodeTreeNode);

         }

         //Init files in listView
         InitListView();

         this.Cursor = Cursors.Default;
      }

      protected ManagementObjectCollection getDrives()
      {
         // Get drives
         ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
         ManagementObjectCollection queryCollection = query.Get();

         return queryCollection;
      }

      private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
      {
         //TreeNode nodeCurrent = currentSelected;
         //TreeNode node;


         ////Get dirs 1 more level deep for user to "see" there is more dirs under current dir
         //foreach (TreeNode subNode in nodeCurrent.Nodes)
         //{
         //   string[] stringDirectories = Directory.GetDirectories(GetFullPath(subNode.FullPath));
         //   string stringFullPath = "";
         //   string stringPathName = "";

         //   int imageIndex = 5;
         //   int selectIndex = 12;

         //   //Loop through all directory
         //   foreach (string stringDir in stringDirectories)
         //   {
         //      stringFullPath = stringDir;
         //      stringPathName = GetPathName(stringFullPath);

         //      //Create node for dir
         //      node = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
         //      subNode.Nodes.Add(node);
         //   }

         //this.Cursor = Cursors.WaitCursor;

         ////Populate folder and files when a folder is selected


         ////Get current selected Drive or Folder
         //TreeNode nodeCurrent = e.Node;

         ////Clear all subfolder before use
         //nodeCurrent.Nodes.Clear();

         ////Write data to TreeNode currentSelected for later use in cut, copy and paste command
         //currentSelected = nodeCurrent;

         //if (nodeCurrent.SelectedImageIndex == 10)
         //{
         //   //Selected My Computer, re-populate all list
         //   PopulateDriveList();

         //   path = "My Computer";
         //   //Write data to address variable
         //   address = path;
         //}
         //else
         //{
         //   //Populate sub-folder and files
         //   PopulateDirectory(nodeCurrent, nodeCurrent.Nodes);

         //   //Write data to path
         //   path = GetFullPath(nodeCurrent.FullPath);
         //   path = GetPath(path);

         //   address = path;
         //}

         //this.Cursor = Cursors.Default;

      }

      private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
      {
         this.Cursor = Cursors.WaitCursor;

         //Populate folder and files when a folder is selected


         //Get current selected Drive or Folder
         TreeNode nodeCurrent = e.Node;

         //Clear all subfolder before use
         nodeCurrent.Nodes.Clear();

         //Write data to TreeNode currentSelected for later use in cut, copy and paste command
         currentSelected = nodeCurrent;

         if (nodeCurrent.SelectedImageIndex == 10)
         {
            //Selected My Computer, re-populate all list
            PopulateDriveList();

            path = "My Computer";
            path2 = path;
            //Write data to address variable
            address = path;

            UpdatePath();
         }
         else
         {
            //Populate sub-folder and files
            PopulateDirectory(nodeCurrent, nodeCurrent.Nodes);

            //Write data to path
            if (flagListView1)
            {
               path = GetFullPath(nodeCurrent.FullPath);
               path = GetPath(path);

               UpdatePath();

               address = path;
            }
            else
            {
               path2 = GetFullPath(nodeCurrent.FullPath);
               path2 = GetPath(path2);

               UpdatePath();

               address = path2;
            }
         }

         this.Cursor = Cursors.Default;
      }

      private void PopulateDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection)
      {
         TreeNode nodeDir;
         TreeNode node;

         int imageIndex = 5;
         int selectIndex = 12;

         if (nodeCurrent.SelectedImageIndex != 10)
         {
            //Populate TreeView with folder
            try
            {
               //check path
               if (Directory.Exists(GetFullPath(nodeCurrent.FullPath)) == false)
               {
                  MessageBox.Show("Folder '" + nodeCurrent.ToString() + "' does not exist");
               }
               else
               {
                  //Populate file
                  PopulateFiles(nodeCurrent);

                  string[] stringDirectories = Directory.GetDirectories(GetFullPath(nodeCurrent.FullPath));
                  string stringFullPath = "";
                  string stringPathName = "";

                  //loop through all directory
                  foreach (string stringDir in stringDirectories)
                  {
                     stringFullPath = stringDir;
                     stringPathName = GetPathName(stringFullPath);

                     //Creat node for directory
                     nodeDir = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
                     nodeCurrentCollection.Add(nodeDir);
                  }

                  //Get dirs 1 more level deep for user to "see" there is more dirs under current dir
                  foreach (TreeNode subNode in nodeCurrent.Nodes)
                  {
                     stringDirectories = Directory.GetDirectories(GetFullPath(subNode.FullPath));
                     stringFullPath = "";
                     stringPathName = "";

                     //Loop through all directory
                     foreach (string stringDir in stringDirectories)
                     {
                        stringFullPath = stringDir;
                        stringPathName = GetPathName(stringFullPath);

                        //Create node for dir
                        node = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
                        subNode.Nodes.Add(node);
                     }

                  }
               }
            }
            catch (IOException)
            {
               MessageBox.Show("Error: Drive not ready or directory does not exist.");
            }
            catch (UnauthorizedAccessException)
            {
               //MessageBox.Show("Error: Drive or directory access denided.");
            }
            catch (Exception e)
            {
               MessageBox.Show("Error: " + e);
            }
         }
      }

      private string GetFullPath(string stringPath)
      {
         //Get Full Path
         string stringParse = "";
         //Remove My Computer from path
         stringParse = stringPath.Replace("My Computer\\", "");

         return stringParse;
      }

      private string GetPath(string fullPath)
      {
         char[] arr = { '\\' };
         string path = "";
         string[] nameList = fullPath.Split(arr);
         string nodeName = nameList.GetValue(0).ToString();

         path += nodeName + "\\";
         for (int i = 2; i < nameList.Length; i++)
            path += nameList[i] + "\\";
         return path;
      }

      private string GetPathName(string stringPath)
      {
         //Get Name of Folder
         string[] stringSplit = stringPath.Split('\\');
         int maxIndex = stringSplit.Length;

         return stringSplit[maxIndex - 1];
      }

      protected void InitListView()
      {
         if (flagListView1)
         {
            listView1.Clear(); //clear control
            listView1.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Size", 75, System.Windows.Forms.HorizontalAlignment.Right);
            listView1.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);
         }
         if (flagListView2)
         {
            listView2.Clear(); //clear control
            listView2.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            listView2.Columns.Add("Size", 75, System.Windows.Forms.HorizontalAlignment.Right);
            listView2.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
            listView2.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);
         }
         //init listView Control
      }

      #endregion

   }
}