using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    class User
    {
        public string name      { set; get; }
        public string surname   { set; get; }
        public string email     { set; get; }
        public string phone     { set; get; }
        public string birthday  { set; get; }
        public string gender    { set; get; }
        public string username  { set; get; }
        public string password  { set; get; }
        public int code { set; get; } //0 = cliente 777 = Empleado

        public User(string name, string surname, string email, string phone, string birthday, string gender, string username, string password){
                this.name = name;
                this.surname = surname;
                this.email = email;
                this.phone = phone;
                this.birthday = birthday;
                this.gender = gender;
                this.username = username;
                this.password = password;
                code = 7;
            }


        
    }
}
