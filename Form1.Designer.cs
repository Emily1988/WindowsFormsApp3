namespace WindowsFormsApp3
{
    partial class Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.portname = new System.Windows.Forms.Label();
            this.baudrate = new System.Windows.Forms.Label();
            this.cbpn = new System.Windows.Forms.ComboBox();
            this.cbbd = new System.Windows.Forms.ComboBox();
            this.btopen = new System.Windows.Forms.Button();
            this.btreset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btsend = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chinrb = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chrerb = new System.Windows.Forms.RadioButton();
            this.butds = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.bcbt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // portname
            // 
            this.portname.AutoSize = true;
            this.portname.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portname.Image = ((System.Drawing.Image)(resources.GetObject("portname.Image")));
            this.portname.Location = new System.Drawing.Point(23, 24);
            this.portname.Name = "portname";
            this.portname.Size = new System.Drawing.Size(69, 19);
            this.portname.TabIndex = 0;
            this.portname.Text = "端口名";
            // 
            // baudrate
            // 
            this.baudrate.AutoSize = true;
            this.baudrate.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baudrate.Image = ((System.Drawing.Image)(resources.GetObject("baudrate.Image")));
            this.baudrate.Location = new System.Drawing.Point(279, 23);
            this.baudrate.Name = "baudrate";
            this.baudrate.Size = new System.Drawing.Size(69, 19);
            this.baudrate.TabIndex = 1;
            this.baudrate.Text = "波特率";
            // 
            // cbpn
            // 
            this.cbpn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbpn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbpn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbpn.FormattingEnabled = true;
            this.cbpn.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cbpn.Location = new System.Drawing.Point(103, 19);
            this.cbpn.Name = "cbpn";
            this.cbpn.Size = new System.Drawing.Size(121, 23);
            this.cbpn.TabIndex = 2;
            this.cbpn.SelectedIndexChanged += new System.EventHandler(this.cbpn_SelectedIndexChanged);
            // 
            // cbbd
            // 
            this.cbbd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbd.FormattingEnabled = true;
            this.cbbd.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbbd.Location = new System.Drawing.Point(349, 19);
            this.cbbd.Name = "cbbd";
            this.cbbd.Size = new System.Drawing.Size(121, 23);
            this.cbbd.TabIndex = 3;
            // 
            // btopen
            // 
            this.btopen.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btopen.Location = new System.Drawing.Point(572, 12);
            this.btopen.Name = "btopen";
            this.btopen.Size = new System.Drawing.Size(118, 30);
            this.btopen.TabIndex = 4;
            this.btopen.Text = "打开串口";
            this.btopen.UseVisualStyleBackColor = true;
            this.btopen.Click += new System.EventHandler(this.btopen_Click);
            // 
            // btreset
            // 
            this.btreset.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btreset.Location = new System.Drawing.Point(572, 48);
            this.btreset.Name = "btreset";
            this.btreset.Size = new System.Drawing.Size(119, 31);
            this.btreset.TabIndex = 5;
            this.btreset.Text = "清除接收";
            this.btreset.UseVisualStyleBackColor = true;
            this.btreset.Click += new System.EventHandler(this.btreset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(572, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "接收字节数：0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 158);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(695, 120);
            this.textBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(70, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "发送模式";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(568, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "发送字节数：0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 337);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(549, 72);
            this.textBox2.TabIndex = 15;
            // 
            // btsend
            // 
            this.btsend.Enabled = false;
            this.btsend.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btsend.Location = new System.Drawing.Point(571, 306);
            this.btsend.Name = "btsend";
            this.btsend.Size = new System.Drawing.Size(134, 25);
            this.btsend.TabIndex = 16;
            this.btsend.Text = "发送数据";
            this.btsend.UseVisualStyleBackColor = true;
            this.btsend.Click += new System.EventHandler(this.btsend_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton1.BackgroundImage")));
            this.radioButton1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(38, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 23);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "字符";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton2.BackgroundImage")));
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(133, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 23);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "数值";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(70, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "接收模式";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBox2.Location = new System.Drawing.Point(349, 61);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(280, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "数据位";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "8"});
            this.comboBox3.Location = new System.Drawing.Point(103, 56);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.cbbd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.baudrate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbpn);
            this.groupBox1.Controls.Add(this.portname);
            this.groupBox1.Location = new System.Drawing.Point(31, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 90);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.chinrb);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Location = new System.Drawing.Point(185, 284);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 34);
            this.panel1.TabIndex = 25;
            // 
            // chinrb
            // 
            this.chinrb.AutoSize = true;
            this.chinrb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chinrb.BackgroundImage")));
            this.chinrb.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chinrb.Location = new System.Drawing.Point(221, 9);
            this.chinrb.Name = "chinrb";
            this.chinrb.Size = new System.Drawing.Size(70, 23);
            this.chinrb.TabIndex = 2;
            this.chinrb.TabStop = true;
            this.chinrb.Text = "中文";
            this.chinrb.UseVisualStyleBackColor = true;
            this.chinrb.CheckedChanged += new System.EventHandler(this.chinrb_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton4.BackgroundImage")));
            this.radioButton4.Checked = true;
            this.radioButton4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton4.Location = new System.Drawing.Point(133, 9);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(70, 23);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "数值";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton3.BackgroundImage")));
            this.radioButton3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(38, 8);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 23);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "字符";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.chrerb);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Location = new System.Drawing.Point(185, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 34);
            this.panel2.TabIndex = 26;
            // 
            // chrerb
            // 
            this.chrerb.AutoSize = true;
            this.chrerb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chrerb.BackgroundImage")));
            this.chrerb.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chrerb.Location = new System.Drawing.Point(221, 3);
            this.chrerb.Name = "chrerb";
            this.chrerb.Size = new System.Drawing.Size(70, 23);
            this.chrerb.TabIndex = 19;
            this.chrerb.TabStop = true;
            this.chrerb.Text = "中文";
            this.chrerb.UseVisualStyleBackColor = true;
            // 
            // butds
            // 
            this.butds.Enabled = false;
            this.butds.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butds.Location = new System.Drawing.Point(571, 337);
            this.butds.Name = "butds";
            this.butds.Size = new System.Drawing.Size(134, 26);
            this.butds.TabIndex = 27;
            this.butds.Text = "定时发送";
            this.butds.UseVisualStyleBackColor = true;
            this.butds.Click += new System.EventHandler(this.butds_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(567, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "间隔时间（s）：";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(576, 394);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 23);
            this.comboBox4.TabIndex = 30;
            // 
            // bcbt
            // 
            this.bcbt.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bcbt.Location = new System.Drawing.Point(572, 86);
            this.bcbt.Name = "bcbt";
            this.bcbt.Size = new System.Drawing.Size(118, 27);
            this.bcbt.TabIndex = 31;
            this.bcbt.Text = "保存数据";
            this.bcbt.UseVisualStyleBackColor = true;
            this.bcbt.Click += new System.EventHandler(this.bcbt_Click);
            // 
            // Form
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(729, 429);
            this.Controls.Add(this.bcbt);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butds);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btsend);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btreset);
            this.Controls.Add(this.btopen);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form";
            this.Text = "串口调试助手";
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label portname;
        private System.Windows.Forms.Label baudrate;
        private System.Windows.Forms.ComboBox cbpn;
        private System.Windows.Forms.ComboBox cbbd;
        private System.Windows.Forms.Button btopen;
        private System.Windows.Forms.Button btreset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btsend;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.RadioButton chinrb;
        private System.Windows.Forms.RadioButton chrerb;
        private System.Windows.Forms.Button bcbt;
    }
}

