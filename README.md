# WindowsFormsApp3
串口工具
目录 
1．串口 .................................................. 1 
1.1．串口通信定义 ..................................... 1 
1.2．串口通信原理 ..................................... 1 
1.3．串口通信协议 ..................................... 2 
1.3.1用户层协议编制原理	2 
2．上位机 ................................................ 3 	
2.1上位机定义	3 
3.基于C#的串口通信上位机	4 
3.1 Microsoft Visual Studio使用步骤	4 
3.2 C#制作一个串口通信上位机	11 
3.2.1 串口通信模块（SerialPort）	11 
3.2.1窗口设计	13 
3.2.1代码编写	13 
4.串口协议	23 
4.1二进制数据协议解析	23 
4.2 文本协议分析	26 
5.总结	28 

 
 
 
 
串口通信 
1．串口 
1.1．串口通信定义  
串口是计算机上一种通用的设备通信协议，串口通信可以用于远程采集设备中的数
据。大多数计算机包含两个基于RS232的串口；很多GPIB兼容的设备也会带有RS232接口。 
 
1.2．串口通信原理 
串口通信的概念非常简单，串口按位（bit）发送、接收字节。尽管比并行通信慢，但串口通信实现简单并且能够远距离通信。比如 IEEE488 定义并行通行状态时，规定设备线总长不得超过 20 米，并且任意两个设备间的长度不得超过 2 米；而对于串口而言，长度可达 1200 米。串口通信使用 3 根线完成：（1）地线，（2）发送，（3）接收。由于串口通信是异步的，端口能够在一根线上发送数据的同时在另一根线上接收数据，其他线用于握手，但不是必须的。串口通信最重要的参数是波特率、数据位、停止位和奇偶校验。对于两个进行通信的端口，这些参数必须匹配：      a. 波特率：这是一个衡量通信速度的参数。它表示每秒钟传送bit的个数。例如300 波特表示每秒钟发送 300 个 bit。串口通信的钟周期也是指波特率，例如：如果协议需要
4800波特率，那么时钟就是 4800Hz，这也意味着串口通信在数据线上的采样率为4800Hz。但是波特率和距离成反比。高波特率常常用于放置的很近的仪器间的通信，典型的例子就是
GPIB设备的通信。    
b.数据位：这是衡量通信中实际数据位的参数。当计算机发送一个信息包，实际的数据不会是8位的，标准的值是5、7和8位。如何设置取决于你想传送的信息。比如，标准的
ASCII码是0～127（7位）。扩展的ASCII码是0～255（8位）。如果数据使用简单的文本
（标准 ASCII码），那么每个数据包使用7位数据。每个包是指一个字节，包括开始/停止位，数据位和奇偶校验位。 
c.停止位：用于表示单个包的最后一位。典型的值为1，1.5和2位。停止位是按长度来算的。串行异步通信从计时开始，以单位时间为间隔（一个单位时间就是波特率的倒数），依次接收所规定的数据位和奇偶校验位，并拼装成一个字符的并行字节；此后应接收到规定长度的停止位“1”。所以说，停止位都是“1”，1.5是它的长度，即停止位的高电平保持
1.5个单位时间长度。一般来讲，停止位有1，1.5，2个单位时间三种长度。由于数据是在传输线上定时的，并且每一个设备有其自己的时钟，很可能在通信中两台设备间出现了小小的不同步。因此停止位不仅仅是表示传输的结束，也能提供计算机校正时钟同步的机会。适用于停止位的位数越多，不同时钟同步的容忍程度越大，但是数据传输率同时也越慢。    
d.奇偶校验位：串口通信中的一种简单的检错方式。有四种检错方式：偶、奇、高和低。当然没有校验位也是可以的。对于偶和奇校验的情况，串口会设置校验位（数据位后面的一位），用一个值确保传输的数据有偶个或者奇个逻辑高位。例如，如果数据是011，那么对于偶校验，校验位为0，保证逻辑高的位数是偶数个。如果是奇校验，校验位为1，这样就有3个逻辑高位。高位和低位不真正的检查数据，简单置位逻辑高或者逻辑低校验。这样使得接收设备能够知道一个位的状态，有机会判断是否有噪声干扰了通信或者是否传输和接收数据不同步。 
 
