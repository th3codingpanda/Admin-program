using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{
    internal class LoggedInMenuSetup
    {
        public void LoggedinMenu(string Username, bool IsAdmin)
        {
            Console.Clear();
            string Menu;
            //have check with streamreader adminusers to check if user is an admin
            Console.WriteLine("Enter menu Delete/Info");
            Menu = Console.ReadLine().ToLower();
            if (Menu == "debug")
            {
                DebugMenuSetup debugMenuSetup = new DebugMenuSetup();
                debugMenuSetup.DebugMenu();

            }
            if (Menu == "delete")
            {
            
            }
            else if (Menu == "info")
            {

            }
            else
            {

            }
        }
    }
}
