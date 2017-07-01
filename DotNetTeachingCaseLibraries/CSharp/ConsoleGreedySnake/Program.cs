using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGreedySnake
{
    class Point
    {
        public int R { get; set; }
        public int C { get; set; }
    }
    class Program
    {

        static char mark = 'w';
        static void Main(string[] args)
        {
            new Thread(Go).Start();
            while (true)
            {
                mark = Console.ReadKey(true).KeyChar;
            }
        }
        /// <summary>
        /// 蛇自动走步
        /// </summary>
        static void Go()
        {
            var snake = new List<Point>();
            snake.Add(new Point { C = 12, R = 20 });
            snake.Add(new Point { C = 12, R = 21 });
            snake.Add(new Point { C = 12, R = 22 });
            snake.Add(new Point { C = 12, R = 23 });
            while (true)
            {
                //创建底板和蛇数组
                var board = CreateBoard(snake);
                //显示
                ShowBoard(board);
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
                    case 'S':
                        snake[0].R++;
                        if (snake[0].R > board.GetLength(0) - 2)
                        {
                            snake[0].R = 1;
                        }
                        break;
                    case 'w':
                    case 'W':
                        snake[0].R--;
                        if (snake[0].R < 1)
                        {
                            snake[0].R = board.GetLength(0) - 2;
                        }
                        break;
                    case 'a':
                    case 'A':
                        snake[0].C--;
                        if (snake[0].C < 1)
                        {
                            snake[0].C = board.GetLength(1) - 2;
                        }
                        break;
                    case 'd':
                    case 'D':
                        snake[0].C++;
                        if (snake[0].C > board.GetLength(1) - 2)
                        {
                            snake[0].C = 1;
                        }
                        break;
                }
                Thread.Sleep(500);
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
            return board;
        }
    }
}
