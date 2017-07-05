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
        static string name;
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            var client = new TcpClient(hostname, port);
            var stream = client.GetStream();
            Login(stream);
        }
        static void Login(NetworkStream stream)
        {
            var formater = new BinaryFormatter();

            Console.Write("帐号：");
            var account = Console.ReadLine();
            Console.Write("密码：");
            var password = Console.ReadLine();
            var loginPackage = new LoginPackage { Account = account, Password = password };
            formater.Serialize(stream, loginPackage);

            var loginResultPackage = formater.Deserialize(stream) as LoginResultPackage;
            if (loginResultPackage.Result)
            {
                Console.WriteLine("登录成功!");
                Console.WriteLine("我的朋友");
                foreach(var friend in loginResultPackage.Frinds)
                {
                    Console.WriteLine(friend);
                }
                //读的代码
                new Thread(ReadMessage).Start(stream);
                //开始写线程
                WriteMessage(stream);
            }
            else
            {
                Console.WriteLine(loginResultPackage.Message);
            }

        }

        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="stream">网络流</param>
        static void ReadMessage(object obj)
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
                Console.WriteLine(acceptPackage);
            }
        }
        /// <summary>
        /// 写网络流
        /// </summary>
        /// <param name="obj">网络流</param>
        static void WriteMessage(NetworkStream stream)
        {
            var formater = new BinaryFormatter();
            while (true)
            {
                Console.WriteLine("请输入朋友名字：");
                var friendName = Console.ReadLine();
                Console.WriteLine("输入发送内容：");
                var content = Console.ReadLine();
                var messagePackage = new MessagePackage { Content = content, Sender = name, SendTime = DateTime.Now, Accepter = friendName };
                formater.Serialize(stream, messagePackage);
                Console.WriteLine(content);
            }
        }
    }
}
