using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Parking
    {
        private string _name;
        private double _price;
        private int _capacity;

        public Parking(string name, double price, int capacity)
        {
            _name = name;
            _price = price;
            _capacity = capacity;
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

        public double price
        {
            set
            {
                _price = value;
            }
            get
            {
                return _price;
            }
        }

        public int capacity
        {
            set
            {
                _capacity = value;
            }
            get
            {
                return _capacity;
            }
        }

    }
}
