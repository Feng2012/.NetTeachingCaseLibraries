using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace DistributedLogWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //创建一个名为"log"的队列，防止producer端没有创建该队列
                    channel.QueueDeclare(queue: "log",
           durable: false,
           exclusive: false,
           autoDelete: false,
           arguments: null);

                    //回调，当consumer收到消息后会执行该函数
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (sender, e) =>
                    {
                        var body = e.Body;
                        var message = Encoding.UTF8.GetString(body);
                        //这里完成向数据库写日志
                        Console.WriteLine("收到： {0}", message);
                    };

                    //消费队列"log"中的消息
                    channel.BasicConsume(queue: "log",noAck: true,consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}