图1-1 数据包 
1.3．串口通信协议 
串口通信协议一般可以从两个角度来思考：底层通信协议和用户层协议。底层协议一般由计算机硬件提供商和设备厂家提供，在一般性的通信编程中很少涉及，而用户层协议则是面向使用者的，也就是我们在编程中通常谈到的通信协议。这种用户层的通信协议，简单说，就是数据以何种格式发送出去，或者说如何从接收到的某种格式的数据中提取需要的数据，以及在发送和接收过程中如何保证这些数据的正确性，即数据校验。 
1.3.1用户层协议编制原理 
在串口用户层的通信协议中，一般是关于发送方如何建立数据包、接收方如何处理数据包、如何从数据包中提取出预期数据等内容。在用户层的通信协议中有几个原则需要我们严
格遵守： 
1.数据包必须有包头 
包头是供接收方判断一个数据包开始传输的重要标志，接收方从收到的数据中判断接收到了包头，就认为接收的数据已经开始，真正的数据信息马上就会到达。但是，我们必须要切记一点，包头字符必须有别于数据信息，也就是说，这种特征是数据包中其他数据没有的，否则会造成混乱。 
2.非定长数据必须有包尾 
3.定长数据应该指明长度 
对于长度不变的数据包，数据长度应该事先约定。这样接收方在知道接收长度之后，就能够判断接收的数据包是否结束。 
4.建议对数据进行校验 
串口通信底层协议(机器硬件实现)已经设置了奇偶检验方式。但是，如果在用户层
添加新的校验，可以对数据进行进一步的排错，这样可以更好地保证数据的正确
性。 
5.换行符的使用 
如果要显示数据，推荐在数据包的结尾添加换行符，方便阅读接收到的数据。 
6.如果更新快的数据，建议尽量简短 
如果要求数据更新快，就要让每次传输的数据尽量短。 
 
2．上位机 
2.1上位机定义 
上位机是指可以直接发出操控命令的计算机，一般是 PC/host /computer/master 
/computer/upper computer 等。下位机是直接控制设备获取设备状况的计算机，一般是 PLC/ 单片机/single chip microcomputer/slave computer/lower computer 之类的。上位机发出的命令首先给下位机，下位机再根据此命令解释成相应时序信号直接控制相应设备。两机如何通讯，
一般取决于下位机。 
 
 
 
3.基于C#的串口通信上位机 
前期需要的语言基础：C#（http://www.runoob.com/csharp/csharp-tutorial.html） 
使用软件：Microsoft Visual Studio 
 
3.1 Microsoft Visual Studio使用步骤 
（1）	文件、新建、项目、然后选择Windows窗体应用输入工程名称，名称和解决方案名称保持一致。 位置中输入程序路径，框架最好选择.NET Framework 4（兼容性较好）。 
  图 3-1 VS新建项目界面 
