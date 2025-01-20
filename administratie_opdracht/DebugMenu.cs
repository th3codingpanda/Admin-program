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
        public async Task DebugMenu()
        {

            Console.WriteLine("Type exit to exit or quit to quit");
            string Menu = Console.ReadLine().ToLower();
            if (Menu == "exit")
            {
                MainMenuSetup mainMenuSetup = new MainMenuSetup();
                mainMenuSetup.MainMenu();
            }
            else if (Menu == "quit")
            {

            }
            else { Console.WriteLine("please select an option");
            Task.Delay(1000).Wait();
            DebugMenu();
            }
        }
    }
}
