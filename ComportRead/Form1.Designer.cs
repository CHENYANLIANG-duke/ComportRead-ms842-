namespace ComportRead
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.ComportName = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBoxEnter = new System.Windows.Forms.CheckBox();
            this.labcomchoice = new System.Windows.Forms.Label();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.radSpecialCaptrue = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetup = new System.Windows.Forms.Button();
            this.chktab = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(314, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 64);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "連線";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(12, 98);
            this.txtLabel.Multiline = true;
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(398, 143);
            this.txtLabel.TabIndex = 1;
            // 
            // ComportName
            // 
            this.ComportName.FormattingEnabled = true;
            this.ComportName.Location = new System.Drawing.Point(84, 8);
            this.ComportName.Name = "ComportName";
            this.ComportName.Size = new System.Drawing.Size(121, 20);
            this.ComportName.TabIndex = 2;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "2D Scaner";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // checkBoxEnter
            // 
            this.checkBoxEnter.AutoSize = true;
            this.checkBoxEnter.Location = new System.Drawing.Point(141, 33);
            this.checkBoxEnter.Name = "checkBoxEnter";
            this.checkBoxEnter.Size = new System.Drawing.Size(73, 16);
            this.checkBoxEnter.TabIndex = 3;
            this.checkBoxEnter.Text = "後帶Enter";
            this.checkBoxEnter.UseVisualStyleBackColor = true;
            // 
            // labcomchoice
            // 
            this.labcomchoice.AutoSize = true;
            this.labcomchoice.Font = new System.Drawing.Font("標楷體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labcomchoice.Location = new System.Drawing.Point(9, 9);
            this.labcomchoice.Name = "labcomchoice";
            this.labcomchoice.Size = new System.Drawing.Size(79, 15);
            this.labcomchoice.TabIndex = 4;
            this.labcomchoice.Text = "選擇COM :";
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Location = new System.Drawing.Point(6, 21);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(58, 16);
            this.radNormal.TabIndex = 5;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "Normal";
            this.radNormal.UseVisualStyleBackColor = true;
            // 
            // radSpecialCaptrue
            // 
            this.radSpecialCaptrue.AutoSize = true;
            this.radSpecialCaptrue.Location = new System.Drawing.Point(87, 21);
            this.radSpecialCaptrue.Name = "radSpecialCaptrue";
            this.radSpecialCaptrue.Size = new System.Drawing.Size(93, 16);
            this.radSpecialCaptrue.TabIndex = 6;
            this.radSpecialCaptrue.TabStop = true;
            this.radSpecialCaptrue.Text = "Special capture";
            this.radSpecialCaptrue.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNormal);
            this.groupBox1.Controls.Add(this.radSpecialCaptrue);
            this.groupBox1.Location = new System.Drawing.Point(7, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 45);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Mode";
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(233, 12);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(75, 64);
            this.btnSetup.TabIndex = 8;
            this.btnSetup.Text = "設定";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // chktab
            // 
            this.chktab.AutoSize = true;
            this.chktab.Location = new System.Drawing.Point(76, 33);
            this.chktab.Name = "chktab";
            this.chktab.Size = new System.Drawing.Size(62, 16);
            this.chktab.TabIndex = 9;
            this.chktab.Text = "後帶tab";
            this.chktab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(418, 251);
            this.Controls.Add(this.chktab);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labcomchoice);
            this.Controls.Add(this.checkBoxEnter);
            this.Controls.Add(this.ComportName);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.ComboBox ComportName;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox checkBoxEnter;
        private System.Windows.Forms.Label labcomchoice;
        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.RadioButton radSpecialCaptrue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.CheckBox chktab;
    }
}

