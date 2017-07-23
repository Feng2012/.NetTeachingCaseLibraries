using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("选择运算：1、+ 2、- 3、* 4、/");
                switch (Console.ReadLine())
                {
                    case "1":
                        Plus();
                        break;
                }

            }
        }
        /// <summary>
        /// 加法
        /// </summary>
        private static void Plus()
        {
            var calculator = new Calculator();
            var nums = new List<double>();
            while (true)
            {               
                Console.WriteLine("请输入加数：");
                var num = Convert.ToDouble(Console.ReadLine());
                nums.Add(num);
                Console.WriteLine("结束输入加数请按e，继续请按任意键");
                if(Console.ReadKey(true).KeyChar=='e')
                {
                    break;
                }
            }
            Console.WriteLine($"结果：{calculator.Plus(nums.ToArray())}");
        }
    }
}
