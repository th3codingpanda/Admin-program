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

    /*public async Task Login(string aUsername)
    {

        LoginMenuSetup loginMenuSetup = new LoginMenuSetup();
        //used to go back to loginmenu
        DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
        bool Correct = false;
        FileInfo[] Files = d.GetFiles("*.json"); //Getting Text files

        foreach (FileInfo file in Files)
        {
            //loop thru files to check if username exist
            if ((aUsername + ".json").ToLower() == file.Name.ToLower())
            {
                Correct = true;
                Console.Clear();
                Console.WriteLine("Enter Back or password:");
                string aPassWord = Console.ReadLine();
                if (aPassWord.ToLower() == "back")
                {
                    Correct = false;
                    loginMenuSetup.LoginSetup();
                    return;
                }
                else
                {
                    Encrypt encrypt = new Encrypt();
                    aPassWord = encrypt.encrypt(aPassWord);
                }
                string fileName = $".\\Users\\{aUsername}.json";
                LoggedInMenuSetup login = new LoggedInMenuSetup();
                if (File.ReadAllText(fileName) == $"Username:\t\t\t{aUsername}\nPassword:\t\t\t{aPassWord}\nIsAdmin:\t\t\tFalse")
                {
                    Console.WriteLine("Logged in as:" + aUsername);
                    Task.Delay(1000).Wait();
                    login.LoggedinMenu(aUsername, false);
                }
                else if (File.ReadAllText(fileName) == $"Username:\t\t\t{aUsername}\nPassword:\t\t\t{aPassWord}\nIsAdmin:\t\t\tTrue")
                {
                    Console.WriteLine("Logged in as Admin:" + aUsername);
                    Task.Delay(1000).Wait();
                    login.LoggedinMenu(aUsername, true);

                }
                else
                {
                    Correct = false;
                    Console.WriteLine("Wrong password");
                    Task.Delay(1000).Wait();
                    Login(aUsername);
                    return;
                }
            }
        }
        if (!Correct)
        {
            Console.WriteLine("Wrong Username");
            Task.Delay(1000).Wait();
            loginMenuSetup.LoginSetup();
            return;
        }
        //else
        //
        //    Correct = false;
        //}
    }*/
    /* public async Task Delete(string username) {
         if (username == "admin") {
             Console.WriteLine("What account do you want to delete?");
             string Menu = Console.ReadLine();
         }
         else
         {
             LoginMenuSetup loginMenuSetup = new LoginMenuSetup();
             DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
             FileInfo[] Files = d.GetFiles("*.json");
             foreach (FileInfo file in Files)
             {
                 if (username + ".json" == file.Name)
                 {
                     Console.WriteLine("are you sure you want to delete: " + username);
                 }
             }

         }
     }
       */
}










