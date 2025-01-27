using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace administratie_opdracht
{
    internal class LoggedInMenuSetup
    {
        string Menu;

        public void LoggedinMenu(string Username, bool IsAdmin)
        {
            if (IsAdmin)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.WriteLine("Enter menu Debug/Delete (user)/Edit (user)");
                Menu = Console.ReadLine().ToLower();
                if (Menu == "debug")
                {
                    DebugMenuSetup debugMenuSetup = new DebugMenuSetup();
                    debugMenuSetup.DebugMenu(Username);

                }
                else if (Menu == "delete user" || Menu == "delete")
                {

                }
                else if (Menu == "edit user" || Menu == "edit")
                {
                    Console.WriteLine("Enter The user you want to edit");
                    Menu = Console.ReadLine();
                    EditUser editUser = new EditUser();
                    editUser.EditUsers(Menu, IsAdmin, Username);

                }
            }
            else {
                Console.Clear();

                //have check with streamreader adminusers to check if user is an admin
                Console.WriteLine("Enter menu Delete/Edit");
                Menu = Console.ReadLine().ToLower();
      
                if (Menu == "delete")
                {

                }
                else if (Menu == "edit")
                {


                }
                else
                {

                }

            }
            
        }
    }
}
