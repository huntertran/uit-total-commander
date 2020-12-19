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
   public partial class ContactMeForm : Form
   {
      public ContactMeForm()
      {
         InitializeComponent();
      }

      private void tuanFacebookTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "http://www.facebook.com/cuoilennaocacban");
      }

      private void duyenFacebookTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "https://www.facebook.com/profile.php?id=100001868603792");
      }
   }
}
