using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class CandyControl
    {
        public int x { get; set; }
        public int y { get; set; }
        public const int OPTIONS = 4;
        private int index;
        public string name = null;
        public string type = null;
        public double price = -1;
        public int option = 0;

        public CandyControl()
        {
            x = 15;
            y = 10;
            index = -1;
        }

        public CandyControl(int index) : this()
        {
            if (Program.cinema.candies.Count > 0 && index < Program.cinema.candies.Count && index >= 0)
            {
                this.index = index;
                Candy candy = Program.cinema.candies.ToArray()[index];
                type = candy.type;
                price = candy.price;
                name = candy.name;
            }
        }


        public void showMenu()
        {
            System.Console.Clear();
            Console.WriteLine("            ,--. ,--.  ,-----.  ,------.   ,--. ,--.   ,--.   ,---.   ,--.   ,--. ");
            Console.WriteLine("            |  .'   / '  .-.  ' |  .-.  \\  |  | |   `.'   |  /  O  \\   \\  `.'  /  ");
            Console.WriteLine("            |  .   '  |  | |  | |  |  \\  : |  | |  |'.'|  | |  .-.  |   .'    \\   ");
            Console.WriteLine("            |  |\\   \\ '  '-'  ' |  '--'  / |  | |  |   |  | |  | |  |  /  .'.  \\  ");
            Console.WriteLine("            `--' '--'  `-----'  `-------'  `--' `--'   `--' `--' `--' '--'   '--' ");
            Console.WriteLine("\n\t Muevase con las flechas arriba y abajo, cuando desee escribir presione enter sobre el campo y podra escribir");
            Console.WriteLine("\t Para ingresar ubiquese en la opcion \"ENTRAR\" y presione enter, si quiere crear un nuevo usuario, ubiquese en");
            Console.WriteLine("\t la opcion: \"REGISTRARSE\" y llene el formulario que se abrira ");

            Console.SetCursorPosition(x + 15, y - 1);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 1);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y);
            Console.Write("Nombre: ");
            Console.SetCursorPosition(x + 17, y);
            Console.Write(name != null ? name : "");

            Console.SetCursorPosition(x + 15, y + 2);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 3);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 4);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 3);
            Console.Write("Tipo: ");

            Console.SetCursorPosition(x + 17, y + 3);
            Console.Write(type != null ? type : "");

            Console.SetCursorPosition(x + 15, y + 5);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 6);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 7);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 6);
            Console.Write("Precio: ");

            Console.SetCursorPosition(x + 17, y + 6);
            Console.Write(price > -1 ? "" + price : "");


            Console.SetCursorPosition(x + 20, y + 8);
            //Console.Write(" ________________ ");
            Console.SetCursorPosition(x + 20, y + 9);
            Console.Write("      ENTRAR      ");
            Console.SetCursorPosition(x + 20, y + 10);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

            Console.SetCursorPosition(x + 20, y + 12);
            Console.Write("    REGRESAR   ");
            Console.SetCursorPosition(x + 20, y + 13);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

        }

        private bool isInvalid()
        {
            return (type == null || price < 0 || name == null);
        }

        public bool editCandy()
        {
            bool isRegister = false;
            Console.Clear();
            showMenu();
            while ((isInvalid() || option != OPTIONS - 1) && option != OPTIONS)
            {
                getOption();
            }
            if (!isInvalid() && option == OPTIONS - 1)
            {
                if (index >= 0)
                {
                    try
                    {
                        Candy candy = Program.cinema.candies.ToArray()[index];
                        candy.type = type;
                        candy.price = price;
                        candy.name = name;
                        isRegister = true;
                    }
                    catch (Exception e) { }
                }else
                {
                    Candy candy = new Candy(Program.cinema.candies.Count>0? Program.cinema.candies.ToArray()[Program.cinema.candies.Count-1].id+1:1, name, type, price);
                    Program.cinema.candies.Add(candy);
                    isRegister = true;
                }
            }
            return isRegister;
        }


        public int getOption()
        {
            int res = y;
            string number;
            res = y + 3 * option;
            Console.SetCursorPosition(x + 17, res);
            var c = Console.ReadKey(true).Key;
            while (c != ConsoleKey.Enter)
            {
                switch (c)
                {
                    case ConsoleKey.UpArrow:
                        option = option <= 0 ? OPTIONS : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option >= OPTIONS ? 0 : option + 1;
                        break;
                }
                switch (option)
                {
                    case OPTIONS:
                        Console.SetCursorPosition(x + 20, y + 13);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 20, y + 8);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 9);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 10);
                        Console.Write("                  ");
                        break;
                    case OPTIONS - 1:
                        Console.SetCursorPosition(x + 20, y + 13);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 8);
                        Console.Write(" ________________ ");
                        Console.SetCursorPosition(x + 20, y + 9);
                        Console.Write("|     ENTRAR     |");
                        Console.SetCursorPosition(x + 20, y + 10);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        break;
                    default:
                        Console.SetCursorPosition(x + 20, y + 13);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 8);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 9);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 10);
                        Console.Write("                  ");
                        break;
                }
                res = y + 3 * option;
                Console.SetCursorPosition(x + 17, res);
                c = Console.ReadKey(true).Key;
            }

            if (c == ConsoleKey.Enter)
            {
                switch (option)
                {
                    case 0:
                        Console.SetCursorPosition(x + 15, y - 1);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 1);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y);
                        name = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y + 3);
                        break;
                    case 1:
                        Console.SetCursorPosition(x + 15, y + 2);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 3);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 4);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 3);
                        type = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y);
                        break;
                    case 2:
                        Console.SetCursorPosition(x + 15, y + 5);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 6);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 7);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 6);
                        number = Console.ReadLine();
                        try
                        {
                            price = double.Parse(number);
                        }
                        catch (Exception e)
                        {
                            Console.SetCursorPosition(x + 46, y + 6);
                            Console.Write("Debe digitar un numero");
                        }
                        if (String.IsNullOrEmpty(number))
                        {
                            Console.SetCursorPosition(x + 15, y + 6);
                            Console.Write("|                              |");
                        }
                        Console.SetCursorPosition(x + 17, y + 6);
                        break;
                    case OPTIONS - 1:
                        if (isInvalid())
                        {
                            Console.SetCursorPosition(x + 15, y + 32);
                            Console.WriteLine("DEBE LLENAR TODOS LOS CAMPOS");
                            Console.SetCursorPosition(x + 20, y + 6);
                        }
                        break;
                }
            }

            return res;
        }



    }
}
