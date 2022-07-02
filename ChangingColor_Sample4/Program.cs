using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
class HelloWorld
{
    static Cell cell = new Cell(ConsoleColor.Black, ConsoleColor.Red);
    static void Main()
    {
        Console.CancelKeyPress += (sender, e) =>
        {
            Environment.Exit(0);
        };

        var rkey = new Task(ReadKeys);
        var animate = new Task(Animation);
        rkey.Start();
        animate.Start();
        var work = new[] { rkey };
        Task.WaitAll(work);

    }
    private static void ReadKeys()
    {
        ConsoleKeyInfo ky = new ConsoleKeyInfo();
        while (!Console.KeyAvailable && ky.Key != ConsoleKey.Escape)
        {
            ky = Console.ReadKey(true);
            switch (ky.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (cell.X > 0)
                    {
                        cell.X = cell.X - 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (cell.X < 12)
                    {
                        cell.X = cell.X + 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (cell.Y < 12)
                    {
                        cell.Y = cell.Y + 3;
                        cell.rotate();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (cell.Y < 30)
                    {
                        cell.Y = cell.Y + 1;
                    }
                    break;
            }
        }
    }
    private static void Animation()
    {
        for (; cell.Y < 12;)
        {
            Thread.Sleep(1000);
            cell.Y = cell.Y + 1;
        }
    }
}
class Cell
{
    private int[,] cell;
    private int x, y;
    private ConsoleColor bg, fg;
    public void rotate()
    {
        int[,] tmp = new int [3,3];
        const int N = 3;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                tmp[j, 2 - i] = cell[i, j];
            }
        }
        cell = tmp;
    }
    private int[,] NextCell()
    {
        int maxCell = 6;
        Random rnd = new Random();
        return GetCell(rnd.Next(maxCell));
        //return GetCell(1);
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
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < 15; i++)
        {
            Console.SetCursorPosition(15, i);
            Console.WriteLine("|");
        }
        for (int i = 0; i < 15; i++)
        {
            Console.SetCursorPosition(i, 15);
            Console.Write("-");
        }
        int y1 = y;
        Console.ForegroundColor = fg;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x + j, y1 + i);
                Console.Write("{0}", cell[i, j] == 0 ? ' ' : '*');
            }
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
                Console.SetCursorPosition(x + j, y1 + i);
                Console.Write("{0}", cell[i, j] == 0 ? ' ' : '*');
            }
        }
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
    public int X
    {
        set
        {
            Clean();
            x = value;
            Draw();
        }
        get
        {
            return x;
        }
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
