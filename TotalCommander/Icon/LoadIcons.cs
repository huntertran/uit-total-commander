using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TotalCommander.IconMethod
{
   class LoadIcons
   {

      private const int SHGFI_ICON = 0x100;
      private const int SHGFI_SMALLICON = 0x1;
      private const int SHGFI_LARGEICON = 0x0;

      Icon myIcon;

      PictureBox temp1;
      PictureBox temp2;

      // This structure will contain information about the file
      public struct SHFILEINFO
      {
         // Handle to the icon representing the file
         public IntPtr hIcon;
         // Index of the icon within the image list
         public int iIcon;
         // Various attributes of the file
         public uint dwAttributes;
         // Path to the file
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
         public string szDisplayName;
         // File type
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
         public string szTypeName;
      };

      // The signature of SHGetFileInfo (located in Shell32.dll)
      [DllImport("Shell32.dll")]
      public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);

      public void LoadAllIcon(string FileName)
      {

         // Will store a handle to the small icon
         IntPtr hImgSmall;
         // Will store a handle to the large icon
         IntPtr hImgLarge;

         SHFILEINFO shinfo = new SHFILEINFO();

         // Get a handle to the small icon
         hImgSmall = SHGetFileInfo(FileName, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
         // Get the small icon from the handle
         myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
         // Display the small icon
         temp1.Image = myIcon.ToBitmap();

         // Get a handle to the large icon
         hImgLarge = SHGetFileInfo(FileName, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
         // Get the large icon from the handle
         myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
         // Display the large icon
         temp2.Image = myIcon.ToBitmap();
      }
   }
}
