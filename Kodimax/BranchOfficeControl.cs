using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class BranchOfficeControl
    {
        private BranchOffice _branchOffice;
        private string _name;
        private double _price;
        private int _capacity;
        private bool _edit;
        private int _index;


        public BranchOfficeControl()
        {
            _branchOffice = new BranchOffice();
            _edit = false;
            _name = null;
            _price = -1;
            _capacity = -1;
        }

        public BranchOfficeControl(int index)
        {
            if(index>=0 && index < Program.cinema.branchs.Count)
            {
                _branchOffice = Program.cinema.branchs.ToArray()[index];
                _name = _branchOffice.name;
                _price = _branchOffice.price;
                _capacity = _branchOffice.capacity;
                _edit = true;
                _index = index;
            }
            else
            {
                _branchOffice = new BranchOffice();
            }
        }

        public bool editBranch()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("Nombre de la sucursal {0}:", _name != null ? "(anterior = "+_name+")" : "");
            _name = Console.ReadLine();

            do
            {
                try
                {
                    Console.WriteLine("");
                    Console.Write("Precio de estacionamiento {0}:", _price>0 ? "(anterior = " + _price + ")" : "");
                    _price = double.Parse(Console.ReadLine());
                }catch(Exception e)
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

            _branchOffice.name = _name;
            _branchOffice.capacity = _capacity;
            _branchOffice.price = _price;

            if (!_edit)
            {
                Program.cinema.branchs.Add(_branchOffice);
            }

            return true;
        }


    }
}
