using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{
    internal class EditUser
    {
        string Menu;
        DataBase db = new DataBase();
        Encrypt Encrypt = new Encrypt();
        LoggedInMenuSetup loggedInMenuSetup = new LoggedInMenuSetup();
        public void EditUsers(string Username ,bool IsChangerAdmin ,string adminuser) {
            if (IsChangerAdmin) {
                foreach (User Users in db.userslist)
                {
                    if (Users.Username.ToLower() == Username.ToLower() && Users.IsAdmin == false)
                    {
                        Console.WriteLine("What do you want to change about this user?");
                        Console.WriteLine("Password/Admin");
                        Menu = Console.ReadLine().ToLower();
                        if (Menu == "password")
                        {
                            Console.Clear();
                            Console.WriteLine("What do you want to change their password to?");
                            Menu = Console.ReadLine();
                            Users.Password = Encrypt.encrypt(Menu);
                            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Users, Newtonsoft.Json.Formatting.Indented);
                            File.WriteAllText($".\\Users\\{Username}.json", output);
                            Console.WriteLine("Changed password to " + Menu);
                            Task.Delay(1000).Wait();
                            loggedInMenuSetup.LoggedinMenu(adminuser, true);
                            return;
                        }
                        else if (Menu == "admin")
                        {
                          Users.IsAdmin = true;
                          string output = Newtonsoft.Json.JsonConvert.SerializeObject(Users, Newtonsoft.Json.Formatting.Indented);
                          File.WriteAllText($".\\Users\\{Username}.json", output);
                            Console.WriteLine("Changed IsAdmin to " + Users.IsAdmin);

                        }



                    }
                    else if (Users.Username.ToLower() == Username.ToLower() && Users.IsAdmin == true) 
                    {
                    Console.WriteLine("can not edit admin users (nice try hidde)") ;
                    Task.Delay(1000).Wait();
                        loggedInMenuSetup.LoggedinMenu(adminuser, true);

                        return;
                    }
                }
                Console.WriteLine("Please enter a valid username") ;
                Task.Delay(1000).Wait();
                loggedInMenuSetup.LoggedinMenu(adminuser, true);
                return;
            }
            else {
                foreach (User Users in db.userslist) {
                    if (Users.Username == Username)
                    {
                        Console.WriteLine("What do you want to change your password to?");
                        Menu = Console.ReadLine();
                        Users.Password = Encrypt.encrypt(Menu);
                        string output = Newtonsoft.Json.JsonConvert.SerializeObject(Users, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText($".\\Users\\{Username}.json", output);
                        Console.WriteLine("Changed password to " + Menu);
                        Task.Delay(1000).Wait();
                        MainMenuSetup mainMenuSetup = new MainMenuSetup();
                        mainMenuSetup.MainMenu();
                        return;
                    }
                }
                Console.WriteLine("how?");
            }
        }
    }
}
