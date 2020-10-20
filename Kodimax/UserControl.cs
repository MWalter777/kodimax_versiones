using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Kodimax
{
    class UserControl
    {
        private const int CLIENT = 7;
        private const int EMPLOYEE = 77;
        private const int ADMIN = 777;
        public static void showMenu()
        {
            if(Program.user != null)
            {
                switch (Program.user.code)
                {
                    case CLIENT:
                        showClientMenu();
                        break;
                    case EMPLOYEE:
                        showEmployeeMenu();
                        break;
                    case ADMIN:
                        showAdminMenu();
                        break;
                }
            }
        }

        private static void showAdminMenu()
        {
            Console.Clear();
            ArrayList items = new ArrayList();
            items.Add("ELIMINAR PELICULAS");
            items.Add("AGREGAR PELICULAS");
            items.Add("MODIFICAR SALAS");
            items.Add("ELIMINAR GOLOSINA");
            items.Add("MODIFICAR GOLOSINA");
            items.Add("GREGAR GOLOSINA");
            items.Add("ELIMINAR EMPLEADO");
            items.Add("GREGAR EMPLEADO");
            items.Add("AGREGAR SUCURSALES");
            items.Add("MODIFICAR SUCURSALES");
            items.Add("AGREGAR PRECIO DE AUTOCINE");
            items.Add("MODIFICAR PRECIO DE AUTOCINE");
            items.Add("GENERAR REPORTES");
            items.Add("CERRAR SESION");
            Menu menu = new Menu(items, 15, 7);
            int option;
            do
            {
                menu.printItems();
                option = menu.getOption();
                switch (option)
                {
                    case 0:
                        deleteMovies();
                        break;
                    case 1:
                        addMovie();
                        break;
                    case 2:
                        selectRoom();
                        break;
                    case 3:
                        deleteCandies();
                        break;
                    case 4:
                        editCandy();
                        break;
                    case 5:
                        addCandy();
                        break;
                    case 6:
                        deleteEmployee();
                        break;
                    case 7:
                        addEmployee();
                        break;
                    case 8:
                        addBranchOffice();
                        break;
                    case 9:
                        editBranchOffice();
                        break;
                    case 10:
                        addParking();
                        break;
                    case 11:
                        editParking();
                        break;
                    case 12:
                        printReport();
                        break;
                }
            } while (option < 13);
        }

        private static void printReport()
        {
            ArrayList items = new ArrayList();
            items.Add("REPORTE DE USUARIOS  (U)");
            items.Add("REPORTE DE PELICULAS (C)");
            items.Add("REPORTE DE GOLOSINAS (G)");
            items.Add("REGRESAR");
            Menu menu = new Menu(items, 15, 7);
            menu.printItems();
            int option;
            do
            {
                Console.Clear();
                menu.printItems();
                option = menu.getOption();
                switch (option)
                {
                    case 0:
                        printUserJSON();
                        break;
                    case 1:
                        printMovieJSON();
                        break;
                    case 2:
                        printCandyJSON();
                        break;
                }
            } while (option < 3);
        }

        private static void printCandyJSON()
        {
            Console.Clear();
            string result = JsonConvert.SerializeObject(Program.cinema.candies);
            Console.WriteLine(result);
            printJSON(result, "candies.json");
            Console.ReadKey();
        }

        private static void printMovieJSON()
        {
            Console.Clear();
            string result = JsonConvert.SerializeObject(Program.cinema.movies);
            Console.WriteLine(result);
            printJSON(result, "movies.json");
            Console.ReadKey();
        }

        private static void printUserJSON()
        {
            Console.Clear();
            string result = JsonConvert.SerializeObject(Program.cinema.users);
            Console.WriteLine(result);
            printJSON(result, "users.json");
            Console.ReadKey();
        }

        private static void printJSON(string json, string name)
        {
            Console.Clear();
            Console.WriteLine(json);
            try
            {
                string path = Directory.GetCurrentDirectory();
                Console.WriteLine(path + "\\"+name);
                string[] separatingStrings = { "}]}" };
                using (StreamWriter output = new StreamWriter(path + "\\"+name))
                {
                    output.WriteLine(json);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR, NO SE PUEDE CREAR EL ARCHIVO tickets.json\nError: {0}", e.ToString());
            }
        }


        private static void addEmployee()
        {
            RegisterControl registerControl = new RegisterControl();
            if (registerControl.register())
            {
                Console.Clear();
                Console.WriteLine("NUEVO EMPLEADO REGISTRADO CON EXITO");
                Console.ReadKey();
            }
        }

        private static void deleteEmployee()
        {
            int index = showEmployee("Seleccione el empleado a eliminar");
            if (Program.cinema.users.Count > 0 && index > -1) Program.cinema.users.RemoveAt(index);
        }

        private static void showEmployeeMenu()
        {
            Console.Clear();
            ArrayList items = new ArrayList();
            items.Add("ELIMINAR PELICULAS");
            items.Add("AGREGAR PELICULAS");
            items.Add("MODIFICAR SALAS");
            items.Add("ELIMINAR GOLOSINA");
            items.Add("MODIFICAR GOLOSINA");
            items.Add("GREGAR GOLOSINA");
            items.Add("AGREGAR SUCURSALES");
            items.Add("MODIFICAR SUCURSALES");
            items.Add("AGREGAR PRECIO DE AUTOCINE");
            items.Add("MODIFICAR PRECIO DE AUTOCINE");
            items.Add("CERRAR SESION");
            Menu menu = new Menu(items, 15, 7);
            int option;
            do
            {
                menu.printItems();
                option = menu.getOption();
                switch (option)
                {
                    case 0:
                        deleteMovies();
                        break;
                    case 1:
                        addMovie();
                        break;
                    case 2:
                        selectRoom();
                        break;
                    case 3:
                        deleteCandies();
                        break;
                    case 4:
                        editCandy();
                        break;
                    case 5:
                        addCandy();
                        break;
                    case 6:
                        addBranchOffice();
                        break;
                    case 7:
                        editBranchOffice();
                        break;
                    case 8:
                        addParking();
                        break;
                    case 9:
                        editParking();
                        break;
                }
            } while (option < 10);

        }

        private static void addParking()
        {
            int index = showBranch("SELECCIONE LA SUCURSAL");
            if (index >= 0 && index < Program.cinema.branchs.Count)
            {
                ParkingControl parking = new ParkingControl(index);
                if (parking.edit())
                {
                    Console.Clear();
                    Console.WriteLine("PARQUEO AGREGADO CON EXITO");
                    Console.ReadKey();
                }
            }
        }

        private static void editParking()
        {
            int index = showBranch("SELECCIONE LA SUCURSAL");
            if (index >= 0 && index < Program.cinema.branchs.Count)
            {
                int indexParking = showParking(index);
                BranchOffice br = Program.cinema.branchs.ToArray()[index];
                if(indexParking>=0 && indexParking < br.parking.Count)
                {
                    ParkingControl parking = new ParkingControl(index, indexParking);
                    if (parking.edit())
                    {
                        Console.Clear();
                        Console.WriteLine("PARQUEO AGREGADO CON EXITO");
                        Console.ReadKey();
                    }
                }
            }
        }

        private static int showParking(int index)
        {
            BranchOffice br = Program.cinema.branchs.ToArray()[index];
            Console.Clear();
            ArrayList items = new ArrayList();
            foreach (Parking p in br.parking)
            {
                items.Add(String.Format("{0}\t{1}\t{2}", p.name, p.price, p.capacity));
            }
            items.Add("REGRESAR");
            Menu menu = new Menu(items, 15, 7, "Seleccione el parqueo");
            menu.printItems();
            int option = menu.getOption();
            return option;
        }

        private static void addBranchOffice()
        {
            BranchOfficeControl branchOffice = new BranchOfficeControl();
            if (branchOffice.editBranch())
            {
                Console.Clear();
                Console.WriteLine("SUCURSAL AGREGADA CON EXITO");
                Console.ReadKey();
            }
        }

        private static void editBranchOffice()
        {
            int index = showBranch("SELECCIONE LA SUCURSAL");
            if (index >= 0 && index < Program.cinema.branchs.Count)
            {
                BranchOfficeControl branchOffice = new BranchOfficeControl(index);
                if (branchOffice.editBranch())
                {
                    Console.Clear();
                    Console.WriteLine("SUCURSAL EDITADA CON EXITO");
                    Console.ReadKey();
                }
            }
        }

        private static int showBranch(string v)
        {
            Console.Clear();
            ArrayList items = new ArrayList();
            foreach (BranchOffice br in Program.cinema.branchs)
            {
                items.Add(String.Format("{0}", br.name));
            }
            items.Add("REGRESAR");
            Menu menu = new Menu(items, 15, 7, "Seleccione una opcion");
            menu.printItems();
            int option = menu.getOption();
            return option;
        }

        private static void addMovie()
        {
            MovieControl movieControl = new MovieControl();
            if (movieControl.editMovie())
            {
                Console.Clear();
                Console.WriteLine("PELICULA AGREGADA CON EXITO");
                Console.ReadKey();
            }
        }

        private static void addCandy()
        {
            CandyControl candyControl = new CandyControl();
            if (candyControl.editCandy())
            {
                Console.Clear();
                Console.WriteLine("GOLOSINA AGREGADA CON EXITO");
                Console.ReadKey();
            }
        }

        private static void editCandy()
        {
            int index = showCandies("Seleccione la golosina a editar");
            if(index < Program.cinema.candies.Count)
            {
                CandyControl candyControl = new CandyControl(index);
                if (candyControl.editCandy())
                {
                    Console.Clear();
                    Console.WriteLine("EDITADO CON EXITO");
                    Console.ReadKey();
                }
            }
        }

        private static void selectRoom()
        {
            int option = showRooms();
            if (option<3)
            {
                RoomControl roomControl = new RoomControl(option);
                if (roomControl.editRoom())
                {
                    Console.Clear();
                    Console.WriteLine("Editado");
                    Console.ReadKey();
                }
            }
        }

        private static int showRooms()
        {
            Console.Clear();
            ArrayList items = new ArrayList();
            foreach (Room room in Program.cinema.rooms)
            {
                items.Add(String.Format("{0}\t{1}\t${2}", room.id, room.type, room.price));
            }
            items.Add("REGRESAR");
            Menu menu = new Menu(items, 15, 7, "Seleccione una opcion a editar");
            menu.printItems();
            int option = menu.getOption();
            return option;
        }

        private static void deleteCandies()
        {
            int index = showCandies("Presione enter sobre el dato a eliminar");
            if(Program.cinema.candies.Count>0 && index< Program.cinema.candies.Count) Program.cinema.candies.RemoveAt(index);
        }

        private static void deleteMovies()
        {
            int index = showMovies("Presione enter sobre el dato a eliminar");
            if(Program.cinema.movies.Count>0 && index < Program.cinema.movies.Count) Program.cinema.movies.RemoveAt(index);
        }

        private static void showClientMenu()
        {
            ArrayList items = new ArrayList();
            items.Add("VER CARTELERA");
            items.Add("VER GOLOSINAS");
            items.Add("COMPRAR BOLETO");
            items.Add("COMPRAR GOLOSINA");
            items.Add("CERRAR SESION");
            Menu menu = new Menu(items, 15, 7);
            menu.printItems();
            int option;
            do
            {
                Console.Clear();
                menu.printItems();
                option = menu.getOption();
                switch (option)
                {
                    case 0:
                        showMovies("Presione enter para volver al menu");
                        break;
                    case 1:
                        showCandies("Presione enter para volver al menu");
                        break;
                    case 2:
                        getMovie();
                        break;
                    case 3:
                        getCandy();
                        break;
                }
            } while (option < 4);


        }

        private static void getCandy()
        {
            int index = showCandies("SELECCIONE LA GOLOSINA A COMPRAR");
            if (index >= 0 && index < Program.cinema.candies.Count)
            {
                ArrayList items2 = new ArrayList();
                Candy candy = Program.cinema.candies.ToArray()[index];
                items2.Add("Dulce: "+candy.name);
                items2.Add("Precion: $" + candy.price);

                VentaControl venta = new VentaControl(index, items2, 20);
                if (venta.newVenta())
                {
                    Console.Clear();
                    Console.WriteLine("GOLOSINA COMPRADA CON EXITO");
                    Console.ReadKey();
                }
            }
        }

        private static void getMovie()
        {
            int index = showMovies("SELECCIONE LA PELICULA QUE DESEA");
            if(index>=0 && index < Program.cinema.movies.Count)
            {
                Console.Clear();
                ArrayList items = new ArrayList();
                Movie movie = Program.cinema.movies.ToArray()[index];
                foreach(Room r in movie.rooms)
                {
                    items.Add(String.Format("Tipo: {0}, precio: ${1}, disponible: {2} ", r.type, r.price, r.free));
                }
                items.Add("SALIR");
                Menu menu = new Menu(items, 15, 7, "SELECCIONE LA SALA QUE DESEA");
                menu.printItems();
                int option = menu.getOption();
                if(option>=0 && option < items.Count - 1)
                {
                    Room room = movie.rooms.ToArray()[option];
                    ArrayList items2 = new ArrayList();
                    items2.Add("Pelicula: " + movie.name);
                    items2.Add("Sala: " + room.type);
                    items2.Add("Precio por boleto: $" + room.price);
                    VentaControl venta = new VentaControl(index, option, room.free, items2);
                    if (venta.newVenta())
                    {
                        Console.Clear();
                        Seat seat = new Seat(room.rows, room.columns, room.matriz);
                        List<OptionSeat> value = seat.getIndex(venta.quantity, movie.name);
                        foreach (OptionSeat val in value)
                        {
                            room.matriz[val.y][val.x] = false;
                        }
                        Console.SetCursorPosition(0,11);
                        Console.WriteLine("PELICULA RESERVADA CON EXITO");
                        Console.ReadKey();
                    }
                }
            }
        }

        private static int showCandies(string footer)
        {
            Console.Clear();
            ArrayList items = new ArrayList();
            foreach (Candy candy in Program.cinema.candies)
            {
                items.Add(String.Format("{0}\t{1}\t${2}", candy.id, candy.name, candy.price));
            }
            items.Add("REGRESAR");
            Menu menu = new Menu(items, 15, 7, footer);
            menu.printItems();
            int option = menu.getOption();
            return option;
        }

        private static int showMovies(string footer)
        {
            Console.Clear();
            ArrayList items = new ArrayList();
            foreach (Movie movie in Program.cinema.movies)
            {
                items.Add(String.Format("{0}\t{1}\t {2}", movie.id, movie.name, movie.type));
            }
            items.Add("REGRESAR");
            Menu menu = new Menu(items, 15, 7, footer);
            menu.printItems();
            int option = menu.getOption();
            return option;
        }


        private static int showEmployee(string footer)
        {
            Console.Clear();
            ArrayList items = new ArrayList();
            List<int> index = new List<int>();
            int i = 0;
            foreach (User user in Program.cinema.users)
            {
                if(user.code == EMPLOYEE)
                {
                    items.Add(String.Format("{0}\t{1}\t{2}", user.code, user.name, user.username));
                    index.Add(i);
                }
                i++;
            }
            items.Add("REGRESAR");
            Menu menu = new Menu(items, 15, 7, footer);
            menu.printItems();
            int option = menu.getOption();
            return index.Count>0 && option<items.Count -1? index.ToArray()[option]:-1;
        }

    }
}
