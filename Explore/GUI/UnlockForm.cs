using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explore.GUI
{
    public partial class UnlockForm : Form
    {
        public delegate void DelegateUnlock(string path);
        public static DelegateUnlock dlgUnlock;
        private string path;
        public UnlockForm(string path)
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            this.path = path;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Unlock();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void Unlock()
        {
            try
            {
                StreamReader sr = new StreamReader(path + "\\password.dat");
                string password = sr.ReadLine();
                sr.Close();
                if (password == txtPassword.Text)
                {
                    File.Delete(path + "\\password.dat");
                    dlgUnlock(path);
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Password wrong");
                }
            }catch(Exception e) { }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Unlock();
            }
        }
    }
}
