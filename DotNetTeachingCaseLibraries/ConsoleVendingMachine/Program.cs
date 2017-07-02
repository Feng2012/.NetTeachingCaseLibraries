using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        static void Start()
        {
            var goodses = Restock();
            ShowGoodses(goodses);
        }

        /// <summary>
        ///  上货
        /// </summary>
        /// <returns></returns>
        static List<Goods> Restock()
        {
            var goodses = new List<Goods>();
            goodses.Add(new Goods() { No = 1, Name = "恒大冰泉", Price = 5, Quantity = 10 });
            goodses.Add(new Goods() { No = 2, Name = "可乐", Price = 3, Quantity = 10 });
            goodses.Add(new Goods() { No = 3, Name = "果粒橙", Price = 3, Quantity = 10 });
            goodses.Add(new Goods() { No = 4, Name = "绿茶", Price = 3.5m, Quantity = 10 });
            goodses.Add(new Goods() { No = 5, Name = "农夫山泉", Price = 1.5m, Quantity = 10 });
            return goodses;
        }
        /// <summary>
        /// 显示商品
        /// </summary>
        /// <param name="goodses"></param>
        static void ShowGoodses(List<Goods> goodses)
        {
            foreach(var goods in goodses)
            {
                Console.WriteLine(goods);
            }
        }
    }

    /// <summary>
    /// 商品
    /// </summary>
    class Goods
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int No
        { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price
        { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        { get; set; }
        /// <summary>
        /// 重写父类string,显示商品信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"编号：{No}  名称：{Name}  单价：{Price}  数量：{Quantity}";
        }
    }
}
