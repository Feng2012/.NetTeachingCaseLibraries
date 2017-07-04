using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Client
{
    class Program
    {
        static string name;
        static void Main(string[] args)
        {
            Console.WriteLine("请输入昵称：");
            name = Console.ReadLine();

        }

        static void Start()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            var client = new TcpClient(hostname, port);
            var stream = client.GetStream();
            //开始写线程
            new Thread(WriteMessage).Start(stream);
            //读的代码
            ReadMessage(stream);


        }
        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="stream">网络流</param>
        static void ReadMessage(NetworkStream stream)
        {
            while (true)
            {
                var reader = new StreamReader(stream);
                var content = reader.ReadLine();
                Console.WriteLine(content);
            }
        }
        /// <summary>
        /// 写网络流
        /// </summary>
        /// <param name="obj">网络流</param>
        static void WriteMessage(object obj)
        {
            var stream = obj as NetworkStream;
            while (true)
            {
                var writer = new StreamWriter(stream);
                var content = $"{name}:{Console.ReadLine()}";
                writer.WriteLine(content);
                Console.WriteLine(content);
            }

        }
    }
}
