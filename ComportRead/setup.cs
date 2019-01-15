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

namespace ComportRead
{
    public partial class setup : Form
    {

        String datapath = Path.GetDirectoryName(Application.UserAppDataPath); //設定檔路徑
        String datacfg;  //設定檔

        public setup()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtSplitWord.Text == "") || (txtRemoveStartWord.Text == "") || (txtRemoveEndWord.Text == "") || (txtThreadTime.Text == ""))//若有一項無值時則無法紀錄
            {
                MessageBox.Show("請填寫完整");
            }
            else
            {
                StreamWriter sa = File.CreateText(Path.Combine(this.datapath, "unitech_scaner.cfg"));
                datacfg = txtSplitWord.Text + ";" + txtRemoveStartWord.Text + ";" + txtRemoveEndWord.Text + ";" + txtThreadTime.Text;
                sa.Write(datacfg);
                sa.Flush();
                sa.Close();
                MessageBox.Show("save succesed!!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void setup_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader sa = File.OpenText(Path.Combine(this.datapath, "unitech_scaner.cfg"));
                datacfg = sa.ReadLine();
                String[] newdatacfg = datacfg.Split(';');//將讀出來的字串轉成陣列在塞回去
                txtSplitWord.Text = newdatacfg[0];
                txtRemoveStartWord.Text = newdatacfg[1];
                txtRemoveEndWord.Text = newdatacfg[2];
                txtThreadTime.Text = newdatacfg[3];
                sa.Close();
            }
            catch (Exception EX) { }
        }
    }
}
