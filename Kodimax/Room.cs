using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Room : ICloneable
    {
        public int id { set; get; }
        public string type { set; get; }
        public double price { set; get; }
        public int rows { set; get; }
        public int columns { set; get; }
        public int free = 0;
        public bool[][] matriz;


        public Room(int id, string type, double price, int rows, int columns)
        {
            this.id = id;
            this.type = type;
            this.price = price;
            this.rows = rows;
            this.columns = columns;
            free = rows * columns;

            matriz = new bool[rows][];
            for(int i = 0; i < rows; i++)
            {
                matriz[i] = new bool[columns];
                for(int j = 0; j < columns; j++)
                {
                    matriz[i][j] = true;
                }
            }

        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
