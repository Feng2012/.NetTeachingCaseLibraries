using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGreedySnake
{
    /// <summary>
    /// 坐标点
    /// </summary>
    class Point
    {
        /// <summary>
        /// 行
        /// </summary>
        public int R { get; set; }
        /// <summary>
        /// 列
        /// </summary>
        public int C { get; set; }
    }
    class Program
    {
        /// <summary>
        /// 全局方向变量
        /// </summary>
        static char mark = 'w';
        /// <summary>
        /// 全豆坐标
        /// </summary>
        static Point bean;
        static void Main(string[] args)
        {
            new Thread(Go).Start();
            //控制蛇的方向
            while (true)
            {
                //判断方向按键是否与运行方向相向，只有90度方向起作用
                var newmark = Console.ReadKey(true).KeyChar;
                if (((mark == 'w' || mark == 's') && (newmark == 'a' || newmark == 'd')) || ((newmark == 'w' || newmark == 's') && (mark == 'a' || mark == 'd')))
                {
                    mark = newmark;
                }
            }
        }
        /// <summary>
        /// 获取随机的豆豆
        /// </summary>
        /// <param name="board">底板</param>
        /// <returns></returns>
        static Point GetBean(string[,] board)
        {
            var random = new Random();
            var r = random.Next(1, board.GetLength(0) - 1);
            var c = random.Next(1, board.GetLength(1) - 1);
            return new Point() { R = r, C = c };
        }
        /// <summary>
        /// 蛇自动走步
        /// </summary>
        static void Go()
        {
            var snake = new List<Point>();

            snake.Add(new Point { C = 12, R = 21 });
            snake.Add(new Point { C = 12, R = 22 });
            snake.Add(new Point { C = 12, R = 23 });
            while (true)
            {
                //创建底板和蛇数组
                var board = CreateBoard(snake);

                //显示
                ShowBoard(board);
                var endPoint = new Point() { R = snake[snake.Count - 1].R, C = snake[snake.Count - 1].C };
                //把蛇除头外的其他坐标前移一个坐标
                for (int i = snake.Count - 1; i > 0; i--)
                {
                    snake[i].R = snake[i - 1].R;
                    snake[i].C = snake[i - 1].C;
                }
                //按运行方向赋值新坐标点
                switch (mark)
                {
                    case 's':
                        snake[0].R++;
                        if (snake[0].R > board.GetLength(0) - 2)
                        {
                            snake[0].R = 1;
                        }
                        break;
                    case 'w':
                        snake[0].R--;
                        if (snake[0].R < 1)
                        {
                            snake[0].R = board.GetLength(0) - 2;
                        }
                        break;
                    case 'a':
                        snake[0].C--;
                        if (snake[0].C < 1)
                        {
                            snake[0].C = board.GetLength(1) - 2;
                        }
                        break;
                    case 'd':
                        snake[0].C++;
                        if (snake[0].C > board.GetLength(1) - 2)
                        {
                            snake[0].C = 1;
                        }
                        break;
                }
                //判断蛇是否撞到自己
                if (IsBumpSelf(snake))
                {

                    Console.WriteLine($"游戏结束！蛇长{snake.Count}");
                    break;
                }
                //判断是否吃到豆
                var result = IsEatBean(snake[0]);
                if (result)
                {
                    //吃到豆后蛇长加一
                    snake.Add(endPoint);
                    //生成新豆
                    bean = GetBean(board);
                }
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// 蛇头是否撞到自己
        /// </summary>
        /// <param name="snake"></param>
        /// <returns></returns>
        static bool IsBumpSelf(List<Point> snake)
        {
            //判断蛇中是否撞到自己身体的节点
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].R == snake[i].R && snake[0].C == snake[i].C)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否吃到豆
        /// </summary>
        /// <param name="point">蛇头最新位置</param>
        /// <returns></returns>
        static bool IsEatBean(Point point)
        {
            //蛇头位置和豆的位置是否相同
            if (bean.C == point.C && bean.R == point.R)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 显示空底板和蛇
        /// </summary>
        /// <param name="board"></param>
        /// <param name="point"></param>
        static void ShowBoard(string[,] board)
        {
            Console.Clear();
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    Console.Write(board[r, c]);
                }
                Console.WriteLine();
            }

        }
        /// <summary>
        /// 实例化一个空底板
        /// </summary>
        /// <returns></returns>
        static string[,] CreateBoard(List<Point> snake)
        {
            //赋值所有元素为┼
            var board = new string[25, 25];
            //循环行
            for (int r = 0; r < board.GetLength(0); r++)
            {
                //循环列
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    board[r, c] = "　";
                }
            }
            //赋值左上角
            board[0, 0] = "┌";
            //赋值右下角
            board[board.GetLength(0) - 1, board.GetLength(1) - 1] = "┘";
            //赋值右上角
            board[0, board.GetLength(1) - 1] = "┐";
            //赋值左下角
            board[board.GetLength(0) - 1, 0] = "└";
            //赋值首行和尾行
            for (int c = 1; c < board.GetLength(1) - 1; c++)
            {
                //赋值首行
                board[0, c] = "─";
                //赋值尾行
                board[board.GetLength(0) - 1, c] = "─";
            }
            //赋值首列和尾列
            for (int r = 1; r < board.GetLength(0) - 1; r++)
            {
                //赋值首列
                board[r, 0] = "│";
                //赋值尾列
                board[r, board.GetLength(1) - 1] = "│";
            }
            //显示蛇
            foreach (var p in snake)
            {
                board[p.R, p.C] = "█";
            }
            if (bean == null)
            {
                bean = GetBean(board);
            }
            board[bean.R, bean.C] = "☉";
            return board;
        }
    }
}
