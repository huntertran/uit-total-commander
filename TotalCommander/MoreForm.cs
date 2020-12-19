using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TotalCommander
{
   public partial class MoreForm : Form
   {
      public MoreForm()
      {
         InitializeComponent();
      }

      private void uacButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\UserAccountControlSettings.exe");
      }

      private void actionCenterButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\wscui.cpl");
      }

      private void winTBSButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\control.exe", "/name Microsoft.Troubleshooting");
      }

      private void computerManagementButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\compmgmt.msc");
      }

      private void sysInfoButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\msinfo32.exe");
      }

      private void programButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\appwiz.cpl");
      }

      private void systemPropertiesButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\control.exe", "system");
      }

      private void internetOptionButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\inetcpl.cpl");
      }

      private void resourcesMonitorButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\resmon.exe");
      }

      private void regEditButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\regedt32.exe");
      }

      private void eventViewerButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\eventvwr.exe");
      }

      private void systemRestoreButton_Click(object sender, EventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Windows\System32\rstrui.exe");
      }
   }
}
