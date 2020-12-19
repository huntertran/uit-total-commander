using System;
using System.Windows.Forms;

namespace zip1
{
    public partial class SetPassWord : Form
    {
        public static string strPassword;
        public SetPassWord()
        {
           InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
           if (tbPassword.Text != tbConfirmPassword.Text)
           {
              MessageBox.Show("Recheck your Password", "Incorect password", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
              strPassword = tbConfirmPassword.Text;
              this.Close();
           }
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
           if (tbPassword.Text != tbConfirmPassword.Text)
           {
              noteLabel.Text = "Note: Incorrect Password. Please check!";
           }
           else
           {
              noteLabel.Text = "Note: Password Correct";
           }
        }
    }
}
