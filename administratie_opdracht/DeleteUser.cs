using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{

    internal class DeleteUser
    {
        DataBase db = new DataBase();
        string Menu;
        LoggedInMenuSetup loggedInMenuSetup = new LoggedInMenuSetup();
        public void DeleteUsers(string Username, bool IsChangerAdmin, string adminuser)
        {
            if (IsChangerAdmin)
            {
                foreach (User Users in db.userslist)
                {
                    if (Users.Username.ToLower() == Username.ToLower() && Users.IsAdmin == false)
                    {
                        Console.WriteLine("are you sure you want to delete " + Username);
                        Menu = Console.ReadLine().ToLower();
                        if (Menu == "yes")
                        {
                            File.Delete($".\\Users\\{Username}.json");
                            Console.WriteLine("deleted " + Username);
                            Task.Delay(1000).Wait();
                            loggedInMenuSetup.LoggedinMenu(adminuser, true);
                            return;
                        }
                        else
                        {
                            loggedInMenuSetup.LoggedinMenu(adminuser, true);
                            return;
                        }

                    }
                    else if (Users.Username.ToLower() == Username.ToLower() && Users.IsAdmin == true)
                    {
                        Console.WriteLine("Can not delete admin users *cough* Hidde");
                        Task.Delay(1000).Wait();
                        loggedInMenuSetup.LoggedinMenu(adminuser, true);
                        return;
                    }
                }
                Console.WriteLine("Enter a valid username");
                Task.Delay(1000).Wait();
                loggedInMenuSetup.LoggedinMenu(adminuser, true);
                return;
            }
            else
            {
                foreach (User Users in db.userslist)
                {
                    if (Users.Username.ToLower() == Username.ToLower())
                    {
                        Console.WriteLine("are you sure you want to delete " + Username);
                        Menu = Console.ReadLine().ToLower();
                        if (Menu == "yes")
                        {
                            File.Delete($".\\Users\\{Username}.json");
                            Console.WriteLine("deleted " + Username);
                            Task.Delay(1000).Wait();
                            MainMenuSetup mainMenuSetup = new MainMenuSetup();
                            mainMenuSetup.MainMenu();
                            return;
                        }
                        else {
                            loggedInMenuSetup.LoggedinMenu(Username, false);
                        }
                        }
                }
            }
        }
    }
}
