using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Movie
    {
        public int id { set; get; }
        public string name { set; get; }
        public string duration { set; get; }
        public string type { set; get; }
        [JsonIgnore]
        public List<Room> rooms = new List<Room>();

        public Movie(int id, string name, string duration, string type)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.type = type;
        }

        public Movie(int id, string name, string duration, string type, Room room) : this(id, name, duration, type)
        {
            rooms.Add(room);
        }


    }
}
