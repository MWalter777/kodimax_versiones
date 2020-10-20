using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class MovieControl
    {
        public int x { get; set; }
        public int y { get; set; }
        public const int OPTIONS = 4;
        private int index;
        public string name = null;
        public string duration = null;
        public string type = null;
        public int option = 0;

        public MovieControl()
        {
            x = 15;
            y = 10;
            index = -1;
        }

        public MovieControl(int index) : this()
        {
            if(index>=0 && index < Program.cinema.movies.Count)
            {
                Movie movie = Program.cinema.movies.ToArray()[index];
                name = movie.name;
                type = movie.type;
                duration = movie.duration;
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
            Console.WriteLine("\t Para ingresar ubiquese en la opcion \"ENTRAR\"");

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
            Console.Write("Duracion: ");

            Console.SetCursorPosition(x + 17, y + 6);
            Console.Write(duration != null ? duration : "");

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
            return (type == null || name == null || duration == null);
        }

        public bool editMovie()
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
                if (index>=0)
                {
                    try
                    {
                        Movie movie = Program.cinema.movies.ToArray()[index];
                        movie.type = type;
                        movie.name = name;
                        movie.duration = duration;
                        isRegister = true;
                    }
                    catch (Exception e) { }
                }else
                {
                    Movie newMovie = new Movie(Program.cinema.movies.Count>0? Program.cinema.movies.ToArray()[Program.cinema.movies.Count - 1].id+1:1, name, duration, type);
                    foreach(Room r in Program.cinema.rooms)
                    {
                        newMovie.rooms.Add((Room)r.Clone());
                    }
                    Program.cinema.movies.Add(newMovie);
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
                        break;
                    case 2:
                        Console.SetCursorPosition(x + 15, y + 5);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 6);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 7);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 6);
                        duration = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y + 6);
                        break;
                    case OPTIONS - 1:
                        if (isInvalid())
                        {
                            Console.SetCursorPosition(x + 15, y + 22);
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
