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
using System.Diagnostics;

namespace Explore
{
    public partial class ShowFile : UserControl
    {
        private Thread t;
        public ShowFile()
        {
            InitializeComponent();
            initLog();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void initLog()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\Windows\\System32\\drivers\\etc\\logFileHide.dat");
                string str;
                while ((str = sr.ReadLine()) != null)
                {                    
                    listBoxFile.Items.Add(str);
                }
                sr.Close();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void saveLog()
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Windows\\System32\\drivers\\etc\\logFileHide.dat");
                for (int i = 0; i < listBoxFile.Items.Count; i++)
                {
                    sw.WriteLine(listBoxFile.Items[i].ToString());
                }
                sw.Close();
            }
            catch (Exception) {
                //throw; 
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] filePath = Directory.GetFiles(fbd.SelectedPath);
                string[] dirPath = Directory.GetDirectories(fbd.SelectedPath);
                string folder = fbd.SelectedPath;

                listBoxFile.Items.Add("************Show File/Folder*************     "+DateTime.Now.ToString());               
                foreach (String path in filePath)
                {
                    try
                    {
                        File.SetAttributes(path, FileAttributes.Normal);
                        listBoxFile.Items.Add(path);
                    }
                    catch (Exception) { }
                }

                foreach (String path in dirPath)
                {
                    try
                    {
                        File.SetAttributes(path, FileAttributes.Normal | FileAttributes.System);
                        listBoxFile.Items.Add(path);
                    }
                    catch (Exception) { }
                }
                listBoxFile.Items.Add("**********************************************************************************************************************");
                listBoxFile.Items.Add("");
                saveLog();
               
                t= new Thread(loadProcessing);
                t.Start();
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] filePath = Directory.GetFiles(fbd.SelectedPath);
                string[] dirPath = Directory.GetDirectories(fbd.SelectedPath);
                string folder = fbd.SelectedPath;

                
                listBoxFile.Items.Add("*************Hide File/Folder*************         "+DateTime.Now.ToString());
                foreach (String path in filePath)
                {
                    try
                    {
                        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                        listBoxFile.Items.Add(path);
                    }
                    catch (Exception e1) { }
                }

                foreach (String path in dirPath)
                {
                    try
                    {
                        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                        listBoxFile.Items.Add(path);
                    }
                    catch (Exception e2) { }
                }
                listBoxFile.Items.Add("**********************************************************************************************************************");
                listBoxFile.Items.Add("");
                saveLog();
                File.SetAttributes(folder, File.GetAttributes(folder) | FileAttributes.Hidden);
                t = new Thread(loadProcessing);
                t.Start();
            }
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

        private void listBoxFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxFile.SelectedIndex;
            Process.Start(listBoxFile.Items[index].ToString());
        }
    }
}
