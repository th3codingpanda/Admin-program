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
                Console.WriteLine("Enter menu Debug/Delete (user)/Edit (user)/logout");
                Menu = Console.ReadLine().ToLower();
                if (Menu == "debug")
                {
                    DebugMenuSetup debugMenuSetup = new DebugMenuSetup();
                    debugMenuSetup.DebugMenu(Username);

                }
                else if (Menu == "delete user" || Menu == "delete")
                {
                    Console.WriteLine("Enter The user you want to delete");
                    Menu = Console.ReadLine();
                    DeleteUser deleteUser = new DeleteUser();
                    deleteUser.DeleteUsers(Menu, IsAdmin, Username);
                }
                else if (Menu == "edit user" || Menu == "edit")
                {
                    Console.WriteLine("Enter The user you want to edit");
                    Menu = Console.ReadLine();
                    EditUser editUser = new EditUser();
                    editUser.EditUsers(Menu, IsAdmin, Username);
                }
                else if (Menu == "logout")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    MainMenuSetup mainMenuSetup = new MainMenuSetup();
                    mainMenuSetup.MainMenu();
                }
                else
                {
                    Console.WriteLine("enter a valid option");
                    Task.Delay(1000).Wait();
                    LoggedinMenu(Username, IsAdmin);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Enter menu Delete/Edit/logout");
                Menu = Console.ReadLine().ToLower();

                if (Menu == "delete")
                {
                    DeleteUser deleteUser = new DeleteUser();
                    deleteUser.DeleteUsers(Username, IsAdmin, "");
                }
                else if (Menu == "edit")
                {
                    EditUser editUser = new EditUser();
                    editUser.EditUsers(Username, IsAdmin, "");

                }
                else if (Menu == "logout")
                {
                    MainMenuSetup mainMenuSetup = new MainMenuSetup();
                    mainMenuSetup.MainMenu();
                }
                else
                {
                    Console.WriteLine("enter a valid option");
                    Task.Delay(1000).Wait();
                    LoggedinMenu(Username, IsAdmin);
                }

            }

        }
    }
}
