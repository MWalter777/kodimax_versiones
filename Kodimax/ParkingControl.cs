using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class ParkingControl
    {
        private BranchOffice _branchOffice;
        private Parking _parking;
        private string _name;
        private double _price;
        private int _capacity;
        private bool _edit;
        private int _index;
        private int _indexParking;


        public ParkingControl(int index)
        {
            _branchOffice = Program.cinema.branchs.ToArray()[index];
            _edit = false;
            _name = null;
            _price = -1;
            _capacity = -1;
            _index = index;
        }

        public ParkingControl(int index, int indexParking)
        {
            if (index >= 0 && index < Program.cinema.branchs.Count)
            {
                _branchOffice = Program.cinema.branchs.ToArray()[index];
                if (indexParking>=0 && indexParking< _branchOffice.parking.Count)
                {
                    _parking = _branchOffice.parking.ToArray()[indexParking];
                    _name = _parking.name;
                    _price = _parking.price;
                    _capacity = _parking.capacity;
                    _edit = true;
                    _index = index;
                    _indexParking = indexParking;
                }else
                {
                    _parking = null;
                }
            }
        }

        public bool edit()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("Nombre del parqueo {0}:", _name != null ? "(anterior = " + _name + ")" : "");
            _name = Console.ReadLine();

            do
            {
                try
                {
                    Console.WriteLine("");
                    Console.Write("Precio de estacionamiento {0}:", _price > 0 ? "(anterior = " + _price + ")" : "");
                    _price = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    _price = -1;
                }
            } while (_price < 0);

            do
            {
                try
                {
                    Console.WriteLine("");
                    Console.Write("Capacidad {0}: ", _capacity > 0 ? _name : "");
                    _capacity = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    _capacity = -1;
                }
            } while (_capacity < 0);

            if(_parking == null)
            {
                _parking = new Parking(_name, _price, _capacity);
                if (!_edit)
                {
                    _branchOffice.parking.Add(_parking);
                }
            }
            else
            {
                _parking.name = _name;
                _parking.capacity = _capacity;
                _parking.price = _price;
            }

            return true;
        }

    }
}
