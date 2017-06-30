using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "XXX系统";
            Console.WriteLine("*********欢迎使用XXX系统**********");
            var result=Login();            
            Console.WriteLine("**********************************");
            //三元运算符判断用户是否登录成功
            Console.WriteLine(result ? "登录成功" : "登录失败");
            Console.Read();
        }
        /// <summary>
        /// 登录方法
        /// </summary>
        /// <returns></returns>
        static bool Login()
        {
            //三次密码循环器
            for (int i = 1; i < 4; i++)
            {         
                Console.Write("用户名：");
                var username = Console.ReadLine();
                Console.Write("密　码：");
                var password = GetPassword();
                //空换行，为显示美化换行
                Console.WriteLine();          
                if (username == "aaa" && password == "bbb")
                {
                    return true;
                }
                else
                {
                    //第三次登录后不提示剩余次数
                    if (i < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"用户名或密码错误，请重新输入，你还有{3 - i}次输入机会！");
                        Console.ResetColor();
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 获取用户输入密码
        /// </summary>
        /// <returns></returns>
        static string GetPassword()
        {
            //定义空密码变量
            var password = "";
            //不确定用户密码长度，用死循环来接受用户输入，当按下回车键时跳出死循环
            while (true)
            {
                //用Console.ReadKey来接收用户输入的单字符，并不显示用户输入，方便后台用*号掩掉用户输入的真实值
                var inChar = Console.ReadKey(true).KeyChar;
                //判断是否结果输入
                if (inChar == 13)
                {
                    break;
                }
                else
                {
                    //非回车字符拼接
                    password += inChar;
                    //用*掩掉用户输入的值
                    Console.Write("*");
                }
            }
            return password;
        }
    }
}
