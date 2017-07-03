using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleCodeCount
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义文件类型
            var typeDic = new Dictionary<string, string[]>();
            typeDic.Add("1", new string[] { ".cs" });
            typeDic.Add("2", new string[] { ".js" });
            typeDic.Add("3", new string[] { ".htm", "html", ".cshtml" });

            Console.WriteLine("请选择查检代码的类型：");
            Console.WriteLine("1、csharp代码  2、js代码  3、html代码");
            var no = Console.ReadLine();

            Console.WriteLine("请输入文件路径：");
            var path = Console.ReadLine();
            //调用递归方法
            var count = GetCodeCount(path, typeDic[no]);
            Console.WriteLine($"共查询到{count}行代码！");
        }
        /// <summary>
        /// 查询一路径下的代码行数
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="typeStrs">查询类型扩展名数组</param>
        /// <returns></returns>
        static int GetCodeCount(string path, string[] typeStrs)
        {
            var count = 0;
            //查询该路径下的所有文件
            foreach (var file in Directory.GetFiles(path))
            {
                if (typeStrs.Contains(Path.GetExtension(file).ToLower()))
                {
                    count += File.ReadAllLines(file).Length;
                }
            }//查询该路径下的所有文件夹
            foreach (var dic in Directory.GetDirectories(path))
            {
                //递归代码行数
                count += GetCodeCount(dic, typeStrs);
            }
            return count;
        }
    }
}
