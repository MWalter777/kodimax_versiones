using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Ticket
    {
        public int id { set; get; }
        public Room room { set; get; }
        public User user { set; get; }
        public Movie movie { set; get; }
        private int quantity { set; get; }

        public Ticket(int id, Room room, User user, int quantity, Movie movie)
        {
            this.id = id;
            this.room = room;
            this.user = user;
            this.quantity = quantity;
            this.movie = movie;
        }


    }
}
