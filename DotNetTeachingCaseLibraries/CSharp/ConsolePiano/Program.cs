using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ConsolePiano
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "控制台琴";    
            while (true)
            {
                //捕获异常不作处理
                try
                {
                    var key = Console.ReadKey(true).KeyChar.ToString();
                    //播放音乐
                    Play(key);
                    //显示按键
                    ShowKey(key);
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 显示按键
        /// </summary>
        /// <param name="key"></param>
        static void ShowKey(string key)
        {
            int number;
            //判断按键是否为整数并在0到8之间
            if (int.TryParse(key, out number) && number < 8 && number > 0)
            {
                //生成一个长空格字符
                var content = "".PadLeft(number*2+10);  
                //设定背景色
                Console.BackgroundColor = (ConsoleColor)(number * 2);
                //输出空格内容
                Console.Write(content);
                //重置控制台背景色
                Console.ResetColor();
                //输出按键
                Console.WriteLine(number);
            }
        }
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="key">按键</param>
        static void Play(string key)
        {
            //得到当前exe所在路径
            var path = Environment.CurrentDirectory;
            //实例化播放器
            var player = new WMPLib.WindowsMediaPlayer();
            
            //设定播放器播放音乐文件，分别为1到7的文件名，扩展名为.wma
            player.URL = $"{path}/media/{key}.wma";
           
            //获取音乐文件时长（秒）
            Console.WriteLine(player.newMedia($"{path}/media/{key}.wma").duration);

           
        }
    }
}
