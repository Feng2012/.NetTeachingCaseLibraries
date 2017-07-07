using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleReader
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadBooks();
        }
        /// <summary>
        /// 加载书
        /// </summary>
        static void LoadBooks()
        {
            var path =Directory.GetCurrentDirectory()+@"/books";
            var sn = 1;
            var books = Directory.GetFiles(path);
            //遍历当前路径下的所有图书
            foreach (var bookFile in books)
            {
                Console.WriteLine($"{sn}、{Path.GetFileName(bookFile)}");
            }
            //选择书籍
            if (books.Length > 0)
            {
                Console.WriteLine("请选择书阅读书籍序号：");
                var selectSn = Console.ReadLine();
                var index = 0;
                if (int.TryParse(selectSn, out index))
                {
                    var bookFile = books[index - 1];
                    ReadBook(bookFile);
                }
            }
            else 
            {
                Console.WriteLine("查询不到Books下有书籍！");
            }
        }
        /// <summary>
        /// 读书
        /// </summary>
        /// <param name="filePath">书的路径</param>
        static void ReadBook(string filePath)
        {
            //加载书的内容
            var bookRows = File.ReadAllLines(filePath);
            //设计vbs脚本路径
            var file = Directory.GetCurrentDirectory() + "/speak.vbs";
            foreach (var words in bookRows)
            {
                //创建 vbs脚本
                var content = $"CreateObject(\"SAPI.SpVoice\").Speak \"{words}\"";
                File.WriteAllText(file, content,Encoding.Default);
                //开始阅读
                Process.Start(file);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(words);
                Console.WriteLine("---------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("下一段请按任意键，退出请按e");
                Console.ResetColor();
                if(Console.ReadKey(true).KeyChar=='e')
                {
                    break;
                }
            }
        }
    }
}
