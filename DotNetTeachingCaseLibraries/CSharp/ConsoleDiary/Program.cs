using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleDiary
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1、查看日记  2、写日志  3、退出");
                switch (Console.ReadLine())
                {
                    case "1":
                        Query();
                        break;
                    case "2":
                        WriteDiary();
                        break;
                    case "3":
                        return;

                }
            }
        }
        /// <summary>
        /// 查询日记
        /// </summary>
        static void Query()
        {
            var diaries = ReadDiaries();

            Console.WriteLine("请输入日期，如果当天请按回车键 ");
            var createTime = DateTime.Now;
            var createTimeStr = Console.ReadLine();
            while (createTimeStr != "" && !DateTime.TryParse(createTimeStr, out createTime))
            {
                Console.WriteLine("输入的日期格式有误,请重新输入，格式为：2017-02-23");
            }

            foreach (var diary in diaries)
            {
                if (diary.CreateTime.ToString("yyyy-MM-dd") == createTime.ToString("yyyy-MM-dd"))
                {
                    Console.WriteLine("===========================================================");
                    Console.WriteLine(diary);
                    Console.WriteLine("===========================================================");
                    break;
                }
            }
            Console.WriteLine("按任意键继续");
            Console.ReadKey(true);
        }
        /// <summary>
        /// 返回中文星期
        /// </summary>
        /// <param name="dayOfWeek">枚举星期</param>
        /// <returns></returns>
        static string GetChineseWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "星期一";
                case DayOfWeek.Tuesday:
                    return "星期二";
                case DayOfWeek.Wednesday:
                    return "星期三";
                case DayOfWeek.Thursday:
                    return "星期四";
                case DayOfWeek.Friday:
                    return "星期五";
                case DayOfWeek.Saturday:
                    return "星期六";
                case DayOfWeek.Sunday:
                    return "星期日";
                default: return null;
            }
        }
        /// <summary>
        /// 写日记
        /// </summary>
        static void WriteDiary()
        {
            var diary = new Diary();
            Console.WriteLine("请输入日期，如果当天请按回车键 ");
            var createTime = DateTime.Now;
            var createTimeStr = Console.ReadLine();

            while (createTimeStr != "" && !DateTime.TryParse(createTimeStr, out createTime))
            {
                Console.WriteLine("输入的日期格式有误,请重新输入，格式为：2017-02-23");
            }
            //日期
            diary.CreateTime = createTime;

            //转换星期
            diary.Week = GetChineseWeek(createTime.DayOfWeek);

            //天气
            Console.WriteLine("请选择天气序号：");
            var weathers = Enum.GetNames(typeof(Weather));
            int sn = 1;
            foreach (var weather in weathers)
            {
                Console.WriteLine($"{sn}、{weather}");
                sn++;
            }
            var snStr = Console.ReadLine();
            uint selectSn = 0;
            while (!uint.TryParse(snStr, out selectSn) && selectSn >= weathers.Length)
            {
                Console.WriteLine("输入的天气格式有误,请重新输入");
                snStr = Console.ReadLine();
            }
            //选择天气
            diary.Weather = (Weather)Enum.Parse(typeof(Weather), weathers[selectSn-1]);

            //内容
            Console.WriteLine("请输入日记内容：");
            diary.Content = Console.ReadLine();
            WriteDiaries(diary);


        }

        /// <summary>
        /// 读取文件中的日志
        /// </summary>
        /// <returns></returns>
        static List<Diary> ReadDiaries()
        {
            var file = System.IO.Directory.GetCurrentDirectory() + "//data.bin";

            if (File.Exists(file))
            {
                var stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                var formatter = new BinaryFormatter();
                var diries = formatter.Deserialize(stream) as List<Diary>;
                stream.Close();
                return diries;
            }
            else
            {
                var stream = new FileStream(file, FileMode.Create, FileAccess.Write);
                var diries = new List<Diary>();
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, diries);
                stream.Close();
                return diries;
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="diary">日记对象</param>
        static void WriteDiaries(Diary diary)
        {
            var file = System.IO.Directory.GetCurrentDirectory() + "//data.bin";
            var diries = ReadDiaries();
            diries.Add(diary);

            var stream = new FileStream(file, FileMode.Create, FileAccess.Write);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, diries);
            stream.Close();
        }
    }
}
