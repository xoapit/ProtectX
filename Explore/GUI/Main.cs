using Explore.GUI;
using Microsoft.Win32;
using ProtectX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Explore
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            loadFirst();
            loadInfoOS();
        }       

        private void loadInfoOS()
        {          
            var oss = new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get().Cast<ManagementObject>()
     .First();
            string OS = "";
            OS+= ((string)oss["Caption"]).Trim();
            OS+=" " + (string)oss["OSArchitecture"];           
            OS+=" (Build "+ ((string)oss["BuildNumber"])+")";
            lbOS.Text = OS.ToString();

            var cpu = new ManagementObjectSearcher("select * from Win32_Processor").Get().Cast<ManagementObject>()
    .First();
            string CPU = (string)cpu["Name"];

            var ram = new ManagementObjectSearcher("select * from Win32_PhysicalMemory").Get().Cast<ManagementObject>()
   .First();
            String ramValue = Convert.ToString(String.Format("{0:0.00}", (Double)(((UInt64)ram["Capacity"]))/(1024*1024*1024)));
           
            lbCPU.Text = CPU +" RAM: "+ ramValue.ToString()+" GB";
        }

        private void loadFirst()
        {
            UserControl usc = new HideDrive();
            panel1.Controls.Clear();
            usc.Dock = DockStyle.Fill;
            panel1.Controls.Add(usc);
            setColorButton(1);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            UserControl usc = new LockFolder();
            panel1.Controls.Clear();
            usc.Dock = DockStyle.Fill;
            panel1.Controls.Add(usc);
            setColorButton(2);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            UserControl usc = new ShowFile();
            panel1.Controls.Clear();
            usc.Dock = DockStyle.Fill;
            panel1.Controls.Add(usc);
            setColorButton(3);
        }

        private void btnDrive_Click(object sender, EventArgs e)
        {
            UserControl usc = new HideDrive();
            panel1.Controls.Clear();
            usc.Dock = DockStyle.Fill;
            panel1.Controls.Add(usc);
            setColorButton(1);            
        }

        private void setColorButton(int i)
        {
            btnDrive.BackColor = System.Drawing.Color.Transparent;
            btnFile.BackColor = System.Drawing.Color.Transparent;
            btnFolder.BackColor = System.Drawing.Color.Transparent;
            btnSetting.BackColor = System.Drawing.Color.Transparent;
            if (i==1)
                btnDrive.BackColor = System.Drawing.Color.FromArgb(0x39, 0x78, 0xd9);
            else if(i==2)
                btnFolder.BackColor = System.Drawing.Color.FromArgb(0x39, 0x78, 0xd9);
            else if(i==3)
                btnFile.BackColor = System.Drawing.Color.FromArgb(0x39, 0x78, 0xd9);
            else
                btnSetting.BackColor = System.Drawing.Color.FromArgb(0x39, 0x78, 0xd9);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            UserControl usc = new Setting();
            panel1.Controls.Clear();
            usc.Dock = DockStyle.Fill;
            panel1.Controls.Add(usc);
            setColorButton(1);
            setColorButton(4);
        }
    }
}
