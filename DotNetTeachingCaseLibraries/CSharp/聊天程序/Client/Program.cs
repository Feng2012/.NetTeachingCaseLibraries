using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Common;

namespace Client
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Start();        
        }
        /// <summary>
        /// 开始客户商连接
        /// </summary>
        static void Start()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            var client = new TcpClient(hostname, port);
            var stream = client.GetStream();
            //登录
            Login(stream);
        }
        /// <summary>
        /// 网络登录
        /// </summary>
        /// <param name="stream">连接网络流</param>
        static void Login(NetworkStream stream)
        {
            var formater = new BinaryFormatter();

            Console.Write("帐号：");
            var account = Console.ReadLine();
            Console.Write("密码：");
            var password = Console.ReadLine();
            //组织登录报文
            var loginPackage = new LoginPackage { Account = account, Password = password };
            //发送登录报文
            formater.Serialize(stream, loginPackage);
            //接收登录报文返回织
            var loginResultPackage = formater.Deserialize(stream) as LoginResultPackage;
            //判断登结结果
            if (loginResultPackage.Result)
            {
                Console.WriteLine("登录成功!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*******我的好友******");       
                foreach (var friend in loginResultPackage.Frinds)
                {
                    Console.WriteLine("帐户："+friend);
                }
                Console.WriteLine("*******我的好友******");
                Console.ResetColor();
                //读的代码
                new Thread(ReadMessage).Start(stream);
                //开始写线程
                WriteMessage(stream,account);
            }
            else
            {
                //登录不成功可以再次登录
                Console.WriteLine(loginResultPackage.Message);
                Console.WriteLine("退出请按e，再次登录请按任意键！");
                if(Console.ReadKey().KeyChar!='e')
                {
                    Login(stream);
                }
            }

        }

        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="stream">网络流</param>
        static void ReadMessage(object obj)
        {
            try
            {
                var stream = obj as NetworkStream;
                var formater = new BinaryFormatter();
                while (true)
                {
                    var package = formater.Deserialize(stream) as Package;
                    Package acceptPackage = null;
                    switch (package.PackageType)
                    {
                        case PackageType.Message:
                            acceptPackage = package as MessagePackage;
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(acceptPackage);
                    Console.ResetColor();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
        /// <summary>
        /// 写网络流
        /// </summary>
        /// <param name="obj">网络流</param>
        static void WriteMessage(NetworkStream stream,string account)
        {
            try
            {
                var formater = new BinaryFormatter();
                while (true)
                {
                    Console.WriteLine("请输入朋友名字：");
                    var friendName = Console.ReadLine();
                    Console.WriteLine("输入发送内容：");
                    var content = Console.ReadLine();
                    var messagePackage = new MessagePackage { Content = content, Sender = account, SendTime = DateTime.Now, Accepter = friendName };
                    formater.Serialize(stream, messagePackage);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($@"-------------------发送到的消息-开始--------------------
我 :{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
{content}
-------------------发送到的消息-开始--------------------");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