（2）	新建好窗体应用项目后，Microsoft Visual Studio的显示如图3-2所示，分为4个模块。 
模块一：窗体form1 
可以将工具箱中的的控件（如按钮、文本输入框、复选框）、组件等往窗体里拖。（若没
有出现工具箱可以点击视图，选择工具箱）。 
模块二：解决方案资源管理器 
解决方案资源管理器窗口默认位于右上角。（若没有可以通过类视图在菜单栏中选择）解决方案管理器窗口显示了组成该窗体项目的项目文件，.Designer.cs 文件是系统自动生成的，一般来说不需要修改。 
模块三：属性 
属性模块用来更改控件及窗体的属性。 
1、常用属性 
（1）	Name属性：用来获取或设置窗体的名称，在应用程序中可通过Name属性来引用窗
体； 
（2）	WindowState属性：用来获取或设置窗体的窗口状态。 取值有三种： Normal （窗
体正常显示）、 Minimized（窗体以最小化形式显示）和 Maximized（窗体以最   
大化形式显示）； 
（3）	StartPosition属性：用来获取或设置运行时窗体的起始位置。默认的起始位置是
WindowsDefaultLocation； 
（4）	Text属性：该属性是一个字符串属性，用来设置或返回在窗口标题栏中显示的文
字； 
（5）	Width属性：用来获取或设置窗体的宽度；   
（6）	Height属性：用来获取或设置窗体的高度； 
（7）	Left属性：用来获取或设置窗体的左边缘的x坐标（以像素为单位）；   
（8）	Top属性：用来获取或设置窗体的上边缘的y坐标（以像素为单位）； 
（9）	ControlBox属性：用来获取或设置一个值，该值指示在该窗体的标题栏中是否显示
控制框。值为true时将显示控制框，值为false时不显示控制框；   
（10）	MaximizeBox属性：用来获取或设置一个值，该值指示是否在窗体的标题栏中显示
最大化按钮。值为 true时显示最大化按钮，值为false时不显示最大化按钮；   
（11）	MinimizeBox 属性：用来获取或设置一个值，该值指示是否在窗体的标题栏中显示
最小化按钮。值为 true时显示最小化按钮，值为false时不显示最小化按钮；   
（12）	AcceptButton 属性：该属性用来获取或设置一个值，该值是一个按钮的名称，当按 
Enter 键时就相当于单击了窗体上的该按钮；   
（13）	CancelButton 属性：该属性用来获取或设置一个值，该值是一个按钮的名称，当按 
Esc 键时就相当于单击了窗体上的该按钮；  
（14）	Modal 属性：该属性用来设置窗体是否为有模式显示窗体。如果有模式地显示该窗
体，该属性值为true；否则为 false。当有模式地显示窗体时，只能对模式窗体上的对象进行输入。必须隐藏或关闭模式窗体（通常是响应某个用户操作），然后才能
对另一窗体进行输入。有模式显示的窗体通常用做应用程序中的对话框；   
（15）	ActiveControl属性：用来获取或设置容器控件中的活动控件。窗体也是一种容器
控件；  
（16）	ActiveMdiChild属性：用来获取多文档界面（MDI）的当前活动子窗口；            
（17）	AutoScroll 属性：用来获取或设置一个值，该值指示窗体是否实现自动滚动。如果   
此属性值设置为 true，则当任何控件位于窗体工作区之外时，会在该窗体上显示滚动条。 另外，当自动滚动打开时，窗体的工作区自动滚动，以使具有输入焦点的控件可
见；                                 
（18）	BackColor属性：用来获取或设置窗体的背景色；   
（19）	BackgroundImage属性：用来获取或设置窗体的背景图像；   
（20）	Enabled 属性：用来获取或设置一个值，该值指示控件是否可以对用户交互作出响
应。如果控件可以对用户交互作出响应，则为 true；否则为false。默认值为
true；   
（21）	Font属性：用来获取或设置控件显示的文本的字体;   
(22）ForeColor属性：用来获取或设置控件的前景色；   
（23）	IsMdiChild属性：获取一个值，该值指示该窗体是否为多文档界面（MDI）子窗
体。值为 true时，是子窗体，值为false时，不是子窗体；   
（24）	IsMdiContainer 属性：获取或设置一个值，该值指示窗体是否为多文档界面
（MDI）中的子窗体的容器。值为true时，是子窗体的容器，值为false时，不是子 
窗体的容器；   
（25）	KeyPreview属性：用来获取或设置一个值，该值指示在将按键事件传递到具有焦点
的控件前，窗体是否将接收该事件。值为true时，窗体将接收按键事件，值为
false时，窗体不接收按键事件 ；  
（26）	MdiChildren属性：数组属性。数组中的每个元素表示以此窗体作为父级的多文档
界面（MDI）子窗体；  
（27）	MdiParent属性：用来获取或设置此窗体的当前多文档界面（MDI）父窗体；   
（28）	ShowInTaskbar属性：用来获取或设置一个值，该值指示是否在Windows任务栏中
显示窗体；   
（29）	Visible属性：用于获取或设置一个值，该值指示是否显示该窗体或控件。值为 true时显示窗体或控件，为 false时不显示； 
（30）	Capture属性：如果该属性值为true，则鼠标就会被限定只由此控件响应，不管鼠
标是否在此控件的范围内。  
2、常用方法  
下面介绍一些窗体的最常用方法：  
（1）	Show方法：该方法的作用是让窗体显示出来，其调用格式为：窗体名.Show()；   
其中窗体名是要显示的窗体名称；  
（2）	Hide方法：该方法的作用是把窗体隐藏出来，其调用格式为：窗体名.Hide()；  
其中窗体名是要隐藏的窗体名称；   
（3）	Refresh方法：该方法的作用是刷新并重画窗体，其调用格式为：窗体
名.Refresh()；其中窗体名是要刷新的窗体名称；   
（4）	Activate方法：该方法的作用是激活窗体并给予它焦点。其调用格式为：窗体
名.Activate()；其中窗体名是要激活的窗体名称；  
（5）	Close方法：该方法的作用是关闭窗体。其调用格式为：窗体名.Close()；   
其中窗体名是要关闭的窗体名称；   
（6）	ShowDialog 方法：该方法的作用是将窗体显示为模式对话框。其调用格式为：窗体
名.ShowDialog()。   
3．常用事件  
（1）	Load事件：该事件在窗体加载到内存时发生，即在第一次显示窗体前发生。经常用
来写一些初始化函数； 
（2）	Activated事件：该事件在窗体激活时发生；   
（3）	Deactivate事件：该事件在窗体失去焦点成为不活动窗体时发生；   
（4）	Resize事件：该事件在改变窗体大小时发生；   
（5）	Paint事件：该事件在重绘窗体时发生；   
（6）	Click事件：该事件在用户单击窗体时发生； 
（7）	DoubleClick事件：该事件在用户双击窗体时发生；  
（8）	Closed事件：该事件在关闭窗体时发生。 
模块四：工具箱 
工具箱中存放所有的控件，如按钮、复选框等公共控件，还有指针、串口等组件。双击控件就能编辑对应控件的代码。（双击控件口，系统自动组自动在.Designer.cs 文件中为该控件注册了事件，如若在代码中删除了对应控件的代码，窗体显示文件（Form1.cs(设计）会报错，此时应在.Designer.cs 文件中删除对应事件注册代码）。 
 
图3-2 VS窗体界面 
（3）将工具箱中需要的控件拖至窗体中。例如：在窗体中添加两个按钮，当单击第一个按钮时，显示“我来啦！”，当单击第二个按钮时，显示“我走啦！”。 
第一步：创建项目； 
文件→新建→项目；选择“项目类型”为Visual C#，“模板”为Windows窗体应用程序；输入名称“例1-2”；选择存放路径“H:\C#程序”；选择“创建新解决方案”；第二步：用户界面设计；（视图→工具箱） 
在工具箱中点击“button”添加按钮；点击“textbox”添加文本框； 
工具箱：                          用户界面： 
 
图 3-3 VS工具箱与用户界面 
第三步：属性设置；（视图→属性窗口）        
控件名 	Name 	Text 
Form1 	第一个窗体应用程序 	第一个窗体应用程序 
Button1 	button1 	按钮1 
Button2 	button2 	按钮2 
表 3-1 属性设置 
  
图 3-4窗体界面： 
 
第四步：编写程序代码； 
（1）	双击按钮1，在private void button1_Click(object sender, EventArgs e){}中输入            textBox1.Text=("我来了！"); 
（2）	双击按钮2，在private void button2_Click(object sender, EventArgs e){}中输入 
           textBox1.Text = ("我走了！"); 
代码如下： 
namespace WindowsFormsApp7 
{ 
    public partial class 第一个窗体应用程序 : Form 
    { 
        public 第一个窗体应用程序() 
        { 
            InitializeComponent(); 
        } 
 
        private void button1_Click(object sender, EventArgs e) 
        {             textBox1.Text = ("我来了"); 
        } 
 
        private void button2_Click(object sender, EventArgs e) 
        {             textBox1.Text = ("我走了"); 
        } 
    } 
} 
第五步：保存、调试、运行；单击启动调试或者 F5 键。 
点击调试后可以在窗体最下端查看程序运行的结果。如可以在局部变量中查看单步调试后的各变量变化情况。
  
图 3-5 VS调试界面 
 
图 3-6 运行结果 
 
3.2 C#制作一个串口通信上位机 
目的：使用C#制作一个串口小助手串口小助手基本功能： 
1.能够手动选取端口号：点击port name后面的下拉框，即可手动选取对应的端口号； 
2.能够手动选取波特率：点击port name后面的下拉框，即可手动选取对应的波特率； 
3.在设置好端口号和波特率后，点击open按钮，即可打串口； 
4.在打开串口后，点击send按钮，可以将写入发送框的数据通过串口发送至对应机器，并且显示发送字符数； 
5.可以设置发送模式：字符、数值、中文； 
6.数据接收框中可以接收到机器返回的数据并显示接收字符数； 
7.保存接收框和发送框中的数据； 
8.定时发送：设置好定时时间后，点击定时发送按钮，定时发送数据； 
9.清除接收框的数据。 
 
3.2.1 串口通信模块（SerialPort） 
C#中已经封装了串口通信模块（SerialPort），故在做串口通信上位机时可以调用此模块，具体使用方法如下： 
1.在头文件中加入using System.IO.Ports。  
  
图 3-7 添加头文件 
2.在 Form1.cs（设计）中，通过工具箱向窗体拖拽一个 serialPort 控件，并在属性栏中修改 serialPort 控件的属性。 
  
图 3-8 serialPort 组件 
                            
BaudRate 	波特率 
DataBits 	数据位 
Parity 	奇偶校验位 
PortName 	端口号 
StopBits 	停止位 
ByteToRead 	获取输入缓冲区的 
IsOpen 	获取是否开启串口 
表 3-2 常用 serialPort 控件属性 
串口通信模块的事件有三个，双击即可建立函数。  
  
图 3- 9 serialPort 事件 
 
方 法 名 称 	说  明 
Open 	打开串口. 
Close 	关闭串口 
Read 	从SerialPort 输入缓冲区读 
ReadByte 	从SerialPort 输入缓冲区读一个字节 
ReadChar 	从SerialPort 输入缓冲区读一个字符 
Write 	写入到输出缓冲寄存器 
表3-3 serialPort类常见的方法 
3.2.1窗口设计 
  图 3- 10 串口小助手窗体界面 
 
3.2.1代码编写 
首先实现一个简单的串口收发功能： 
（1）	设定端口名、波特率、数据位、停止位。 
 
  private void Form_Load(object sender, EventArgs e) 
        { 
 
            String[] ports = SerialPort.GetPortNames();             Array.Sort(ports);             cbpn.Items.AddRange(ports); 
            cbpn.SelectedIndex = cbpn.Items.Count > 0 ? 0 : -1;//默认显示第一个串口号
SearchAddPort(serialPort1, cbpn); 
            cbbd.Text = "115200";//默认显示9600             comboBox3.Text = "8";//数据位             comboBox2.Text = "1";//停止位 
            serialPort1.DataReceived += new 
SerialDataReceivedEventHandler(port_DataReceived);//添加串口收到数据的事件注册(当串口接收到数据之后，就调用port_DataReceived 方法； 
           
       } 
 
（2）	数据接收模块 
  private void port_DataReceived(object sender,SerialDataReceivedEventArgs e)//处理串口收到的数据 
        {                 int count = 0;                  byte[] buf = new byte[serialPort1.BytesToRead]; 
                //List<byte> buffer = new List<byte>();                 serialPort1.Read(buf, 0, buf.Length);                 for (int i = 0; i < buf.Length; i++) 
                {                     string str = Convert.ToString(buf[i]);                     textBox1.AppendText("0x" + (str.Length == 1 ? "0" + str : str) + " ");//给
接收到的数据添加OX 
                    count++; 
                }                 label4.Text = "接收字节数：" + count; 
            }             if (chrerb.Checked)//如果选中中文接收 
            {                 int count = 0;                 byte[] buf = new byte[serialPort1.BytesToRead];                 serialPort1.Read(buf, 0, buf.Length);                 String chinshou = ByteToString(buf);                 textBox1.AppendText(chinshou); 
            }   }   
 
（3）	数据发送模块 
private void btsend_Click(object sender, EventArgs e)//按发送按钮 
        { 
            if (serialPort1.IsOpen)//判断串口是否打开，如果打开执行下一步操作 
            { 
               send(serialPort1, textBox2.Text);       
           }             else 
            { 
                MessageBox.Show("请打开串口", "警告"); 
            }  
}  
private void send(SerialPort port,String textBox)//数据发送函数 
        {                 try                 {                     byte[] send = new byte[20];                     send[0] = 0xAB;                     send[1] = 0x00;                     send[2] = 0x00;                     send[3] = 0x00;                     send[4] = 0x37;                     send[5] = 0x00;                     send[6] = 0x01;                     send[7] = 0x01;                     send[8] = 0x01;                     send[9] = 0x01;                     send[10] = 0x00;                     send[11] = 0x00;                     send[12] = 0x00;                     send[13] = 0x00;                     send[14] = 0x00;                     send[15] = 0x00;                     send[16] = 0x00;                     send[17] = 0x00;                     send[18] = 0x00;                     send[19] = 0xE6;                     port.Write(send, 0, send.Length);                 } 
} 
此时已完成一个简单的串口收发功能。 
串口小助手能够完成基本的收发数据的基础上可以添加一些其他功能。此代码已写了完整注释，故直接贴代码。 
using System; using System.Text; using System.Windows.Forms; using System.IO.Ports; using System.Data.SqlClient; 
 
namespace WindowsFormsApp3 
{ 
 
    public partial class Form : System.Windows.Forms.Form 
    {                  public Form() 
        { 
            InitializeComponent(); 
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; 
        } private void Form_Load(object sender, EventArgs e)         { 
 
            SearchAddPort(serialPort1, cbpn);             cbbd.Text = "115200";//默认显示9600             comboBox3.Text = "8";//数据位             comboBox2.Text = "1";//停止位             serialPort1.DataReceived += new 
SerialDataReceivedEventHandler(port_DataReceived);//添加串口收到数据的事件注册(当串口接收到数据之后，就调用port_DataReceived 方法 
            for (int i = 1; i < 100; i++) 
            {                 comboBox4.Items.Add(i.ToString());//秒前有一个空格符 
} 
 
        }         private void SearchAddPort(SerialPort myport, ComboBox combo)//串口扫描，自动将
串口号填写在串口下拉框中 
        {             string[] s = new string[20];             string buffer;             combo.Items.Clear();//清空串口下拉框             int count = 0; //设置计数器初始值为0             for (int i = 0; i < 20; i++)//循环将存在的串口号添加到串口下拉框中 
            {                 try                 {                     buffer = "COM" + i.ToString();                     myport.PortName = buffer; 
                    myport.Open();//若端口未打开，则catch 异常                     s[count] = buffer;                     combo.Items.Add(buffer);                     myport.Close();                     count++; 
                } 
                catch//catch 为空，执行下一个循环 
                { 
 
                } 
            } 
            combo.Text = s[0]; //在串口下拉框中自动显示第一个串口号 
 } 
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//处理串
口收到的数据 
        {             if (radioButton1.Checked)//如果接收模式为字符模式 
            {                 string str = serialPort1.ReadExisting();//字符串方式读                 textBox1.AppendText(str);//添加内容 
            }             if (radioButton2.Checked) 
            {  
              //如果接收模式为数值接收（接收缓存中的所有数据）                 int count = 0;                 byte[] buf = new byte[serialPort1.BytesToRead]; //读取缓存中的字节个数 
                //List<byte> buffer = new List<byte>();                 serialPort1.Read(buf, 0, buf.Length);                 for (int i = 0; i < buf.Length; i++) 
                {                     string str = Convert.ToString(buf[i]); 
                    textBox1.AppendText("0x" + (str.Length == 1 ? "0" + str : str) + " ");//给
接收到的数据添加OX，使其以十六进制的方式显示出来 
                    count++; 
                }                 label4.Text = "接收字节数：" + count; 
            } 
            if (chrerb.Checked)//如果选中中文接收 
            { 
                int count = 0; 
                byte[] buf = new byte[serialPort1.BytesToRead]; 
                serialPort1.Read(buf, 0, buf.Length); //一次性读取缓存中的全部数据                 String chinshou = ByteToString(buf);                 textBox1.AppendText(chinshou); 
            }         } 
        private void btopen_Click(object sender, EventArgs e) //点击打开串口按钮 
        {             if (serialPort1.IsOpen) 
            { 
                serialPort1.Close(); 
                btopen.Text = "关闭串口";                 btsend.Enabled = serialPort1.IsOpen; 
butds.Enabled = serialPort1.IsOpen; 
            }             else//点击打开按钮 
            { 
                serialPort1.PortName = cbpn.Text; //读取端口号 
                serialPort1.BaudRate = Convert.ToInt32(cbbd.Text); //读取波特率                 try                 {                     serialPort1.Open(); 
 
                }                 catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message); 
                }                 btopen.Text = serialPort1.IsOpen ? "关闭串口" : "打开串口";                 btsend.Enabled = serialPort1.IsOpen;                 butds.Enabled = serialPort1.IsOpen; 
 
            } 
 
        } 
 
        private void btsend_Click(object sender, EventArgs e)//点击发送按钮 
        { 
            if (serialPort1.IsOpen)//判断串口是否打开，如果打开执行下一步操作 
            {                 send(serialPort1, textBox2.Text);       
            }             else 
            { 
                MessageBox.Show("请打开串口", "警告"); 
            } 
        } 
 
        private void btreset_Click(object sender, EventArgs e)//复位按钮 
        { 
            textBox1.Text = " ";             //textBox2.Text = " "; 
} 
private void butds_Click(object sender, EventArgs e)//定时发送按钮 
 
 
        {             int i = 0; 
            try//若接收到的是个位数，即1-9 秒，则执行catch 语句，若接收到的是10-
99 秒，执行try 语句 
            {                 i = Convert.ToInt32(comboBox4.Text.Substring(0, 2)); 
            }             catch             {                 try                 {                     i = Convert.ToInt32(comboBox4.Text.Substring(0, 1)); 
 
                }                 catch 
                { 
                    MessageBox.Show("输入的时间为 0");                     return;//返回整个函数 
                } 
                
                             }             if (serialPort1.IsOpen) 
            { 
                                timer1.Interval = i * 1000;//设置定时器的中断为多少秒，定时器的单位为
ms 
                timer1.Start();//跳转至timer1_Tick 函数 
            }             else 
            { 
 
                MessageBox.Show("请打开串口"); 
            } 
 
            butds.Enabled = false; 
 
        } 
         private void send(SerialPort port,String textBox)//数据发送函数 
        {             if (radioButton3.Checked)//按字符发送 
            { 
                Try 
 
                {//send 中的数据可改 
                    byte[] send = new byte[20];                     send[0] = 0xAB; 
                    send[1] = 0x00;                     send[2] = 0x00; 
                    send[3] = 0x00;                     send[4] = 0x37; 
                    send[5] = 0x00;                     send[6] = 0x01;                     send[7] = 0x01;                     send[8] = 0x01;                     send[9] = 0x01;                     send[10] = 0x00;                     send[11] = 0x00;                     send[12] = 0x00;                     send[13] = 0x00;                     send[14] = 0x00;                     send[15] = 0x00;                     send[16] = 0x00;                     send[17] = 0x00;                     send[18] = 0x00;                     send[19] = 0xE6;                     port.Write(send, 0, send.Length); 
                } 
 
                catch (Exception err) 
                { 
                    MessageBox.Show("串口数据写入错误", "错误"); 
 
                }             }             if (radioButton4.Checked) //按数值发送 
            { 
                String trim = textBox.Replace(" ", "");//去除空格 
 
                if (trim.Length % 2 != 0)//发送的数据位奇数个 
                { 
                    int count = 0; 
                    byte[] data = new byte[trim.Length / 2 + 1]; 
                    for (int i = 0; i < (trim.Length - trim.Length % 2) / 2; i++)                     { 
 
                        data[i] = Convert.ToByte(trim.Substring(i * 2, 2), 16); 
                        //serialPort1.Write(data, 0, data.Length); 
                        count++; 
 
                    } 
                    data[trim.Length / 2] = Convert.ToByte(trim.Substring(trim.Length - 1, 
1), 16); 
                    count++;                     port.Write(data, 0, data.Length);//串口发送                     label6.Text = "发送字节数：" + count; 
                } 
                else//发送数据的个数为偶数个 
                {                     int count = 0;                     byte[] data = new byte[trim.Length / 2];                     for (int i = 0; i < (trim.Length - trim.Length % 2) / 2; i++) 
                    {                         data[i] = Convert.ToByte(trim.Substring(i * 2, 2), 16);                         count++; 
                    } 
 
                    port.Write(data, 0, data.Length);                     label6.Text = "发送字节数：" + count; 
                }             }             if (chinrb.Checked)//如果选中中文按钮 
            {                 int count = 0;                 string SS = textBox;                 byte [] DD=StringToByte(SS);//调用StringToByte 方法                 port.Write(DD, 0, DD.Length);                 count = DD.Length; 
                label6.Text = "发送字节数：" + count; 
 
            } 
         } private void timer1_Tick(object sender, EventArgs e)//定时器 
        { 
            butds.Enabled = true;             timer1.Stop(); 
            send(serialPort1, textBox2.Text); 
        }         private byte[] StringToByte(string TheString)//将UTF-8（中文显示）的编码转换成
