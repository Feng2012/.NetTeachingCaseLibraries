using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Configuration;
using System.Net;
using System.Threading;
using Common;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
namespace Server
{
    class Program
    {
        /// <summary>
        /// 存放用户连接的集合
        /// </summary>
        static Dictionary<string, NetworkStream> userConnects;
        /// <summary>
        /// 存放用户名和用户密码的集合
        /// </summary>
        static Dictionary<string, string> users;
        static void Main(string[] args)
        {
            //加载用户信息
            LoadUsers();
            //实例化用户连接集合
            userConnects = new Dictionary<string, NetworkStream>();
            //建立客户端监听程序
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            var listener = new TcpListener(IPAddress.Parse(hostname), port);
            //开始监听
            listener.Start();
            Console.WriteLine("服务端启动！");
            while (true)
            {
                //获取客户商连接
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}接到一个客户端连接！{client.Client.Handle}");
                //开始一个线程
                new Thread(AcceptPackage).Start(client.GetStream());
            }

        }
        /// <summary>
        /// 加载用户列表
        /// </summary>
        static void LoadUsers()
        {
            users = new Dictionary<string, string>();
            users.Add("aaa", "111");
            users.Add("bbb", "222");
        }
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="obj"></param>
        static void HandleLoginPackage(NetworkStream stream, LoginPackage loginPackage)
        {
            var loginResultPackage = new LoginResultPackage();
            //验证用帐号和密码,组织正确或错误报文并返回
            if (users.Keys.Contains(loginPackage.Account)&& users[loginPackage.Account] == loginPackage.Password)
            {
                loginResultPackage.Result = true;
                loginResultPackage.Frinds = userConnects.Keys.ToArray();
                userConnects.Add(loginPackage.Account, stream);
            }
            else
            {
                loginResultPackage.Result = false;
                loginResultPackage.Message = "用户名或密码错误！";
            }
            var formater = new BinaryFormatter();
            formater.Serialize(stream, loginResultPackage);
        }
        /// <summary>
        /// 处理消息报文
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="messagePackage"></param>
        static void HandleMessagePackage(NetworkStream stream, MessagePackage messagePackage)
        {
            var formater = new BinaryFormatter();
            //判断消息的接收者是否在连接队列中
            if (userConnects.Keys.Contains(messagePackage.Accepter))
            {
                var acceptStream = userConnects[messagePackage.Accepter];
                formater.Serialize(acceptStream, messagePackage);
            }
            else
            {
                formater.Serialize(stream, new MessagePackage { Accepter = messagePackage.Sender, Sender = "服务器", SendTime = DateTime.Now, Content = $"消息发送不到{messagePackage.Accepter}，请确定接收者是否正确！" });
            }
        }
        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="stream">网络流</param>
        static void AcceptPackage(object obj)
        {
            var stream = obj as NetworkStream;
            //格式化器
            var formater = new BinaryFormatter();
            try
            {
                while (true)
                {
                    var package = formater.Deserialize(stream) as Package;
                    Console.WriteLine($@"收到一个{package.PackageType}报文:
{package}");
                    //根据报文类型确定处理方式
                    switch (package.PackageType)
                    {
                        case PackageType.Message:
                            HandleMessagePackage(stream, package as MessagePackage);
                            break;

                        case PackageType.Login:
                            HandleLoginPackage(stream, package as LoginPackage);
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

    }
}
