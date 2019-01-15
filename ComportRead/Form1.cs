using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComportRead
{
    public partial class Form1 : Form
    {
        String datapath = Path.GetDirectoryName(Application.UserAppDataPath); //設定檔路徑
        String datacfg;  //設定檔
        string[] ports = SerialPort.GetPortNames();
        setup f2 = new setup();
        string SplitWord;
        Int32 RemoveStartWord;
        Int32 RemoveEndWord;
        Int32 ThreadTime;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = true;
            this.Text = "Unitech Scaner v" + "1.0.5";
#if DEBUG
            this.Text = this.Text + "(D)";
#endif
            this.ResumeLayout(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string port in ports)
            {
                ComportName.Items.Add(port);
            }

            SplitWord = "\u001d";
            RemoveStartWord = 0;
            RemoveEndWord = 2;
            ThreadTime = 30;

        }

        private void loadconfig()
        {
            try
            {
                StreamReader sa = File.OpenText(Path.Combine(this.datapath, "unitech_scaner.cfg"));
                datacfg = sa.ReadLine();
                String[] newdatacfg = datacfg.Split(';');//將讀出來的字串轉成陣列在塞回去
                sa.Close();
                SplitWord = newdatacfg[0];
                RemoveStartWord = Convert.ToInt32(newdatacfg[1]);
                RemoveEndWord = Convert.ToInt32(newdatacfg[2]);
                ThreadTime = Convert.ToInt32(newdatacfg[3]);
            }
            catch (Exception ex) { }
        }

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(ThreadTime);
            if (this.serialPort1.BytesToRead > 0)
            {
                string data = serialPort1.ReadExisting();
                BeginInvoke((Action)delegate { CopyPaste(data); });
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            loadconfig();

            if (ComportName.SelectedItem != null)
            {
                if (radNormal.Checked == false && radSpecialCaptrue.Checked == false)
                {
                    MessageBox.Show("請選擇Scan Mode");
                }
                else
                {
                    serialPort1.PortName = ComportName.SelectedItem.ToString();
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open();
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(_port_DataReceived);

                    if (serialPort1.IsOpen)
                    {
                        btnConnect.Enabled = false;
                        btnSetup.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("請選擇連線comport");
            }
        }

        private void CopyPaste(string data)
        {
            if (radSpecialCaptrue.Checked)
            {
                try
                {
                    string[] dataselect = new string[20];
                    dataselect = Regex.Split(data, SplitWord);
                    string datadelete = dataselect[7].Remove(RemoveStartWord, RemoveEndWord).TrimEnd();

                    if (checkBoxEnter.Checked)
                    {
                        KBsimulation(datadelete, "{ENTER}");
                    }
                    else if (chktab.Checked)
                    {
                        KBsimulation(datadelete, "{TAB}");
                    }
                }
                catch (TimeoutException) { return; }
                catch (InvalidOperationException) { return; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
  
                }
            else if (radNormal.Checked)
            {
                if (checkBoxEnter.Checked)
                {
                    KBsimulation(data, "{ENTER}");
                }
                else if (chktab.Checked)
                {
                    KBsimulation(data, "{TAB}");
                }            
            }
        }

        private void KBsimulation(string InputData,string inputkey)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                txtLabel.AppendText(InputData);
            }
            else
            {
                Clipboard.SetDataObject(InputData, true);
                keybd_event(0x11, 0, 0, 0);
                keybd_event(0x56, 0, 0, 0);
                keybd_event(0x56, 0, 2, 0);
                keybd_event(0x11, 0, 2, 0);

                Thread.Sleep(50);

                SendKeys.Send(inputkey);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show(this, "Are you sure to exit?", "UWedge", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (serialPort1 != null) serialPort1.Close();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            f2.Show();
        }

        #region DataChange
        private string ReadCString(Encoding encoding, byte[] cString)
        {
            var nullIndex = Array.IndexOf(cString, (byte)0);
            nullIndex = (nullIndex == -1) ? cString.Length : nullIndex;
            return encoding.GetString(cString, 0, nullIndex);
        }

        private byte[] StringToByteArray(string hexString)
        {
            hexString = hexString.Replace("\r", "");
            hexString = hexString.Replace("\n", "");
            int nBytes = (hexString.Length) / 2;
            byte[] buffer = new byte[nBytes];
            for (int i = 0; i < nBytes; i++)
            {
                buffer[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return buffer;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        #endregion


    }


}
