using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Menu
    {
        public int x { get; set; }
        public int y { get; set; }
        public int START = 5;
        public int END = 5;
        public ArrayList items { set; get; }
        public string footer = null;

        public Menu(ArrayList items)
        {
            this.items = items;
            this.x = 0;
            this.y = 0;
            this.END = items.Count+START-1;
        }

        public Menu(ArrayList items, int x, int y) : this(items)
        {
            this.x = x;
            this.y = y;
            this.START = y;
            this.END = items.Count + START - 1;
        }

        public Menu(ArrayList items, int x, int y, string footer) : this(items, x, y)
        {
            this.footer = footer;
        }

        public void printItems()
        {
            System.Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("                    ______ _________ ________ ________________________  ");
            Console.SetCursorPosition(0, 1);
            Console.Write("                    ___  //_/__  __ \\___  __ \\____  _/__  ____/__  __ \\");
            Console.SetCursorPosition(0, 2);
            Console.Write("                    __  ,<   _  / / /__  / / / __  /  _  / __  _  / / /");
            Console.SetCursorPosition(0, 3);
            Console.Write("                    _  /| |  / /_/ / _  /_/ / __/ /   / /_/ /  / /_/ / ");
            Console.SetCursorPosition(0, 4);
            Console.Write("                    /_/ |_|  \\____/  /_____/  /___/   \\____/   \\____/  ");
            int aux = y>=6?y:6;
            foreach (string val in items)
            {
                Console.SetCursorPosition(x + 4, aux);
                Console.WriteLine(val);
                aux+=2;
            }

            Console.SetCursorPosition(x + 10, aux+5);
            Console.Write(footer != null ? footer : "Bienvenido a KODIMAX");

        }

 

        public int getOption()
        {
            int res = START;
            System.Console.SetCursorPosition(x, res - 1);
            Console.Write(" ___________________________________________________________ ");
            System.Console.SetCursorPosition(x, res + 1);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            System.Console.SetCursorPosition(x, res);
            Console.Write("|");
            System.Console.SetCursorPosition(x + 60, res);
            Console.Write("|");
            var c = Console.ReadKey().Key;
            while (c != ConsoleKey.Enter)
            {
                switch (c)
                {
                    case ConsoleKey.UpArrow:
                        System.Console.SetCursorPosition(x, res - 1);
                        Console.Write("                                                                ");
                        System.Console.SetCursorPosition(x, res + 1);
                        Console.Write("                                                               ");
                        System.Console.SetCursorPosition(x, res);
                        Console.Write("   ");
                        System.Console.SetCursorPosition(x + 60, res);
                        Console.Write("   ");
                        if (res > START) res-=2;
                        else res = END + items.Count-1;
                        System.Console.SetCursorPosition(x, res - 1);
                        Console.Write(" ___________________________________________________________ ");
                        System.Console.SetCursorPosition(x, res + 1);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        System.Console.SetCursorPosition(x, res);
                        Console.Write("|");
                        System.Console.SetCursorPosition(x + 60, res);
                        Console.Write("|");
                        break;
                    case ConsoleKey.DownArrow:
                        System.Console.SetCursorPosition(x, res-1);
                        Console.Write("                                                              ");
                        System.Console.SetCursorPosition(x, res+1);
                        Console.Write("                                                              ");
                        System.Console.SetCursorPosition(x, res);
                        Console.Write("   ");
                        System.Console.SetCursorPosition(x + 60, res);
                        Console.Write("   ");
                        if (res < END + items.Count - 1) res+=2;
                        else res = START;
                        System.Console.SetCursorPosition(x, res - 1);
                        Console.Write(" ___________________________________________________________ ");
                        System.Console.SetCursorPosition(x, res + 1);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        System.Console.SetCursorPosition(x, res);
                        Console.Write("|");
                        System.Console.SetCursorPosition(x + 60, res);
                        Console.Write("|");
                        break;
                }
                c = Console.ReadKey().Key;
            }
            return (res - START)/2;
        }

        public void printFoot(string value)
        {
            System.Console.SetCursorPosition(x + 10, y+30);
            Console.Write(value);
        }

    }
}
