using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class Cinema
    {
        public string name  { set; get; }
        public List<Room> rooms = new List<Room>();
        public List<Movie> movies = new List<Movie>();
        public List<Ticket> tickes = new List<Ticket>();
        public List<User> users = new List<User>();
        public List<Candy> candies = new List<Candy>();
        public List<BranchOffice> branchs = new List<BranchOffice>();

        public Cinema(string name)
        {
            this.name = name;
        }


    }
}
