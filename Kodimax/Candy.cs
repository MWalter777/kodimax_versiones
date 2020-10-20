using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Candy
    {
        public int id { set; get; }
        public string name { set; get; }
        public string type { set; get; }
        public double price { set; get; }

        public Candy(int id, string name, string type, double price)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.price = price;
        }


    }
}
