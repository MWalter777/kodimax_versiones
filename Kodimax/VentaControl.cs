using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class VentaControl
    {
        public int x = 15;
        public int y = 10;
        public const int OPTIONS = 3;
        public int indexMovie = -1;
        public int indexRoom = -1;
        public int free = -1;
        public int indexCandy = -1;
        public int quantity=-1;
        public int option = 0;
        public double pay = 0;
        private List<User> employees = new List<User>();
        public ArrayList items;

        public VentaControl()
        {
            foreach (User user in Program.cinema.users)
            {
                if (user.code == 77)
                {
                    employees.Add(user);
                }
            }
        }

        public VentaControl(int indexCandy, ArrayList items, int free) : this()
        {
            this.indexCandy = indexCandy;
            this.items = items;
            this.free = free;
        }

        public VentaControl(int indexMovie, int indexRoom, int free, ArrayList items) : this()
        {
            this.indexMovie = indexMovie;
            this.indexRoom = indexRoom;
            this.free = free;
            this.items = items;
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
            Console.WriteLine("\t Para ingresar ubiquese en la opcion \"ENTRAR\" y presione enter");
            
            foreach(string value in items)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(value);
                y++;
            }
            y+=2;

            Console.SetCursorPosition(x + 15, y - 1);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 1);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y);
            Console.Write("Cantidad: ");
            Console.SetCursorPosition(x + 17, y);


            Console.SetCursorPosition(x + 15, y + 2);
            Console.Write(" ______________________________ ");
            Console.SetCursorPosition(x + 15, y + 3);
            Console.Write("|                              |");
            Console.SetCursorPosition(x + 15, y + 4);
            Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
            Console.SetCursorPosition(x + 4, y + 3);
            Console.Write("Pago: ");

            Console.SetCursorPosition(x + 20, y + 5);
            //Console.Write(" ________________ ");
            Console.SetCursorPosition(x + 20, y + 6);
            Console.Write("      ENTRAR      ");
            Console.SetCursorPosition(x + 20, y + 7);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

            Console.SetCursorPosition(x + 20, y + 9);
            Console.Write("    REGRESAR   ");
            Console.SetCursorPosition(x + 20, y + 10);
            //Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

        }


        private bool isInvalid()
        {
            return (quantity<0 || quantity>free) || !isPayAcceptable();
        }

        private double getPrice()
        {
            if(indexCandy < 0 && indexRoom>=0 && indexMovie >= 0)
            {
                Movie movie = Program.cinema.movies.ToArray()[indexMovie];
                Room room = movie.rooms.ToArray()[indexRoom];
                return room.price * quantity;
            }
            else if (indexCandy>=0)
            {
                Candy candy = Program.cinema.candies.ToArray()[indexCandy];
                return candy.price * quantity;
            }
            return 0;
        }

        private bool isPayAcceptable()
        {
            return quantity >0? pay >= getPrice():false;
        }

        public Bill newVenta()
        {
            Bill bill = null;
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
                    if (indexCandy ==-1 && indexMovie>=0 && indexRoom>=0 && indexMovie<Program.cinema.movies.Count)
                    {
                        Movie movie = Program.cinema.movies.ToArray()[indexMovie];
                        Room room = movie.rooms.ToArray()[indexRoom];
                        room.free = room.free - quantity;
                        Ticket ticket = new Ticket(indexMovie, room, Program.user, quantity, movie);
                        Program.cinema.tickes.Add(ticket);
                        Console.Clear();
                        Console.SetCursorPosition(x+10, 2);
                        Console.Write("DATOS TECNICOS");
                        Console.SetCursorPosition(x, 4);
                        Console.Write("Pelicula: {0}", ticket.movie.name);
                        Console.SetCursorPosition(x, 5);
                        Console.Write("Genero: {0}", ticket.movie.type);
                        Console.SetCursorPosition(x, 6);
                        Console.Write("Duracion: {0}", ticket.movie.duration);
                        Console.SetCursorPosition(x, 8);
                        double getPaid = quantity * ticket.room.price;
                        Console.Write("Cliente: {0}", ticket.user.name);
                        Console.SetCursorPosition(x, 9);
                        Console.Write("Boletos: {0}", quantity);
                        Console.SetCursorPosition(x, 10);
                        Console.Write("Precio a pagar: {0}", getPaid);
                        Console.SetCursorPosition(x, 12);
                        Console.Write(pay == getPaid ? "COBRO EXACTO, GRACIAS POR COMPRAR EN KODIMAX" : String.Format("SU CAMBIO ES: $ {0} GRACIAS POR COMPRAR EN KODIMAX", pay - getPaid));
                        Console.SetCursorPosition(x, 13);
                        Console.Write("POR FAVOR SELECCIONE SUS ASIENTOS");
                        bill = new Bill("Compra de boletos para "+ticket.movie.name, quantity, getPaid);
                    }
                    if (indexCandy >=0 && indexMovie < 0 && indexRoom < 0)
                    {
                        Console.Clear();
                        Candy candy = Program.cinema.candies.ToArray()[indexCandy];
                        Console.SetCursorPosition(x, 2);
                        Console.Write("Compra: {0}", candy.name);
                        Console.SetCursorPosition(x, 3);
                        Console.Write("Precio unitario: {0}", candy.price);
                        Console.SetCursorPosition(x, 4);
                        Console.Write("Cliente: {0}", Program.user.name);
                        Console.Write("Cantidad: {0}", quantity);
                        Console.Write("Precio: {0}", getPrice());
                        Console.SetCursorPosition(x, 6);
                        Console.Write(pay == getPrice() ? "COBRO EXACTO, GRACIAS POR COMPRAR EN KODIMAX" : String.Format("SU CAMBIO ES: $ {0} GRACIAS POR COMPRAR EN KODIMAX", pay - getPrice()));
                        bill = new Bill("Compra de dulces: "+candy.name, quantity, getPrice());
                    }
                    Console.SetCursorPosition(x, 14);
                    Console.Write("Empleado: "+getEmpleado());
                    Console.ReadKey();
                }
                catch (Exception e) { }
            }
            return bill;
        }

        private string getEmpleado()
        {
            string employee = "";
            int i = Program.rnd.Next(employees.Count);
            try
            {
                employee = employees.ToArray()[i].name + ", " +employees.ToArray()[i].surname;
            }catch(Exception e) { }
            return employee;
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
                        Console.SetCursorPosition(x + 20, y + 10);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        Console.SetCursorPosition(x + 20, y + 5);
                        Console.Write("                  ");
                        Console.SetCursorPosition(x + 20, y + 6);
                        Console.Write("      ENTRAR      ");
                        Console.SetCursorPosition(x + 20, y + 7);
                        Console.Write("                  ");
                        break;
                    case OPTIONS - 1:
                        Console.SetCursorPosition(x + 20, y + 10);
                        Console.Write("                   ");
                        Console.SetCursorPosition(x + 20, y + 5);
                        Console.Write(" ________________ ");
                        Console.SetCursorPosition(x + 20, y + 6);
                        Console.Write("|     ENTRAR     |");
                        Console.SetCursorPosition(x + 20, y + 7);
                        Console.Write(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
                        break;
                    default:
                        Console.SetCursorPosition(x + 20, y + 10);
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
                        number = Console.ReadLine();
                        try
                        {
                            quantity = int.Parse(number);
                            if (quantity > 0)
                            {
                                Console.SetCursorPosition(x + 46, y + 3);
                                Console.Write("Pagar: $ {0} ", getPrice());
                            }else
                            {
                                quantity = -1;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.SetCursorPosition(x + 46, y);
                            Console.Write("Debe digitar un numero");
                        }
                        if (String.IsNullOrEmpty(number) || quantity<0)
                        {
                            Console.SetCursorPosition(x + 15, y + 6);
                            Console.Write("|                              |");
                        }
                        Console.SetCursorPosition(x + 17, y);
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
                            pay = int.Parse(number);
                            if (!isPayAcceptable())
                            {
                                Console.SetCursorPosition(x + 15, y + 3);
                                Console.Write("|                              |");
                                Console.SetCursorPosition(x + 46, y + 3);
                                Console.Write("Debe ingresar al menos $ {0} ",getPrice());
                                pay = -1;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.SetCursorPosition(x + 46, y + 3);
                            Console.Write("Debe digitar un numero");
                        }
                        if (String.IsNullOrEmpty(number))
                        {
                            Console.SetCursorPosition(x + 15, y + 3);
                            Console.Write("|                              |");
                        }
                        Console.SetCursorPosition(x + 17, y + 3);
                        break;
                    case OPTIONS - 1:
                        if (isInvalid())
                        {
                            Console.SetCursorPosition(x + 15, y + 10);
                            Console.WriteLine("DATOS INVALIDOS!!!");
                            Console.SetCursorPosition(x + 20, y);
                        }
                        break;
                }
            }

            return res;
        }



    }
}
