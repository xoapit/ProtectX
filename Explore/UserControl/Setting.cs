using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ProtectX
{
    public partial class Setting : UserControl
    {
        private Thread t;
        public Setting()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            lbComputer.Text= System.Environment.MachineName.ToString();
        }

        private void btnClearDrive_Click(object sender, EventArgs e)
        {
            File.Delete(@"C:\\Windows\\System32\\drivers\\etc\\logHideDrive.dat");
            t = new Thread(loadProcessing);
            t.Start();
        }

        private void btnClearLock_Click(object sender, EventArgs e)
        {
            File.Delete(@"C:\\Windows\\System32\\drivers\\etc\\listFolder.dat");
            t = new Thread(loadProcessing);
            t.Start();
        }

        private void btnClearShow_Click(object sender, EventArgs e)
        {
            File.Delete(@"C:\\Windows\\System32\\drivers\\etc\\logFileHide.dat");
            t = new Thread(loadProcessing);
            t.Start();
        }

        private void loadProcessing()
        {
            for (int i = 10; i <= 100; i += 10)
            {
                progressBar.Value = i;
                Thread.Sleep(100);
                lbPhanTram.Text = i.ToString() + "%";
            }
            t.Abort();
        }
    }
}
