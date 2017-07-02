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
            Start();
        }
        static void Start()
        {
            while (true)
            {
                Console.Clear();
                //上货
                var goodses = Restock();
                //显示商品
                ShowGoodses(goodses);
                //处理结果
                var result = false;
                //编号
                var no = 0;
                //选择商品
                Goods selectGoods = null;
                //商品序号输入验证
                do
                {
                    Console.WriteLine("请选择购买的商品编号：");
                    var noStr = Console.ReadLine();
                    //偿试转换商品编号，查询是否有效
                    result = int.TryParse(noStr, out no);
                    if (!result)
                    {
                        Console.WriteLine("请输入有效编号！");
                        continue;
                    }
                    //按编号查询商品
                    foreach (var goods in goodses)
                    {
                        if (goods.No == no)
                        {
                            selectGoods = goods;
                        }
                    }
                    //查询是否有此编号商品
                    if(selectGoods==null)
                    {
                        result = false;
                    }
                } while (!result);
               
                //商品数量输入验证
                var quantity = 0;
                do
                {

                    Console.WriteLine("请选择购买数量：");
                    var quantityStr = Console.ReadLine();
                    //偿试转换数量
                    result = int.TryParse(quantityStr, out quantity);
                    if (!result)
                    {
                        Console.WriteLine("请输入有效数量！");
                        continue;
                    }
                    //判断输入数据是否小于商品数实际数据
                    if (selectGoods.Quantity < quantity)
                    {
                        Console.WriteLine("输入的数据大于现有数据！");
                        result=false;
                    }

                } while (!result);

                //应付金额
                decimal payable = selectGoods.Price * quantity;
                //已付金额
                decimal pay = 0;
                do
                {
                    //提示输入金额
                    Console.WriteLine($"请支付{payable - pay}元：");
                    var payStr = Console.ReadLine();
                    var payNow = 0m;
                    //转换金额
                    result = decimal.TryParse(payStr, out payNow);
                    if (!result)
                    {
                        Console.WriteLine("请输入有效金额！");
                        continue;
                    }
                    pay += payNow;
                    //判断应付是否小于等于已付金额
                    if (pay < payable)
                    {
                        result = false;
                    }

                } while (!result);
                //找零
                if(payable<pay)
                {
                    Console.WriteLine($"找零{pay-payable}");
                  
                }
                Console.WriteLine("欢迎下次使用！");

                System.Threading.Thread.Sleep(3000);

            }
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
            Console.WriteLine("************************************************");
            foreach (var goods in goodses)
            {
                Console.WriteLine(goods);
            }
            Console.WriteLine("************************************************");
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
