using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht;

public class StreamReaderSetup
{
    LoginMenuSetup loginMenuSetup = new LoginMenuSetup();
    public void Login(string username) {
        DataBase addUsersToClass = new DataBase();
        addUsersToClass.SetupClass();
        foreach (User user in addUsersToClass.userslist)
        {
            if (user.Username.ToLower() == username.ToLower()) {
                Console.WriteLine("Enter password or type back");
                Encrypt encrypt = new Encrypt();
                string menu = Console.ReadLine();
                if (menu.ToLower() == "back")
                {
                    loginMenuSetup.LoginSetup();
                    return;
                }
                else {
                  menu = encrypt.encrypt(menu);
                }
                if (menu == user.Password)
                {
                    Console.WriteLine("Logged in as:" + user.Username);
                    Task.Delay(1000).Wait();
                    LoggedInMenuSetup loggedInMenuSetup = new LoggedInMenuSetup();
                    loggedInMenuSetup.LoggedinMenu(user.Username, user.IsAdmin);
                    return;
                }
                else
                {
                    Console.WriteLine("incorrect password");
                    Task.Delay(1000).Wait();
                    Login(username);
                }
            }
        }
        Console.WriteLine("incorrect username");
        Task.Delay (1000).Wait();
        loginMenuSetup.LoginSetup();
        return;
    }
}










