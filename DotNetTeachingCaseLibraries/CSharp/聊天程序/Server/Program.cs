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
        static Dictionary<string, NetworkStream> userConnects;
        static Dictionary<string, string> users;
        static void Main(string[] args)
        {
            LoadUsers();
            userConnects = new Dictionary<string, NetworkStream>();
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            var listener = new TcpListener(IPAddress.Parse(hostname), port);
            listener.Start();
            Console.WriteLine("服务端启动！");
            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}接到一个客户端连接！{client.Client.Handle}");
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
            //验证用帐号和密码
            if (users[loginPackage.Account]== loginPackage.Password)
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
        static void HandleMessagePackage(NetworkStream stream,MessagePackage messagePackage)
        {           
            var acceptStream = userConnects[messagePackage.Accepter];
            var formater = new BinaryFormatter();
            formater.Serialize(acceptStream, messagePackage);
        }
        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="stream">网络流</param>
        static void AcceptPackage(object obj)
        {
            var stream = obj as NetworkStream;
            var formater = new BinaryFormatter();
            try
            {
                while (true)
                {
                    var package = formater.Deserialize(stream) as Package;
                    Console.WriteLine($"收到一个报文:{package.PackageType}");
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
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        } 

    }
}
