using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            var path = "~/books";
            var sn = 1;
            var books = Directory.GetFiles(path);
            //遍历当前路径下的所有图书
            foreach (var bookFile in books)
            {
                Console.WriteLine($"{sn}、{Path.GetFileName(bookFile)}");
            }
            Console.WriteLine("请选择书阅读书籍序号：");
            var selectSn = Console.ReadLine();
            var index = 0;
            if (int.TryParse(selectSn, out index))
            {
                var bookFile = books[index - 1];           

            }
        }

        static void LoadBook(string filePath)
        {
            var bookRows = File.ReadAllLines(filePath);

        }
    }
}
