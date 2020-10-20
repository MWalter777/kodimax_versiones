using Newtonsoft.Json;
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
        private List<Bill> _bills;

        public BranchOffice()
        {
            _parking = new List<Parking>();
            _bills = new List<Bill>();
        }

        public BranchOffice(string name) : this()
        {
            _name = name;
        }

        [JsonIgnore]
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

        public List<Bill> bills
        {
            set
            {
                _bills = value;
            }
            get
            {
                return _bills;
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
