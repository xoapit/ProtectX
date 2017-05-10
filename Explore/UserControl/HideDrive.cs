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
using HardwareInfo;
using System.Threading;
using System.Collections;

namespace Explore.GUI
{
    public partial class HideDrive : UserControl
    {
        private Thread t;
        private Hashtable hashtable = new Hashtable();
        public HideDrive()
        {
            InitializeComponent();
            initHashtableDrive();
            Control.CheckForIllegalCrossThreadCalls = false;
            loadLogicalDrive();
            LoadDataDrive();
            ConvertValueToGB();
            initLog();
        }

        private void initHashtableDrive()
        {
            hashtable.Add("A", "1");
            hashtable.Add("B", "2");
            hashtable.Add("C", "4");
            hashtable.Add("D", "8");
            hashtable.Add("E", "10");
            hashtable.Add("F", "20");
            hashtable.Add("G", "40");
            hashtable.Add("H", "80");
            hashtable.Add("I", "100");
            hashtable.Add("J", "200");
            hashtable.Add("K", "400");
            hashtable.Add("L", "8000");
            hashtable.Add("M", "1000");
            hashtable.Add("N", "2000");
            hashtable.Add("O", "4000");
            hashtable.Add("P", "8000");
            hashtable.Add("Q", "10000");
            hashtable.Add("R", "20000");
            hashtable.Add("S", "40000");
            hashtable.Add("T", "80000");
            hashtable.Add("U", "100000");
            hashtable.Add("V", "200000");
            hashtable.Add("W", "400000");
            hashtable.Add("X", "800000");
            hashtable.Add("Y", "1000000");
            hashtable.Add("Z", "2000000");
            hashtable.Add("All Drive", "3ffffff");
        }

