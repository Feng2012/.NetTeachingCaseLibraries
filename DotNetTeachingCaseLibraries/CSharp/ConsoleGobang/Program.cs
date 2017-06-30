using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGobang
{
    class Program
    {
        static void Main(string[] args)
        {
            //循环每局
            while (true)
            {               
                //开始下五子棋
                PlayChess();
                //一局结束提示是否继续
                Console.WriteLine("按任意键重开始一局，按E键退出程序！");
                if (Console.ReadKey().KeyChar == 'E')
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 下棋方法
        /// </summary>   
        static void PlayChess()
        { 
            //初始化棋盘
            var chessboard = CreateChessboard();
            //轮循标志，双方棋手下棋顺序标志
            var roundMark = true;
            //循环双方走子
            while (true)
            {
                //清屏
                Console.Clear();
                //显示当前棋盘布局
                ShowChessboard(chessboard);
                Console.WriteLine("请输入落子坐标（如：4,5）：");
                //接收落子坐标
                var point = Console.ReadLine();
                //把x,y切到数组里
                var xyArr = point.Split(',', '，');
                //判断x是否为整行
                int x;
                if (!int.TryParse(xyArr[0], out x))
                {
                    Console.WriteLine("你的输入有误，请重新输入！");
                    System.Threading.Thread.Sleep(2000);
                    continue;
                }
                //判断y是否为整行
                int y;
                if (!int.TryParse(xyArr[1], out y))
                {
                    Console.WriteLine("你的输入有误，请重新输入！");
                    System.Threading.Thread.Sleep(2000);
                    continue;
                }
                //判断x,y是否越界，判断x,y坐标处是否为可落子坐标
                if (x > 0 && x < chessboard.GetLength(0) && y > 0 && y < chessboard.GetLength(1) && chessboard[x, y].IsEmptyChess())
                {
                    //根据roundMark落子
                    chessboard[x, y] = roundMark ? "●" : "○";
                    //落子成功后反转轮循标志
                    roundMark = !roundMark;
                    //判断胜否
                    if (IsWinLose(x, y, chessboard))
                    {
                        Console.WriteLine($"{chessboard[x, y]}胜！");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("你的输入有误，请重新输入！");
                    System.Threading.Thread.Sleep(2000);
                    continue;
                }
            }
        }
        /// <summary>
        /// 判断胜负
        /// </summary>
        /// <param name="x">落子x坐标</param>
        /// <param name="y">落子y坐标</param>
        /// <param name="chessboard">棋盘</param>
        /// <returns></returns>
        static bool IsWinLose(int x, int y, string[,] chessboard)
        {
            var chess = chessboard[x, y];
            int count = 1;
            #region  横向判断
            //横向向右判断
            for (int c = y + 1; c < chessboard.GetLength(1); c++)
            {
                //右边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[x, c])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //横向向左判断
            for (int c = y - 1; c > 0; c--)
            {
                //左边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[x, c])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //判断是否超过5个子
            if (count >= 5)
            {
                return true;
            }
            #endregion
            count = 1;
            #region  纵向判断
            //纵向向下判断
            for (int r = x + 1; r < chessboard.GetLength(0); r++)
            {
                //右边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[r, y])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //横向向左判断
            for (int r = x - 1; r > 0; r--)
            {
                //左边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[r, y])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //判断是否超过5个子
            if (count >= 5)
            {
                return true;
            }
            #endregion
            count = 1;
            #region 正斜向判断
            //向右上角
            for (int r = x - 1, c = y + 1; r > 0 && c < chessboard.GetLength(1); r--, c++)
            {
                //右边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[r, c])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //向左下角
            for (int r = x + 1, c = y - 1; r < chessboard.GetLength(0) && c > 0; r++, c--)
            {
                //左边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[r, y])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //判断是否超过5个子
            if (count >= 5)
            {
                return true;
            }
            #endregion           
            count = 1;
            #region 反斜向判断
            //向左上角
            for (int r = x - 1, c = y - 1; r > 0 && c > 0; r--, c--)
            {
                //右边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[r, c])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //向右下角
            for (int r = x + 1, c = y + 1; r < chessboard.GetLength(0) && c < chessboard.GetLength(1); r++, c++)
            {
                //左边的棋子和落子相同，总数加1，不相同跳出循环
                if (chess == chessboard[r, y])
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            //判断是否超过5个子
            if (count >= 5)
            {
                return true;
            }
            #endregion
            return false;
        }

        /// <summary>
        /// 实例化一个空棋盘
        /// </summary>
        /// <returns></returns>
        static string[,] CreateChessboard()
        {
            //赋值所有元素为┼
            var chessboard = new string[25, 25];
            //循环行
            for (int r = 0; r < chessboard.GetLength(0); r++)
            {
                //循环列
                for (int c = 0; c < chessboard.GetLength(1); c++)
                {
                    chessboard[r, c] = "┼";
                }
            }
            //赋值左上角
            chessboard[0, 0] = "┌";
            //赋值右下角
            chessboard[chessboard.GetLength(0) - 1, chessboard.GetLength(1) - 1] = "┘";
            //赋值右上角
            chessboard[0, chessboard.GetLength(1) - 1] = "┐";
            //赋值左下角
            chessboard[chessboard.GetLength(0) - 1, 0] = "└";
            //赋值首行和尾行
            for (int c = 1; c < chessboard.GetLength(1) - 1; c++)
            {
                //赋值首行
                chessboard[0, c] = "┬";
                //赋值尾行
                chessboard[chessboard.GetLength(0) - 1, c] = "┴";
            }
            //赋值首列和尾列
            for (int r = 1; r < chessboard.GetLength(0) - 1; r++)
            {
                //赋值首列
                chessboard[r, 0] = "├";
                //赋值尾列
                chessboard[r, chessboard.GetLength(1) - 1] = "┤";
            }
            return chessboard;
        }
        /// <summary>
        /// 显示空棋盘
        /// </summary>
        /// <param name="chessboard">棋盘二维数组</param>
        static void ShowChessboard(string[,] chessboard)
        {
            #region 显示首行偶数数字
            //开头为数字列空两个半角字符
            Console.Write("  ");
            for (int c = 0; c < chessboard.GetLength(1); c++)
            {
                Console.Write(c % 2 == 0 ? c.ToString().PadLeft(2) : "  ");
            }
            Console.WriteLine();
            #endregion
            #region 输出棋盘和首列尾列偶奇数字
            //循环行和列输出棋盘
            for (int r = 0; r < chessboard.GetLength(0); r++)
            {
                //赋值每行的首列为数字
                Console.Write(r % 2 == 0 ? r.ToString().PadLeft(2) : "  ");
                for (int c = 0; c < chessboard.GetLength(1); c++)
                {
                    Console.Write(chessboard[r, c]);
                }
                //赋值每行的尾列为数字
                Console.Write(r % 2 == 1 ? r.ToString().PadLeft(2) : "  ");
                Console.WriteLine();
            }
            #endregion
            #region 尾行奇数数字
            //开头为数字列空两个半角字符
            Console.Write("  ");
            for (int c = 0; c < chessboard.GetLength(1); c++)
            {
                Console.Write(c % 2 == 1 ? c.ToString().PadLeft(2) : "  ");
            }
            Console.WriteLine();
            #endregion
        }
    }

    /// <summary>
    /// 字符串扩展类
    /// </summary>
    static class StringExtension
    {
        /// <summary>
        /// 判断是否为可落子处
        /// </summary>
        /// <param name="chess"></param>
        /// <returns></returns>
        public static bool IsEmptyChess(this string chess)
        {
            return chess == "┼";
        }
    }   
}
