using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{
    internal class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin  { get; set; }
        public User(string aUsername ,string aPassword ,bool Adminstats) {
            Username = aUsername;
            Password = aPassword;
            IsAdmin = Adminstats;
        }
    }
}