        private void initLog()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\Windows\\System32\\drivers\\etc\\logHideDrive.dat");
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    listBoxLog.Items.Add(str);
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
                StreamWriter sw = new StreamWriter("C:\\Windows\\System32\\drivers\\etc\\logHideDrive.dat");
                for (int i = 0; i < listBoxLog.Items.Count; i++)
                {
                    sw.WriteLine(listBoxLog.Items[i].ToString());
                }
                sw.Close();
            }
            catch (Exception)
            {
                //throw; 
            }
        }

        private Int32 getValueDrive()
        {
            string str="0";
            try
            {
                StreamReader sr = new StreamReader("C:\\Windows\\System32\\drivers\\etc\\valueDrive.dat");
                
                while ((str = sr.ReadLine()) != null)
                {
                    sr.Close();           
                    return Int32.Parse(str);
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void setValueDrive(Int32 value)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Windows\\System32\\drivers\\etc\\valueDrive.dat");
                sw.WriteLine(value.ToString());
                sw.Close();
                
            }
            catch (Exception)
            {
                
            }
        }

        private void btnHideDrive_Click(object sender, EventArgs e)
        {
            try
            {                        
                string drive = comboBoxDrive.Text;
                if (drive.Equals(""))
                {
                    MessageBox.Show("Please choose a drive!");
                    return;
                }
                string nodrives = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";

                String value = (String)hashtable[drive];
                Int32 oldValue = getValueDrive();

                Int32 valueSetup = 0;
                if (value.Equals("3ffffff"))
                {
                    valueSetup = Convert.ToInt32(value, 16);
                }else
                {
                    valueSetup = Convert.ToInt32(value, 16) + oldValue;
                }

                RegistryKey rKey = Registry.CurrentUser.CreateSubKey(nodrives);
                rKey.SetValue("NoDrives", valueSetup, RegistryValueKind.DWord);
                rKey.Close();
                
                setValueDrive(valueSetup);

                listBoxLog.Items.Add("Drive " + comboBoxDrive.Text + ":\\ Hiden");
                listBoxLog.Items.Add("On " + DateTime.Now.ToString());
                listBoxLog.Items.Add("");

                saveLog();
                t = new Thread(loadProcessing);
                t.Start();
                reStart();
            }catch(Exception ee) { }
        }

        private void btnUnhideDrive_Click(object sender, EventArgs e)
        {
            try
            {
                string drive = comboBoxDrive.Text;
                if (drive.Equals(""))
                {
                    MessageBox.Show("Please choose a drive!");
                    return;
                }
                string nodrives = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";

                String value = (String)hashtable[drive];
                Int32 oldValue = getValueDrive();

                RegistryKey rKey = Registry.CurrentUser.CreateSubKey(nodrives);

                Int32 valueSetup = 0;
                if (value.Equals("3ffffff"))
                {
                    valueSetup = 0;                    
                }
                else
                {
                    valueSetup = oldValue - Convert.ToInt32(value, 16);
                }
                rKey.SetValue("NoDrives", valueSetup, RegistryValueKind.DWord);
                rKey.Close();
                setValueDrive(valueSetup);

                listBoxLog.Items.Add(drive+": Unhiden");    
                listBoxLog.Items.Add("On " + DateTime.Now.ToString());
                listBoxLog.Items.Add("");
               
                saveLog();
                

                t = new Thread(loadProcessing);
                t.Start();
                reStart();
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.Message);
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

        private void reStart()
        {
            Process process = new Process();
            foreach (System.Diagnostics.Process exe in System.Diagnostics.Process.GetProcesses())
            {
                if (exe.ProcessName == "explorer")
                    exe.Kill();
            }
        }

        private void loadLogicalDrive()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                comboBoxDrive.Items.Add(drive.Name.Substring(0, 1));
            }
            comboBoxDrive.Items.Add("All Drive");
        }

        private int NumOfDisk = 0;
        private DiskInfo[] driveInfos;


        private void LoadDataDrive()
        {
            try
            {
                NumOfDisk = DriveInfo.GetDrives().Count();
                driveInfos = new DiskInfo[NumOfDisk];
                int i = 0;
                foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                {                    
                    driveInfos[i] = new DiskInfo();
                    try
                    {
                        driveInfos[i].Drive = driveInfo.Name;                                  
                        driveInfos[i].MediaType = driveInfo.DriveFormat.ToString();
                        driveInfos[i].Capacity = driveInfo.TotalSize.ToString();
                        driveInfos[i].FreeSpace = driveInfo.TotalFreeSpace.ToString();
                        driveInfos[i].Used = (driveInfo.TotalSize - driveInfo.TotalFreeSpace).ToString();
                        driveInfos[i].Used = "No";
                        if (driveInfo.IsReady)                        
                            driveInfos[i].Status = "Ready";                      
                        else                        
                            driveInfos[i].Status = "Not Ready";                        
                    }
                    catch
                    {
                        driveInfos[i].MediaType = "No";                       
                        driveInfos[i].Capacity = "No";
                        driveInfos[i].FreeSpace = "No";
                        driveInfos[i].Used = "No";
                        driveInfos[i].Status = "Not Ready";
                    }
                    i++;                   
                }
            }
            catch
            {
                //throw;
            }

            dataGridViewDrive.DataSource = driveInfos;            
        }


        public void ConvertValueToGB()
        {
            for (int i = 0; i < dataGridViewDrive.Rows.Count; i++)
            {
                try
                {
                    if (!dataGridViewDrive.Rows[i].Cells["Status"].Value.ToString().Equals("Not Ready"))

                    {
                        Double capacityGB = 0, freeSpaceGB = 0;
                        UInt64 capacityByte = 0, freeSpaceByte = 0;

                        capacityByte = Convert.ToUInt64(dataGridViewDrive.Rows[i].Cells["Capacity"].Value.ToString());
                        capacityGB = (Double)capacityByte / (1024 * 1024 * 1024);
                        capacityGB = Convert.ToDouble(String.Format("{0:0.#}", capacityGB));
                        dataGridViewDrive.Rows[i].Cells["Capacity"].Value = Convert.ToString(capacityGB) + " GB";

                        freeSpaceByte = Convert.ToUInt64(dataGridViewDrive.Rows[i].Cells["FreeSpace"].Value.ToString());
                        freeSpaceGB = (Double)freeSpaceByte / (1024 * 1024 * 1024);
                        freeSpaceGB = Convert.ToDouble(String.Format("{0:0.#}", freeSpaceGB));
                        dataGridViewDrive.Rows[i].Cells["FreeSpace"].Value = Convert.ToString(freeSpaceGB) + " GB (" + (int)(freeSpaceGB * 100 / capacityGB) + "%)";
                        dataGridViewDrive.Rows[i].Cells["Used"].Value = Convert.ToString(capacityGB - freeSpaceGB) + " GB (" + (100 - (int)(freeSpaceGB * 100 / capacityGB)) + "%)";
                    };
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }

        private void dataGridViewDrive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dataGridViewDrive.CurrentRow.Index;
            comboBoxDrive.Text = dataGridViewDrive.Rows[currentRow].Cells["Drive"].Value.ToString().Substring(0, 1);
        }
    }
}
