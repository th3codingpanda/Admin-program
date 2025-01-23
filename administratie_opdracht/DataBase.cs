using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{

    internal class DataBase
    {
        public List<User> userslist = new List<User>();
        public void ListAdd(User temp)
        {            
            userslist.Add(temp);
            //Console.WriteLine(temp.Username);
            //Console.WriteLine(temp.Password);
            //Console.WriteLine(temp.IsAdmin);

        }

    }
}
