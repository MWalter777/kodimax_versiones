using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Program
    {
        public static Cinema cinema = new Cinema("KODIMAX");
        public static User user = null;
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            int exit = 0;
            createData();
            do
            {
                LoginControl login = new LoginControl();
                if (login.login())
                {
                    UserControl.showMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No se encontro el usuario, vuelva a intentarlo");
                    Console.ReadKey();
                }
                ArrayList items = new ArrayList();
                items.Add("VOLVER AL LOGIN?");
                items.Add("SALIR");
                Menu menu = new Menu(items, 15, 7);
                menu.printItems();
                exit = menu.getOption();
            } while (exit == 0);
        }

        private static void createData()
        {
            string userAdmin = "admin-max";
            string passwordAdmin = "@dminM@x";
            User admin = new User("admin", "admin", "email@gmail.com", "7777-5236", "25/07/1996", "masculino", userAdmin, passwordAdmin);
            admin.code = 777;
            User client = new User("cliente", "client", "client@gmail.com", "7777-5236", "25/07/1996", "masculino", "client", "root");
            User employee = new User("Empleado", "employee", "employee@gmail.com", "7777-5236", "25/07/1996", "masculino", "employee", "root");
            employee.code = 77;
            cinema.users.Add(admin);
            cinema.users.Add(client);
            cinema.users.Add(employee);

            Room room1 = new Room(1, "Estandar", 3.55, 7, 8);
            Room room2 = new Room(2, "Premium", 4.75, 5, 8);
            Room room3 = new Room(3, "VIP", 6.50, 5, 6);

            cinema.rooms.Add(room1);
            cinema.rooms.Add(room2);
            cinema.rooms.Add(room3);

            Movie movie1 = new Movie(1, "Dragon ball z", "2:35 h", "Accion", (Room)room1.Clone());
            movie1.rooms.Add((Room)room2.Clone());
            movie1.rooms.Add((Room)room3.Clone());
            Movie movie2 = new Movie(2, "Avatar TLA", "2:35 h", "Accion", (Room)room1.Clone());
            movie2.rooms.Add((Room)room2.Clone());
            movie2.rooms.Add((Room)room3.Clone());
            Movie movie3 = new Movie(3, "Catch me if you can", "2:35 h", "Accion", (Room)room1.Clone());
            movie3.rooms.Add((Room)room2.Clone());
            movie3.rooms.Add((Room)room3.Clone());
            Movie movie4 = new Movie(4, "El octavo pasajero", "2:35 h", "Suspenso", (Room)room1.Clone());
            movie4.rooms.Add((Room)room2.Clone());
            movie4.rooms.Add((Room)room3.Clone());
            Movie movie5 = new Movie(5, "Megamente", "2:35 h", "Comedia/Accion", (Room)room1.Clone());
            movie5.rooms.Add((Room)room2.Clone());
            movie5.rooms.Add((Room)room3.Clone());

            cinema.movies.Add(movie1);
            cinema.movies.Add(movie2);
            cinema.movies.Add(movie3);
            cinema.movies.Add(movie4);
            cinema.movies.Add(movie5);

            cinema.candies.Add(new Candy(1, "Chocolate", "Dulce", 4.25));
            cinema.candies.Add(new Candy(2, "Palomitas de mmaiz", "Comida", 5.25));
            cinema.candies.Add(new Candy(3, "Pepsi", "Bebida", 6.25));
            cinema.candies.Add(new Candy(4, "Nachos", "Comida", 7.25));

        }
    }
}
