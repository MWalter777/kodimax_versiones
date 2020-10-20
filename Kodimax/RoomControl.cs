using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class RoomControl
    {
        public int x { get; set; }
        public int y { get; set; }
        public const int OPTIONS = 5;
        private int index;
        public string type = null;
        public double price = -1;
        public int rows = -1;
        public int columns = -1;
        public int option = 0;

        public RoomControl(int index)
        {
            x = 15;
            y = 10;
            if (Program.cinema.rooms.Count > 0 && index < 4 && index >= 0)
            {
                this.index = index;
                Room room = Program.cinema.rooms.ToArray()[index];
                type = room.type;
                price = room.price;
                rows = room.rows;
                columns = room.columns;
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
            Console.WriteLine("\t Para ingresar ubiquese en la opcion \"ENTRAR\" ");

            Console.SetCursorPosition(x + 15, y - 1);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 1);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y);
            Console.Write("Tipo: ");
            Console.SetCursorPosition(x + 17, y);
            Console.Write(type != null ? type : "");

            Console.SetCursorPosition(x + 15, y + 2);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 3);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 4);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 3);
            Console.Write("Precio: ");

            Console.SetCursorPosition(x + 17, y + 3);
            Console.Write(price > -1 ? ""+price : "");

            Console.SetCursorPosition(x + 15, y + 5);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 6);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 7);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 6);
            Console.Write("Filas: ");

            Console.SetCursorPosition(x + 17, y + 6);
            Console.Write(rows > -1 ? ""+rows : "");

            Console.SetCursorPosition(x + 15, y + 8);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 9);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 10);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 9);
            Console.Write("Columnas: ");

            Console.SetCursorPosition(x + 17, y + 9);
            Console.Write(columns > -1 ? ""+columns : "");


            Console.SetCursorPosition(x + 20, y + 11);
            //Console.Write(" ________________ ");
            Console.SetCursorPosition(x + 20, y + 12);
            Console.Write("      ENTRAR      ");
            Console.SetCursorPosition(x + 20, y + 13);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

            Console.SetCursorPosition(x + 20, y + 15);
            Console.Write("    REGRESAR   ");
            Console.SetCursorPosition(x + 20, y + 16);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

        }

        private bool isInvalid()
        {
            return (type == null || price<0 || rows<0 || columns<0);
        }

        public bool editRoom()
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
                try
                {
                    Room room = Program.cinema.rooms.ToArray()[index];
                    room.type = type;
                    room.price = price;
                    room.rows = rows;
                    room.columns = columns;
                    isRegister = true;
                }
                catch (Exception e) { }
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
                        Console.SetCursorPosition(x + 20, y + 16);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 20, y + 11);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 12);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 13);
                        Console.Write("                  ");
                        break;
                    case OPTIONS - 1:
                        Console.SetCursorPosition(x + 20, y + 16);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 11);
                        Console.Write(" ________________ ");
                        Console.SetCursorPosition(x + 20, y + 12);
                        Console.Write("|     ENTRAR     |");
                        Console.SetCursorPosition(x + 20, y + 13);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        break;
                    default:
                        Console.SetCursorPosition(x + 20, y + 16);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 11);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 12);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 13);
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
                        type = Console.ReadLine();
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
                        number = Console.ReadLine();
                        try
                        {
                            price = double.Parse(number);
                        }
                        catch (Exception e)
                        {
                            Console.SetCursorPosition(x + 46, y + 6);
                            Console.Write("Debe digitar un precio numerico");
                        }
                        if (String.IsNullOrEmpty(number))
                        {
                            Console.SetCursorPosition(x + 15, y + 6);
                            Console.Write("|                              |");
                        }
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
                            rows = int.Parse(number);
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
                    case 3:
                        Console.SetCursorPosition(x + 15, y + 8);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 9);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 10);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 9);
                        number = Console.ReadLine();
                        try
                        {
                            columns = int.Parse(number);
                        }
                        catch (Exception e)
                        {
                            Console.SetCursorPosition(x + 46, y + 9);
                            Console.Write("Debe digitar un numero");
                        }
                        if (String.IsNullOrEmpty(number))
                        {
                            Console.SetCursorPosition(x + 15, y + 9);
                            Console.Write("|                              |");
                        }
                        Console.SetCursorPosition(x + 17, y + 9);
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
