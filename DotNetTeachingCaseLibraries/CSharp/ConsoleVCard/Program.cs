using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVCardManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CardManage();
        }    
        static void CardManage()
        {
            var cards = new List<Card>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*************************************************************");
                Console.WriteLine("1、添加名片  2、修改名片  3、删除名称  4、按姓名或公司查询  \r\n5、全部查询");
                Console.WriteLine("*************************************************************");
                var no = Console.ReadLine();
                switch (no)
                {
                    case "1":
                        AddCard(cards);
                        break;
                    case "2":
                        ModifyCard(cards);
                        break;
                    case "3":
                        RemoveCard(cards);
                        break;
                    case "4":
                        QueryByName(cards);
                        Console.WriteLine("继结请按任意键!");
                        Console.ReadKey(true);
                        break;
                    case "5":
                        QueryAll(cards);
                        Console.WriteLine("继结请按任意键!");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("输入的编号有误！");
                        break;
                }
            }
        }
        /// <summary>
        /// 全部查询
        /// </summary>
        /// <param name="cards">名称集合</param>
        private static void QueryAll(List<Card> cards)
        {
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }
        /// <summary>
        /// 按姓名或公司名查询名片
        /// </summary>
        /// <param name="cards">名称集合</param>
        private static void QueryByName(List<Card> cards)
        {
            Console.WriteLine("请入姓名或公司名称：");
            var name = Console.ReadLine();
            foreach (var card in cards)
            {
                if (card.Name == name || card.Company == name)
                {
                    Console.WriteLine(card);
                }
            }
        }
        /// <summary>
        /// 称动名称
        /// </summary>
        /// <param name="cards">名片集合</param>
        private static void RemoveCard(List<Card> cards)
        {
            QueryByName(cards);
            Console.WriteLine("请选择名片编号：");
            var no = 0;
            if (int.TryParse(Console.ReadLine(), out no))
            {
                var card = GetCard(no, cards);
                if (card != null)
                {
                    cards.Remove(card);
                    Console.WriteLine("删除名片成功！");
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"找不到编号为：{no}的名片！");
                }
            }
        }
        /// <summary>
        /// 修改名片
        /// </summary>
        /// <param name="cards">名片集合</param>
        private static void ModifyCard(List<Card> cards)
        {
            //按姓名或公司名查询名片
            QueryByName(cards);
            Console.WriteLine("请选择名片编号：");
            var no = 0;
            if (int.TryParse(Console.ReadLine(), out no))
            {
                //按编号查询名片
                var card = GetCard(no, cards);
                if (card != null)
                {

                    Console.WriteLine("是否修改姓名？是请按y，否请按任意键");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("请输入姓名：");
                        card.Name = Console.ReadLine();
                    }
                    Console.WriteLine("是否修改公司？是请按y，否请按任意键");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("请输入公司：");
                        card.Company = Console.ReadLine();
                    }
                    Console.WriteLine("是否修改职位？是请按y，否请按任意键");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("请输入职位：");
                        card.Position = Console.ReadLine();
                    }
                    Console.WriteLine("是否修改地址？是请按y，否请按任意键");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("请输入地址：");
                        card.Address = Console.ReadLine();
                    }
                    //修改联系方式
                    do
                    {
                        Console.WriteLine("1、添加联系方式  2、删除联系方式  3、退出");
                        var mark = Console.ReadLine();
                        if(mark=="3")
                        {
                            break;
                        }
                        switch (mark)
                        {
                            case "1":
                                AddContact(card);
                                break;
                            case "2":
                                RemoveContact(card);
                                break;                  
                        }
                    } while (true);


                    Console.WriteLine("修改名片成功！");
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"找不到编号为：{no}的名片！");
                }
            }
        }
        /// <summary>
        /// 按编号查询名称
        /// </summary>
        /// <param name="no">编号</param>
        /// <param name="cards">名片集合</param>
        /// <returns></returns>
        static Card GetCard(int no, List<Card> cards)
        {
            foreach (var card in cards)
            {
                if (card.No == no)
                {
                    return card;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <param name="cards">名片集合</param>
        /// <returns></returns>
        static int GetMaxNo(List<Card> cards)
        {
            var no = 0;
            foreach (var card in cards)
            {
                if (no < card.No)
                {
                    no = card.No;
                }
            }
            return no + 1;
        }
        /// <summary>
        /// 添加名称
        /// </summary>
        /// <param name="cards">名称集合</param>
        private static void AddCard(List<Card> cards)
        {
            var card = new Card();
            card.No = GetMaxNo(cards);
            Console.WriteLine("请输入姓名：");
            card.Name = Console.ReadLine();
            Console.WriteLine("请输入公司：");
            card.Company = Console.ReadLine();
            Console.WriteLine("请输入职位：");
            card.Position = Console.ReadLine();
            Console.WriteLine("请输入地址：");
            card.Address = Console.ReadLine();
            //循环添加名片上的联系方式，可能有多个联系方式
            do
            {
                AddContact(card);
                Console.WriteLine("退出请按e,继续请按其他任意键!");
                var key = Console.ReadLine();
                if (key == "e" || key == "E")
                {
                    break;
                }

            } while (true);
            cards.Add(card);
            Console.WriteLine("添加成功！");
        }

        /// <summary>
        /// 移除联系方式
        /// </summary>
        /// <param name="card"></param>
        static void RemoveContact(Card card)
        {
            for (int i = 0; i < card.Contacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}、{card.Contacts[i].ContactType}:{card.Contacts[i].ContactNo}");

            }
            Console.WriteLine("请选择要删除的序号：");
            var sn = 0;
            if (int.TryParse(Console.ReadLine(), out sn) && sn > -1 && sn < card.Contacts.Count)
            {
                card.Contacts.RemoveAt(sn - 1);
            }
            else
            {
                Console.WriteLine("序号输入有误！");
            }
        }

        /// <summary>
        /// 添加联系方式
        /// </summary>
        /// <param name="card"></param>
        static void AddContact(Card card)
        {
            //选择输入类型
            Console.WriteLine("请选择添加联系方式类型：1、电话  2、QQ  3、手机");
            var no = Console.ReadLine();
            Contact contact = null;
            switch (no)
            {
                case "1":
                    contact = new Telephone();
                    break;
                case "2":
                    contact = new QQ();
                    break;
                case "3":
                    contact = new Mobile();
                    break;
                default:
                    Console.WriteLine("输入的联系方式类型错误");
                    break;
            }
            //输入号码，并验证
            if (contact != null)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"请输入{contact.ContactType}号码：");
                        contact.ContactNo = Console.ReadLine();
                        card.Contacts.Add(contact);
                        break;
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                }
            }
        }
    }
}
