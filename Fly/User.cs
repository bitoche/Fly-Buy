using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public long Balance { get; set; }
        public User()
        {

        }
        public User(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
            Balance = 0;
        }


    }
    public enum Role { Common, Administrator, Accountant, Pilot, Reservist }
}