gb2312 的编码，一个中文字符占两个字节 
        { 
            Encoding FromEncoding = Encoding.GetEncoding("UTF-8"); 
 
            Encoding ToEncoding = Encoding.GetEncoding("gb2312"); 
            byte[] BB = FromEncoding.GetBytes(TheString);//得到字节组             byte[] CC = Encoding.Convert(FromEncoding, ToEncoding, BB);//将整个字节数组
从一种编码转换成另一种编码 
            return CC; 
        }         private String ByteToString(byte[] EE)//将bg2312 编码转换成UTF-8（中文显示）编码 
        { 
            String chin; 
            Encoding FromEncoding = Encoding.GetEncoding("gb2312");             Encoding ToEncoding = Encoding.GetEncoding("UTF-8");             byte[] FF = Encoding.Convert(FromEncoding, ToEncoding, EE);             chin = ToEncoding.GetString(FF);             return chin; 
        }         private void bcbt_Click(object sender, EventArgs e) 
        {             string str = "Server=DESKTOP-00RDM99;database=highcharts;uid= sa;pwd=123456"; 
            SqlConnection conn = new SqlConnection(str);             try             {                 conn.Open(); 
            }             catch (Exception) 
            { 
                MessageBox.Show("数据库未连接", "系统提示", MessageBoxButtons.OK, 
MessageBoxIcon.Information); 
                return; 
            }             if (textBox1.Text != null) 
            { 
                String WW = textBox1.Text.Trim().ToString();             
                string strSQL = "insert into dbo.message(textBox1,textBox2) values ('" + 
textBox1.Text.Trim().Substring(0, 2) + "','" + textBox2.Text.Trim().Substring(0,2) + "')"; 
                SqlCommand mycom = new SqlCommand(strSQL, conn);                 mycom.ExecuteNonQuery(); 
            }             else 
            { 
                MessageBox.Show("输出框为空", "系统提示", MessageBoxButtons.OK, 
MessageBoxIcon.Information); 
            }             conn.Close();         } 
} 
 } 
