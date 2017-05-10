using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explore.GUI
{
    public partial class LockForm : Form
    {
        public delegate void delegateLock(string path, string pass);
        public static delegateLock dlgLock;
        private string path;

        public LockForm(string path)
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtRepassword.UseSystemPasswordChar = true;
            txtPassword.MaxLength = 24;
            txtRepassword.MaxLength = 24;
            this.path = path;
            lbPath.Text = path;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Lock();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Lock()
        {
            if (txtPassword.Text.Length < 6 && txtPassword.Text.Length > 24)
            {
                MessageBox.Show("Password must be between 6 and 24 characters in length");
            }
            else if (txtPassword.Text == txtRepassword.Text)
            {
                dlgLock(path, txtPassword.Text);
                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Password does not match the confirm password");
            }
        }

        private void txtRepassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) Lock();
        }
    }
}
