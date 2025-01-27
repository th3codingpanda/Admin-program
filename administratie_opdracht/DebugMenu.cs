using administratie_opdracht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{
    internal class DebugMenuSetup
    {
       public string username;
        public async Task DebugMenu(string Username)
        {
            Console.Clear();
            DataBase db = new DataBase();
            foreach (User temp in db.userslist) {
                Console.WriteLine(temp.Username);
                Console.WriteLine(temp.IsAdmin);
            }


            Console.WriteLine("Type exit to exit or quit to quit");
            string Menu = Console.ReadLine().ToLower();
            if (Menu == "exit")
            {
               LoggedInMenuSetup loggedInMenuSetup = new LoggedInMenuSetup();
                loggedInMenuSetup.LoggedinMenu(Username, true);
            }
            else if (Menu == "quit")
            {

            }
            else { Console.WriteLine("please select an option");
            Task.Delay(1000).Wait();
            DebugMenu(Username);
            }
        }
    }
}
