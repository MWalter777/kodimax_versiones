using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class RegisterControl
    {
        public int x { get; set; }
        public int y { get; set; }
        public const int OPTIONS = 10;
        public string name      = null;
        public string surname   = null;
        public string email     = null;
        public string phone     = null;
        public string birthday  = null;
        public string gender    = null;
        public string username  = null;
        public string password  = null;
        public int code         = 0;
        public int option       = 0;
        private int indexUser;

        public RegisterControl()
        {
            x = 15;
            y = 10;
            indexUser = -1;
        }

        public RegisterControl(int indexUser) : this()
        {
            this.indexUser = indexUser;
            if (indexUser >= 0)
            {
                try
                {
                    User user = Program.cinema.users.ToArray()[indexUser];
                    name = user.name;
                    surname = user.surname;
                    email = user.email;
                    phone = user.phone;
                    birthday = user.birthday;
                    gender = user.gender;
                    username = user.username;
                    password = user.password;
                    code = user.code;
                }catch(Exception e) { }
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
            Console.Write("Apellido: ");

            Console.SetCursorPosition(x + 17, y + 3);
            Console.Write(surname != null ? surname : "");

            Console.SetCursorPosition(x + 15, y + 5);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 6);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 7);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 6);
            Console.Write("Email: ");

            Console.SetCursorPosition(x + 17, y + 6);
            Console.Write(email != null ? email : "");

            Console.SetCursorPosition(x + 15, y + 8);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 9);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 10);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 9);
            Console.Write("Telefono: ");

            Console.SetCursorPosition(x + 17, y + 9);
            Console.Write(phone != null ? phone : "");

            Console.SetCursorPosition(x + 15, y + 11);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 12);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 13);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 12);
            Console.Write("Cumpleaños: ");

            Console.SetCursorPosition(x + 17, y + 12);
            Console.Write(birthday != null ? birthday : "");

            Console.SetCursorPosition(x + 15, y + 14);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 15);
            Console.Write("|                             |");
            Console.SetCursorPosition(x + 15, y + 16);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 15);
            Console.Write("Genero: ");

            Console.SetCursorPosition(x + 17, y + 15);
            Console.Write(gender != null ? gender : "");

            Console.SetCursorPosition(x + 15, y + 17);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 18);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 19);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 18);
            Console.Write("Username: ");

            Console.SetCursorPosition(x + 17, y + 3);
            Console.Write(username != null ? username : "");

            Console.SetCursorPosition(x + 15, y + 20);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 21);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 22);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 21);
            Console.Write("Password: ");


            Console.SetCursorPosition(x + 15, y + 23);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 24);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 25);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 24);
            Console.Write("Codigo Empl: ");



            Console.SetCursorPosition(x + 20, y + 26);
            //Console.Write(" ________________ ");
            Console.SetCursorPosition(x + 20, y + 27);
            Console.Write("      ENTRAR      ");
            Console.SetCursorPosition(x + 20, y + 28);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

            Console.SetCursorPosition(x + 20, y + 29);
            Console.Write("    REGRESAR   ");
            Console.SetCursorPosition(x + 20, y + 30);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

        }

        public bool register()
        {
            bool isRegister = false;
            Console.Clear();
            showMenu();
            while (( isInvalid() || option != OPTIONS - 1) && option != OPTIONS)
            {
                getOption();
            }
            if ( !isInvalid() && option == OPTIONS - 1)
            {
                User user = new User(name, surname, email, phone, birthday, gender, username, password);
                user.code = code;
                Program.cinema.users.Add(user);
                isRegister = true;
            }
            return isRegister;
        }

        private bool isInvalid()
        {
            return (username == null || password == null || name == null || surname == null || email == null || phone == null || birthday == null || gender == null) || isInvalidUsername();
        }


        public int getOption()
        {
            int res = y;
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
                        Console.SetCursorPosition(x + 20, y + 30);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 20, y + 26);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 27);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 28);
                        Console.Write("                  ");
                        break;
                    case OPTIONS - 1:
                        Console.SetCursorPosition(x + 20, y + 30);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 26);
                        Console.Write(" ________________ ");
                        Console.SetCursorPosition(x + 20, y + 27);
                        Console.Write("|     ENTRAR     |");
                        Console.SetCursorPosition(x + 20, y + 28);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        break;
                    default:
                        Console.SetCursorPosition(x + 20, y + 30);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 26);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 27);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 28);
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
                        surname = Console.ReadLine();
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
                        email = Console.ReadLine();
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
                        phone = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y + 9);
                        break;
                    case 4:
                        Console.SetCursorPosition(x + 15, y + 11);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 12);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 13);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 12);
                        birthday = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y + 12);
                        break;
                    case 5:
                        Console.SetCursorPosition(x + 15, y + 14);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 15);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 16);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 15);
                        gender = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y + 15);
                        break;
                    case 6:
                        Console.SetCursorPosition(x + 15, y + 17);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 18);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 19);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 18);
                        username = Console.ReadLine();
                        if (isInvalidUsername())
                        {
                            Console.SetCursorPosition(x + 15, y + 18);
                            Console.Write("|                              |");
                            Console.SetCursorPosition(x + 46, y + 18);
                            Console.Write("Usuario no valido, intente con otro");
                            username = null;
                        }

                        Console.SetCursorPosition(x + 17, y + 3);
                        break;
                    case 7:
                        Console.SetCursorPosition(x + 15, y + 20);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 21);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 22);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 21);
                        password = Console.ReadLine();
                        Console.SetCursorPosition(x + 17, y + 21);
                        break;
                    case 8:
                        Console.SetCursorPosition(x + 15, y + 23);
                        Console.Write(" ______________________________ ");
                        Console.SetCursorPosition(x + 15, y + 24);
                        Console.Write("|                              |");
                        Console.SetCursorPosition(x + 15, y + 25);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 17, y + 24);
                        string number;
                        number = Console.ReadLine();
                        try
                        {
                            code = int.Parse(number);
                        }
                        catch (Exception e)
                        {
                            Console.SetCursorPosition(x + 46, y + 24);
                            Console.Write("Debe digitar un codigo (Numero)");
                        }
                        if (String.IsNullOrEmpty(number))
                        {
                            Console.SetCursorPosition(x + 15, y + 24);
                            Console.Write("|                              |");
                        }
                        Console.SetCursorPosition(x + 17, y + 21);
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

        private bool isInvalidUsername()
        {
            foreach(User user in Program.cinema.users)
            {
                if (user.username.Equals(username)) return true;
            }
            return false;
        }
    }
}
