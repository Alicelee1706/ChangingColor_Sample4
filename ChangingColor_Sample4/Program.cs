using System;
using System.Collections;
class HelloWorld
{
    static void Main()
    {
        int x = 0;
        int y = 1;
        int xOld, yOld;

        Cell cell = new Cell(ConsoleColor.Black, ConsoleColor.Red);

        cell.Draw();


    }
    class Cell
    {
        private int[,] cell;
        private int x, y;
        private ConsoleColor bg, fg;
        private int[,] NextCell()
        {
            int maxCell = 6;
            Random rnd = new Random();
            return GetCell(rnd.Next(maxCell) + 1);
        }
        private int[,] GetCell(int idx)
        {
            ArrayList DCell = new ArrayList();
            DCell.Add
                (new int[,]
                {
                {1,1,1},
                {1,1,1},
                {1,1,1}
                });
            DCell.Add
                (new int[,]
                {
                {1,0,0},
                {1,0,0},
                {1,1,1}
                });
            DCell.Add
                (new int[,]
                {
                {1,1,0},
                {0,1,0},
                {0,1,1}
                });
            DCell.Add
                (new int[,]
                {
                {1,1,1},
                {0,1,0},
                {0,0,0}
                });
            DCell.Add
                (new int[,]
                {
                {0,0,0},
                {0,1,0},
                {0,0,0}
                });
            DCell.Add
                (new int[,]
                {
                {0,1,0},
                {0,1,0},
                {0,1,0}
                });

            return (int[,])DCell[idx];
        }
        public void Draw()
        {
            int y1 = y;
            Console.ForegroundColor = fg;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(x + j, y1);
                    Console.Write("{0}", cell[i, j] == 0 ? ' ' : '*');
                }
                y1++;
            }
        }
        public void Clean()
        {
            int y1 = y;
            Console.ForegroundColor = bg;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(x + j, y1);
                    Console.Write("{0}", cell[i, j] == 0 ? ' ' : '*');
                }
                y1++;
            }
        }
        public void Move()
        {
            do
            {
                ConsoleKeyInfo ke;
                ke = Console.ReadKey();
                if (ke.Key == ConsoleKey.Escape)
                {
                    break;
                }
                switch (ke.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (y > 0)
                        {
                            y--;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        break;
                }
            }
            while (true);
        }
        public Cell(ConsoleColor bg, ConsoleColor fg)
        {
            cell = new int[5, 3];
            x = 0;
            y = 0;
            this.bg = bg;
            this.fg = fg;
            cell = NextCell();
        }
        public int Y
        {
            set
            {
                Clean();
                y = value;
                Draw();
            }
            get
            {
                return y;
            }
        }

    }
}
