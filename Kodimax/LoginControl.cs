using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class LoginControl
    {
        public int x { get; set; }
        public int y { get; set; }
        private string username = null;
        private string password = null;
        public int option = 0;

        public LoginControl()
        {
            x = 15;
            y = 10;
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
            Console.Write("Username: ");


            Console.SetCursorPosition(x + 15, y + 2);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 3);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 4);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y+3);
            Console.Write("Password: ");


            Console.SetCursorPosition(x + 20, y + 5);
            //Console.Write(" ________________ ");
            Console.SetCursorPosition(x + 20, y + 6);
            Console.Write("      ENTRAR      ");
            Console.SetCursorPosition(x + 20, y + 7);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

            Console.SetCursorPosition(x + 20, y + 8);
            Console.Write("    REGISTRATE   ");
            Console.SetCursorPosition(x + 20, y + 9);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

        }


        public bool login()
        {
            bool isValid = false;
            Console.Clear();
            showMenu();
            while (username == null || password == null || option != 2)
            {
                getOption();
            }
            
            foreach (User user in Program.cinema.users)
            {
                if (username.Equals(user.username) && password.Equals(user.password))
                {
                    Program.user = user;
                    isValid = true;
                }
            }

            return isValid;
        }


        public int getOption()
        {
            int res = y;
            res = y + 3 * option;
            Console.SetCursorPosition(x + 17,res);
            var c = Console.ReadKey(true).Key;
            while (c != ConsoleKey.Enter)
            {
                switch (c)
                {
                    case ConsoleKey.UpArrow:
                        option = option <= 0 ? 3 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option >= 3 ? 0 : option + 1;
                        break;
                }
                switch (option)
                {
                    case 3:
                        Console.SetCursorPosition(x + 20, y + 9);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 20, y + 5);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 6);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 7);
                        Console.Write("                  ");
                        break;
                    case 2:
                        Console.SetCursorPosition(x + 20, y + 9);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 5);
                        Console.Write(" ________________ ");
                        Console.SetCursorPosition(x + 20, y + 6);
                        Console.Write("|     ENTRAR     |");
                        Console.SetCursorPosition(x + 20, y + 7);
                        Console.SetCursorPosition(x + 20, y + 7);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        break;
                    default:
                        Console.SetCursorPosition(x + 20, y + 9);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 5);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 6);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 7);
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
                        username = Console.ReadLine();
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
                        password = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y);
                        break;
                    case 2:
                        if(username==null || password == null)
                        {
                            Console.SetCursorPosition(x + 15, y + 11);
                            Console.WriteLine("EL USUARIO Y CONTRASEÑA NO PUEDE ESTAR VACIO");
                            Console.SetCursorPosition(x + 20, y + 7);
                        }
                        break;
                    case 3:
                        RegisterControl register = new RegisterControl();
                        username = null;
                        password = null;
                        bool newUer = register.register();
                        Console.Clear();
                        showMenu();
                        if (newUer)
                        {
                            Console.SetCursorPosition(x+15, y + 15);
                            Console.Write("Usuario creado con exito ");
                            foreach (User users in Program.cinema.users)
                            {
                                Console.Write("user: {0}, ", users.name);
                            }
                        }
                        option = 0;
                        break;
                }
            }

            return res;
        }


    }
}
