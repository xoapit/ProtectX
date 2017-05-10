using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using ProtectX.DTO;
using System.Threading;

namespace Explore.GUI
{
    public partial class LockFolder : UserControl
    {
        private Thread t;
        private List<Folder> listFolder = new List<Folder>();
        public LockFolder()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            initLog();
        }

        private void initLog()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\Windows\\System32\\drivers\\etc\\listFolder.dat");
                string str;
                while((str=sr.ReadLine())!=null)
                {                   
                    string[] arr = str.Split('*');
                    listFolder.Add(new Folder(arr[0], arr[1], arr[2], arr[3]));
                }
                sr.Close();
                dataGridViewFolder.DataSource = listFolder.ToList();

                if (dataGridViewFolder.Rows.Count > 0)
                {                    
                    setFolderInfo(0);
                }
            }
            catch (Exception) { };
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

        private void reStart()
        {
            Process process = new Process();
            foreach (System.Diagnostics.Process exe in System.Diagnostics.Process.GetProcesses())
            {
                if (exe.ProcessName == "explorer")
                    exe.Kill();
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            //register delegate to lockFolder mothod called when LockForm set password successfully
            LockForm.dlgLock = new LockForm.delegateLock(lockFolder);

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                
                //check password file in that folder
                if (System.IO.Directory.Exists(path + "\\password.dat") == false)
                {
                    LockForm lockForm = new LockForm(path);
                    lockForm.Show();
                }
                else
                {
                    MessageBox.Show("Folder is locked");
                }                  
            }
        }

        private void saveLog()
        {
            StreamWriter sw = new StreamWriter("C:\\Windows\\System32\\drivers\\etc\\listFolder.dat");
            for (int i = 0; i < listFolder.Count; i++)
            {
                Folder f = listFolder.ElementAt(i);
                sw.WriteLine(f.Name + "*" + f.Url + "*" + f.Time + "*" + f.Status);
            }
            sw.Close();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                //register delegate to unlockFolder mothod called when UnlockForm set password successfully
                UnlockForm.dlgUnlock = new UnlockForm.DelegateUnlock(unlockFolder);

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = fbd.SelectedPath;
                    UnlockForm lockForm = new UnlockForm(path);
                    lockForm.Show();
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void lockFolder(string folderPath, string pass)
        {
            try
            {
                //set password for folder                
                StreamWriter sw = new StreamWriter(folderPath + "\\password.dat");
                sw.WriteLine(pass);
                sw.Close();
                
                DirectoryInfo myDirectoryInfo = new DirectoryInfo(folderPath);
                var iduser = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
                DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                FileSystemAccessRule fsar = new FileSystemAccessRule(iduser, FileSystemRights.Read, AccessControlType.Deny);
                myDirectorySecurity.AddAccessRule(fsar);
                myDirectoryInfo.SetAccessControl(myDirectorySecurity);

                //process saving file log
                Folder folder = new Folder(new DirectoryInfo(folderPath).Name, folderPath, DateTime.Now.ToString(), "Lock");
                listFolder.Add(folder);
                dataGridViewFolder.DataSource = listFolder.ToList();
                saveLog();

                t = new Thread(loadProcessing);
                t.Start();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void unlockFolder(string folderPath)
        {
            try
            {
                DirectoryInfo myDirectoryInfo = new DirectoryInfo(folderPath);
                var iduser = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
                DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                FileSystemAccessRule fsar = new FileSystemAccessRule(iduser, FileSystemRights.Read, AccessControlType.Deny);
                myDirectorySecurity.RemoveAccessRule(fsar);
                myDirectoryInfo.SetAccessControl(myDirectorySecurity);
               
                Folder folder = new Folder(new DirectoryInfo(folderPath).Name, folderPath, DateTime.Now.ToString(), "Unlock");
                listFolder.Add(folder);
                dataGridViewFolder.DataSource = listFolder.ToList();
                saveLog();

                t = new Thread(loadProcessing);
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewFolder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dataGridViewFolder.CurrentRow.Index;   
            setFolderInfo(currentRow);
        }

        private void dataGridViewFolder_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRow = dataGridViewFolder.CurrentRow.Index;
            string path = dataGridViewFolder.Rows[currentRow].Cells[1].Value.ToString();
            Process.Start(path);
        }

        private void setFolderInfo(int currentRow)
        {
            Folder f = new Folder(dataGridViewFolder.Rows[currentRow].Cells[0].Value.ToString(),
                dataGridViewFolder.Rows[currentRow].Cells[1].Value.ToString(),
                dataGridViewFolder.Rows[currentRow].Cells[2].Value.ToString(),
                dataGridViewFolder.Rows[currentRow].Cells[3].Value.ToString());
            lbName.Text = f.Name;
            lbUrl.Text = f.Url;
            lbTime.Text = f.Time;
            lbStatus.Text = f.Status;
        }
    }
}
