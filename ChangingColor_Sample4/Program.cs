using System;
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
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(xOld, yOld);
            Console.WriteLine("Hello World");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Hello World");

            Console.SetCursorPosition(0, 20);
            Console.WriteLine("_______________________________|");

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(31, i);
                Console.WriteLine("|");

            }
        }
        while (true);
    }
}