此串口助手未针对具体的下位机，故在代码中没有体现对数据接收的校验。 
 
4.串口协议 
4.1二进制数据协议解析 
串口助手不仅可以进行通用的串口监听收发，还可以根据下位机的协议进行数据缓
存、分析以及通知界面。在此，我们用户层的通信协议应该是这样的：数据头+数据长度+ 数据正文+校验。 
例如：AA 44 05 01 02 03 04 05 EA 
这里我假设的一条数据，协议如下：      数据头：AA 44   数据长度：05 
     数据正文：01 02 03 04 05      校验：EA 
 一般数据的校验，都会采用 CRC16,CRC32,Xor 这三种常用的方式。数据安全要求高的，不允许丢包的，可能还要加入重发机制或是加入数据恢复算法，在校验后根据前面数据添加恢复字节流以恢复数据。这里采用的是简单的异或校验，包含数据头的所有字节，依次异或得到的。在实际开始编码之前，还有一个规则需要了解，当有了通讯协议，还需考虑 4 个问题：缓存收到的所有数据，找到一条完整数据，分析数据，界面通知。 
（1）	对于缓存收到的所有数据，一般最高效的办法就是顺序表，也就是数组，但数组的操作比较复杂，当你使用完一条数据后，用过的需要移除；新数据如果过多的时候，缓存过大需要清理；数据搬移等等，很有可能一个不小心就会丢数据导致软件出些莫名其妙的小问题。个人建议，使用 List<byte>，每次数据不足够的时候会扩容 1 倍，数据的增删改都已经做的很完善了。不会出现什么小问题。 
（2）	找到一条完整数据，如何找到完整数据呢？就我们例子的这个协议，首先在缓存的数据中找 AA 44，当我们找到后，探测后面的字节，发现是 05，然后看缓存剩下的数据是否足够，不足够就不用判断，减少时间消耗，如果剩余数据>=6 个（包含 1 个字节的校验），我们就算一个校验，看和最后的校验是否一致。 
（3）	分析数据：常用的方式就是 BitConvert.ToInt32 这一系列的方法，把连续的字节（和变量长度一样）读取并转换为对应的变量。 
（4）	校验：完整性判断的时候需要和校验对比，但是大多系统都不太严格，不支持重发，所以数据错误就直接丢弃。导致数据错误的原因很多，比如电磁干扰导致数据不完整或错误、硬件驱动效率不够导致数据丢失、我们的软件缓存出错等。 
void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)   
        {   
            if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环   
            try   
            {   
                Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI 的。   
                int n = comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致   
                byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据                   received_count += n;//增加接收计数                   comm.Read(buf, 0, n);//读取缓冲数据   
//<协议解析>                   bool data_1_catched = false;//缓存记录数据是否捕获到   
                //1.缓存数据                   buffer.AddRange(buf);                   //2.完整性判断   
                while (buffer.Count >= 4)//至少要包含头（2 字节）+长度（1 字节）+校验（1 字节）   
                {   
                    //2.1 查找数据头   
                    if (buffer[0] == 0xAA && buffer[1] == 0x44)   
                    {   
                        //2.2 探测缓存数据是否有一条数据的字节，如果不够，就不用费劲的做其他验证了                       
                        int len = buffer[2];//数据长度                                                   if (buffer.Count < len + 4) break;//数据不够的时候什么都不做   
                        //这里确保数据长度足够，数据头标志找到，我们开始计算校
验   
                        //2.3 校验数据，确认数据正确   
                        //异或校验，逐个字节异或得到校验码   

                        byte checksum = 0;                           for (int i = 0; i < len + 3; i++)//len+3 表示校验之前的位置   
                        {                               checksum ^= buffer[i];   
                        }                           if (checksum != buffer[len + 3]) //如果数据校验失败，丢弃这一包数据   
                        {                               buffer.RemoveRange(0, len + 4);//从缓存中删除错误数据                               continue;//继续下一次循环   
                        }   
                        //至此，已经被找到了一条完整数据。我们将数据直接分析，或是缓存起来一起分析                        
                        buffer.CopyTo(0, binary_data_1, 0, len + 4);//复制一条完整数据到
具体的数据缓存   
                        data_1_catched = true;                           buffer.RemoveRange(0, len + 4);//正确分析一条数据，从缓存中移除数据。   
                    }                       else   
                    {   
                        //这里是很重要的，如果数据开始不是头，则删除数据                           buffer.RemoveAt(0);   
                    }   
                }   
                //分析数据   
                if (data_1_catched)   
                {   
                    //我们的数据都是定好格式的，所以当我们找到分析出的数据1，就知道固定位置一定是这些数据，我们只要显示就可以了   
                    string data = binary_data_1[3].ToString("X2") + " " + binary_data_1[4].ToString("X2") + " " +   
                     binary_data_1[5].ToString("X2") + " " + binary_data_1[6].ToString("X2") + " " + binary_data_1[7].ToString("X2");   
                    //更新界面   
                    this.Invoke((EventHandler)(delegate { txData.Text = data; }));   
                }   
                //如果需要别的协议，只要扩展这个data_n_catched 就可以了。往往我们协议多的情况下，还会包含数据编号，给来的数据进行   
                //编号，协议优化后就是： 头+编号+长度+数据+校验                   builder.Clear();//清除字符串构造器的内容   
                //因为要访问ui 资源，所以需要使用invoke 方式同步ui。   
                this.Invoke((EventHandler)(delegate   
                {   
                    //判断是否是显示为16 禁止                       if (checkBoxHexView.Checked)   
                    {   
                        //依次的拼接出16 进制字符串   
                        foreach (byte b in buf)   
                        {                               builder.Append(b.ToString("X2") + " ");   
                        }                       }                       else   
                    {   
                        //直接按ASCII 规则转换成字符串   
                        builder.Append(Encoding.ASCII.GetString(buf));                       }   
                    //追加的形式添加到文本框末端，并滚动到最后。   
                    this.txGet.AppendText(builder.ToString());   
                    //修改接收计数   
                    labelGetCount.Text = "Get:" + received_count.ToString();                   }             }               finally   
            {   
                Listening = false;//我用完了，ui 可以关闭串口了。   
            }   
        }   
一般二进制格式数据就是这样分析，分析数据长度是否足够，找到数据头，数据长度，校验。但是其他分析方法还有很多，可以结合各自实际情况进行操作。 
4.2 文本协议分析 
文本格式可以直观的定义回车换行是协议的结尾，所以可以省略数据长度，增加协议尾。
即： 协议头 + 数据 + 校验 + 数据尾 。 
文本方式的数据比较容易分析。如果数据缓存，可以考虑用StringBuilder，或是不缓存也可以。文本格式数据大多有换行结尾，稍微修改即可。例如分析常见的NMEA 0183格式的卫星坐标数据GGA。 
$GPGGA,121252.000,3937.3032,N,11611.6046,E,1,05,2.0,45.9,M,-5.7,M,,0000*77  
$              开始 
GPGGA     命令字 
*              结尾 
77            校验 
void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)   
    {   
        if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环   
        try   
        {   
            Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI 的。   
            //文本格式比较简单，可以死等。   
           string line = comm.ReadLine();//这就得到回车换行结尾的了。但是不是从头开始的就要检查了   
//<协议解析>   
            //因为恢复的代码在finally 中。你可以直接的return               if(line[0] != '$') return;//数据不重要，直接丢弃就可以了。              int star = line.IndexOf("*",1);               if(star == -1) return;   
           //根据$后面数据计算异或校验，并和*后面的数字对比，如果不相同，就不必进行分析。  
           //当确定头尾存在，校验正确。就可以分析数据了。   
           //分析数据   
           //略      
           //因为要访问ui 资源，所以需要使用invoke 方式同步ui。   
            this.Invoke((EventHandler)(delegate   
            {   
                //判断是否是显示为16 禁止                   if (checkBoxHexView.Checked)   
                {   
                    //依次的拼接出16 进制字符串   
                    foreach (byte b in buf)   
                    {   
                        builder.Append(b.ToString("X2") + " ");   
                    }                   }                   else   
                {   
                    //直接按ASCII 规则转换成字符串   
                    builder.Append(Encoding.ASCII.GetString(buf));                   }   
                //追加的形式添加到文本框末端，并滚动到最后。   
                this.txGet.AppendText(builder.ToString());   
                //修改接收计数   
                labelGetCount.Text = "Get:" + received_count.ToString();   
            }          }           finally   
        {   
            Listening = false;//我用完了，ui 可以关闭串口了。   
        }   
    }   
5.总结 
   至此，我们已经完成了一个基本上位机的制作。在上位机的编程中，可能会遇见各种各样的BUG，此时，应该在合适的地方设置断点，查看程序运行情况和变量变化状况，找出问题所在。 
