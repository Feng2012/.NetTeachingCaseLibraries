using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteDiary();
            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        static void WriteDiary()
        {
            var diary = new Diary();
            Console.WriteLine("请输入日期，如果当天请按回车键 ");
            var createTime = DateTime.Now;
            var createTimeStr = Console.ReadLine();
            
            while (createTimeStr!=""&&!DateTime.TryParse(createTimeStr, out createTime))
            {
                Console.WriteLine("输入的日期格式有误,请重新输入，格式为：2017-02-23");
            }
            diary.CreateTime = createTime;

            Console.WriteLine(diary.CreateTime);
        }
    }
}
