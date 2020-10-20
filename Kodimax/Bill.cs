using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Bill
    {
        private string _concept;
        private int _quantity;
        private double _price;


        public Bill(string concept, int quantity, double price)
        {
            _concept = concept;
            _quantity = quantity;
            _price = price;
        }


        public string concept
        {
            set
            {
                _concept = value;
            }
            get
            {
                return _concept;
            }
        }

        public int quantity
        {
            set
            {
                _quantity = value;
            }
            get
            {
                return _quantity;
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

    }
}
