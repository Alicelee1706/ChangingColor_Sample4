using System;
class HelloWorld
{
    static void Main()
    {
        int x = 0;
        int y = 1;
        int xOld, yOld;

        Cell cell=new Cell (ConsoleColor.Black, ConsoleColor.Red);

        cell.Draw();
        Console.SetCursorPosition(0, 20);
        Console.WriteLine("_______________________________");
        for (int i = 0; i < 20; i++)
        {
            Console.SetCursorPosition(31, i);
            Console.WriteLine("|");

        }
        do
        {
            xOld = x;
            yOld = y;
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
                    if (x < 19)
                    {
                        x++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (y > 0)
                    {
                        y--;
                    }
       
                    break;
                case ConsoleKey.DownArrow:
                    if (y < 19)
                    {
                        y++;
                    }
                    break;
            }
        }
        while (true);
    }
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
        switch (idx)
        {
            case 1:
                return DCell1();
                break;
            case 2:
                return DCell2();
                break;
            case 3:
                return DCell3();
                break;
            case 4:
                return DCell4();
                break;
            case 5:
                return DCell5();
                break;
        }
         return DCell6();
    }
    private int[,] DCell1()
    {
        int[,] values =
        {
            {1,1,1},
            {1,1,1},
            {1,1,1}
        };
        return values;
    }
   private int[,] DCell2()
    {
        int[,] values =
        {
            {1,0,0},
            {1,0,0},
            {1,1,1}
        };
        return values;
    }
   private int[,] DCell3()
    {
        int[,] values =
        {
            {1,1,0},
            {0,1,0},
            {0,1,1}
        };
        return values;
    }
   private int[,] DCell4()
    {
        int[,] values =
        {
            {1,1,1},
            {0,1,0},
            {0,0,0}
        };
        return values;
    }
   private int[,] DCell5()
    {
        int[,] values =
        {
            {0,0,0},
            {0,1,0},
            {0,0,0}
        };
        return values;
    }
   private int[,] DCell6()
    {
        int[,] values =
        {
            {0,1,0},
            {0,1,0},
            {0,1,0}
        };
        return values;
    }
    public void Draw ()
    {
        int y1 = y;
        Console.ForegroundColor = fg;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x + j, y1);
                Console.Write("{0}", cell[i,j] == 0? ' ' : '*');
            }    
            y1++;
        }
    }
    private void ClearT()
    {
        int y1 = y;
        Console.ForegroundColor = bg;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x + j, y1);
                Console.Write("{0}", cell[i,j] == 0? ' ' : '*');
            }    
            y1++;
        }
    }
    public void Move ()
    {
    }
    public Cell (ConsoleColor bg, ConsoleColor fg)
    {
        cell = new int[5,3];
        x = 0;
        y = 0;
        this.bg = bg;
        this.fg = fg;
        cell = NextCell();
    }
}
