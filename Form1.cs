using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Data.SqlClient;



namespace WindowsFormsApp3
{


    public partial class Form : System.Windows.Forms.Form
    {
        //private SerialPort sp = new SerialPort();//串口通信
        // private StringBuilder str = new StringBuilder();
        //private StringBuilder builder = new StringBuilder();

        public Form()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form_Load(object sender, EventArgs e)
        {

            //String[] ports = SerialPort.GetPortNames();
            //Array.Sort(ports);
            //cbpn.Items.AddRange(ports);
            //cbpn.SelectedIndex = cbpn.Items.Count > 0 ? 0 : -1;//默认显示第一个串口号（最小的那个）
            SearchAddPort(serialPort1, cbpn);
            cbbd.Text = "115200";//默认显示9600
            comboBox3.Text = "8";//数据位
            comboBox2.Text = "1";//停止位
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);//添加串口收到数据的事件注册(当串口接收到数据之后，就调用port_DataReceived方法；
            for (int i = 1; i < 100; i++)
            {
                comboBox4.Items.Add(i.ToString());//秒前有一个空格符

            }
            

        }
        private void SearchAddPort(SerialPort myport, ComboBox combo)//串口扫描
        {
            string[] s = new string[20];
            string buffer;
            combo.Items.Clear();
            int count = 0;
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    buffer = "COM" + i.ToString();
                    myport.PortName = buffer;
                    myport.Open();//若端口未打开，则catch异常
                    s[count] = buffer;
                    combo.Items.Add(buffer);
                    myport.Close();
                    count++;
                }
                catch//catch为空，执行下一个循环
                {

                }

            }
            combo.Text = s[0];
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//处理串口收到的数据
        {
            if (radioButton1.Checked)//如果接收模式为字符模式
            {
                string str = serialPort1.ReadExisting();//字符串方式读
                textBox1.AppendText(str);//添加内容
            }
            if (radioButton2.Checked)
            { 
              //如果接收模式为数值接收（接收缓存中的所有数据）
                int count = 0;
                byte[] buf = new byte[serialPort1.BytesToRead];
                //List<byte> buffer = new List<byte>();
                serialPort1.Read(buf, 0, buf.Length);
                for (int i = 0; i < buf.Length; i++)
                {
                    string str = Convert.ToString(buf[i]);
                    textBox1.AppendText("0x" + (str.Length == 1 ? "0" + str : str) + " ");//给接收到的数据添加OX
                    count++;
                }
                label4.Text = "接收字节数：" + count;
            }
            if (chrerb.Checked)//如果选中中文接收
            {
                int count = 0;
                byte[] buf = new byte[serialPort1.BytesToRead];
                serialPort1.Read(buf, 0, buf.Length);
                String chinshou = ByteToString(buf);
                textBox1.AppendText(chinshou);


            }
        }
        private void btopen_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                btopen.Text = "关闭串口";
                btsend.Enabled = serialPort1.IsOpen;
                butds.Enabled = serialPort1.IsOpen;

            }
            else//点击打开按钮
            {
                serialPort1.PortName = cbpn.Text;
                serialPort1.BaudRate = Convert.ToInt32(cbbd.Text);
                try
                {
                    serialPort1.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                btopen.Text = serialPort1.IsOpen ? "关闭串口" : "打开串口";
                btsend.Enabled = serialPort1.IsOpen;
                butds.Enabled = serialPort1.IsOpen;

            }

        }

        private void btsend_Click(object sender, EventArgs e)//按发送按钮
        {
            if (serialPort1.IsOpen)//判断串口是否打开，如果打开执行下一步操作
            {
                send(serialPort1, textBox2.Text);      
            }
            else
            {
                MessageBox.Show("请打开串口", "警告");
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btreset_Click(object sender, EventArgs e)//复位按钮
        {
            textBox1.Text = " ";
            //textBox2.Text = " ";

        }

        private void butds_Click(object sender, EventArgs e)//定时发送按钮
        {
            int i = 0;
            try//若接收到的是个位数，即1-9秒，则执行catch语句，若接收到的是10-99秒，执行try语句
            {
                i = Convert.ToInt32(comboBox4.Text.Substring(0, 2));
            }
            catch
            {
                try
                {
                    i = Convert.ToInt32(comboBox4.Text.Substring(0, 1));

                }
                catch
                {
                    MessageBox.Show("输入的时间为0");
                    return;//返回整个函数
                }
               
                
            }
            if (serialPort1.IsOpen)
            {
               
                timer1.Interval = i * 1000;//设置定时器的中断为多少秒，定时器的单位为ms
                timer1.Start();
            }
            else
            {
                MessageBox.Show("请打开串口");
            }

            butds.Enabled = false;

        }
         private void send(SerialPort port,String textBox)//数据发送函数
        {
            if (radioButton3.Checked)//按字符发送
            {
                try
                {
                    byte[] send = new byte[20];
                    send[0] = 0xAB;
                    send[1] = 0x00;
                    send[2] = 0x00;
                    send[3] = 0x00;
                    send[4] = 0x37;
                    send[5] = 0x00;
                    send[6] = 0x01;
                    send[7] = 0x01;
                    send[8] = 0x01;
                    send[9] = 0x01;
                    send[10] = 0x00;
                    send[11] = 0x00;
                    send[12] = 0x00;
                    send[13] = 0x00;
                    send[14] = 0x00;
                    send[15] = 0x00;
                    send[16] = 0x00;
                    send[17] = 0x00;
                    send[18] = 0x00;
                    send[19] = 0xE6;
                    port.Write(send, 0, send.Length);
                }

                catch (Exception err)
                {
                    MessageBox.Show("串口数据写入错误", "错误");

                }

            }
            if (radioButton4.Checked) //按数值发送
            {


                String trim = textBox.Replace(" ", "");//去除空格

                if (trim.Length % 2 != 0)//发送的数据位奇数个
                {
                    int count = 0;
                    byte[] data = new byte[trim.Length / 2 + 1];
                    for (int i = 0; i < (trim.Length - trim.Length % 2) / 2; i++)
                    {

                        data[i] = Convert.ToByte(trim.Substring(i * 2, 2), 16);
                        //serialPort1.Write(data, 0, data.Length);
                        count++;

                    }
                    data[trim.Length / 2] = Convert.ToByte(trim.Substring(trim.Length - 1, 1), 16);
                    count++;
                    port.Write(data, 0, data.Length);//串口发送
                    label6.Text = "发送字节数：" + count;
                }
                else//发送数据的个数为偶数个
                {
                    int count = 0;
                    byte[] data = new byte[trim.Length / 2];
                    for (int i = 0; i < (trim.Length - trim.Length % 2) / 2; i++)
                    {
                        data[i] = Convert.ToByte(trim.Substring(i * 2, 2), 16);
                        count++;
                    }

                    port.Write(data, 0, data.Length);
                    label6.Text = "发送字节数：" + count;
                }
            }
            if (chinrb.Checked)//如果选中中文按钮
            {
                int count = 0;
                string SS = textBox;
                byte [] DD=StringToByte(SS);//调用StringToByte方法
                port.Write(DD, 0, DD.Length);
                count = DD.Length;
                label6.Text = "发送字节数：" + count;

            }
         }

        private void timer1_Tick(object sender, EventArgs e)//定时器
        {
            butds.Enabled = true;
            timer1.Stop();
            send(serialPort1, textBox2.Text);
        }
        private byte[] StringToByte(string TheString)//将UTF-8（中文显示）的编码转换成gb2312的编码，一个中文字符占两个字节
        {
            Encoding FromEncoding = Encoding.GetEncoding("UTF-8");
            Encoding ToEncoding = Encoding.GetEncoding("gb2312");
            byte[] BB = FromEncoding.GetBytes(TheString);//得到字节组
            byte[] CC = Encoding.Convert(FromEncoding, ToEncoding, BB);//将整个字节数组从一种编码转换成另一种编码
            return CC;
        }
        private String ByteToString(byte[] EE)//将bg2312编码转换成UTF-8（中文显示）编码
        {
            String chin;
            Encoding FromEncoding = Encoding.GetEncoding("gb2312");
            Encoding ToEncoding = Encoding.GetEncoding("UTF-8");
            byte[] FF = Encoding.Convert(FromEncoding, ToEncoding, EE);
            chin = ToEncoding.GetString(FF);
            return chin;
        }


        private void chinrb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bcbt_Click(object sender, EventArgs e)
        {
            string str = "Server=DESKTOP-00RDM99;database=highcharts;uid= sa;pwd=123456";
            SqlConnection conn = new SqlConnection(str);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("数据库未连接", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox1.Text != null)
            {
                String WW = textBox1.Text.Trim().ToString();
               // string strSQL = "insert into dbo.message(textBox1)values('this.WW')";
                string strSQL = "insert into dbo.message(textBox1,textBox2) values ('" + textBox1.Text.Trim().Substring(0, 2) + "','" + textBox2.Text.Trim().Substring(0,2) + "')";
                SqlCommand mycom = new SqlCommand(strSQL, conn);
                mycom.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("输出框为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conn.Close();
        }

        private void cbpn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
