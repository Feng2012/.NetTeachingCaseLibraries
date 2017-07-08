using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace DistributedLog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("writelog")]
        public IActionResult Write(string sendMessage)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //创建一个名叫"hello"的消息队列
                    channel.QueueDeclare(queue: "hello",
       durable: false,
       exclusive: false,
       autoDelete: false,
       arguments: null);

                    var message = sendMessage;
                    var body = Encoding.UTF8.GetBytes(message);

                    //向该消息队列发送消息message
                    channel.BasicPublish(exchange: "",
       routingKey: "hello",
       basicProperties: null,
       body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }

            }
            return new JsonResult(true);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
