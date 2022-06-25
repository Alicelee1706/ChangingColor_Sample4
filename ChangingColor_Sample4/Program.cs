﻿using System;
class HelloWorld
{
    static void Main()
    {
        int x = 0;
        int y = 1;
        int xOld, yOld;

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(x, y);
        Console.WriteLine("Hello World");

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

    }
    public void Draw ()
    {
        int x1 = x, y1 = y;
        Console.ForegroundColor = fg;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x1 + i, y1);
                Console.Write("{0}", b1[i,j]);
            }    
            y1++;
        }
    }
    private void ClearT()
    {
        int x1 = xOld, y1 = yOld;
        Console.ForegroundColor = bg;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x1 + i, y1);
                Console.Write("{0}", b1[i,j]);
            }    
            y1++;
        }
    }
    public void Move ()
    {
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
    public Cell (ConsoleColor bg, ConsoleColor fg)
    {
        Cell = new int[5,3];
        x = 0;
        y = 0;
        this bg = bg;
        this fg = fg;
        cell = NextCell();
    }
}
