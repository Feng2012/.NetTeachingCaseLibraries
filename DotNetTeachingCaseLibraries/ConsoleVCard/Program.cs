using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVCard
{
    class Program
    {
        static void Main(string[] args)
        {
         
            CardManage();
        }
        static int GetLength(string contant)
        {
            return Encoding.Default.GetByteCount(contant);
        }
        static void CardManage()
        {
            var cards = new List<Card>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*************************************************************");
                Console.WriteLine("1、添加名片  2、修改名片  3、删除名称  4、按姓名或公司查询  5、按联系方式查询");
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
                        break;
                    case "5":
                        QueryByContact(cards);
                        break;
                    default:
                        Console.WriteLine("输入的编号有误！");
                        break;
                }
            }
        }

        private static void QueryByContact(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static void QueryByName(List<Card> cards)
        {
            foreach(var card in cards)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine("继结请按任意键!");
            Console.ReadKey(true);        }

        private static void RemoveCard(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static void ModifyCard(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static void AddCard(List<Card> cards)
        {
            var card = new Card();
            Console.WriteLine("请输入姓名：");
            card.Name = Console.ReadLine();
            Console.WriteLine("请输入公司：");
            card.Company = Console.ReadLine();
            Console.WriteLine("请输入职位：");
            card.Position = Console.ReadLine();
            Console.WriteLine("请输入地址：");
            card.Address = Console.ReadLine();

            do
            {
                AddContact(card);
                Console.WriteLine("退出请按E,继续请按其他任意键!");
                if (Console.ReadLine() == "e")
                {
                    break;
                }

            } while (true);
            cards.Add(card);
            Console.WriteLine("添加成功！");
        }

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
