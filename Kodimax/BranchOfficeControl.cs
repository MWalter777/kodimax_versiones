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
        private bool _edit;
        private int _index;


        public BranchOfficeControl()
        {
            _branchOffice = new BranchOffice();
            _edit = false;
            _name = null;
        }

        public BranchOfficeControl(int index)
        {
            if(index>=0 && index < Program.cinema.branchs.Count)
            {
                _branchOffice = Program.cinema.branchs.ToArray()[index];
                _name = _branchOffice.name;
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

            _branchOffice.name = _name;

            if (!_edit)
            {
                Program.cinema.branchs.Add(_branchOffice);
            }

            return true;
        }


    }
}
