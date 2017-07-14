using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Package;

namespace Server
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //设置跨线程访问控件
            CheckForIllegalCrossThreadCalls = false;
        }
        //网络流
        NetworkStream _stream;
        private void frmMain_Load(object sender, EventArgs e)
        {
            //定义IP地址
            var ip = IPAddress.Parse("127.0.0.1");
            //监听器定义
            var server = new TcpListener(ip, 8888);
            //开始监听
            server.Start();
            //接收客户端连接
            var client = server.AcceptTcpClient();
            //获取客户端网络流
            _stream = client.GetStream();
            //启动读流信息线程
            new Thread(Read).Start(_stream);
        }
        /// <summary>
        /// 接收信息
        /// </summary>
        /// <param name="obj"></param>
        private void Read(object obj)
        {
            var stream = obj as NetworkStream;
            //定义格式化器
            var formater = new BinaryFormatter();
            while (true)
            {
                try
                {
                    //反序列化包文
                    var package = formater.Deserialize(stream) as Package.Package;
                    //判断报文的类型，进行相应的处理
                    switch (package.PackageType)
                    {
                        case Package.PackageType.Text:
                            HandleText(package as TextPackage);
                            break;
                        case PackageType.Image:
                            HandleImage(package as ImagePackage);
                            break;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
        /// <summary>
        /// 处理图片报文
        /// </summary>
        /// <param name="imagePackage"></param>
        private void HandleImage(ImagePackage imagePackage)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 处理文本报文
        /// </summary>
        /// <param name="textPackage"></param>
        private void HandleText(TextPackage textPackage)
        {
            txbHis.Text += "对方说：" + textPackage.Message + "\r\n";
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //组织发送文本报文
            var textPackage = new TextPackage() { Message = txbSend.Text };
            //定义格式化器
            var formater = new BinaryFormatter();
            //序列化到网络流，即发送信息
            formater.Serialize(_stream, textPackage);
            //历史信息显示
            txbHis.Text += "自己说：" + txbSend.Text + "\r\n";
            //清空发送文本框
            txbSend.Clear();
        }
    }
}
