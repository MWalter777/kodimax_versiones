using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class BranchOffice
    {
        private string _name;
        private List<Parking> _parking;
        private List<Ticket> _tikets;

        public BranchOffice()
        {
            _parking = new List<Parking>();
            _tikets = new List<Ticket>();
        }

        public BranchOffice(string name) : this()
        {
            _name = name;
        }

        public List<Parking> parking
        {
            set
            {
                _parking = value;
            }
            get
            {
                return _parking;
            }
        }

        public List<Ticket> tikets
        {
            set
            {
                _tikets = value;
            }
            get
            {
                return _tikets;
            }
        }

        public string name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }


    }
}
