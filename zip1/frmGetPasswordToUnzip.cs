using System;
using System.Windows.Forms;

namespace zip1
{
    public partial class frmGetPasswordToUnzip : Form
    {
        public frmGetPasswordToUnzip()
        {
            InitializeComponent();
        }

        private void btGetPasswordToUnzip_Click(object sender, EventArgs e)
        {
           frmUnZip.strGetPasswordToUnzip = tbGetPasswordToUnzip.Text;
           this.Close();
        }
    }
}