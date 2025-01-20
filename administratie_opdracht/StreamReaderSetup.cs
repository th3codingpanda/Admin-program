using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht;

public class StreamReaderSetup
{
    public async Task Login(string aUsername)
    {

        LoginMenuSetup loginMenuSetup = new LoginMenuSetup();
        //used to go back to loginmenu
        DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
        bool Correct = false;
        FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files

        foreach (FileInfo file in Files)
        {
            //loop thru files to check if username exist
            if ((aUsername + ".txt").ToLower() == file.Name.ToLower())
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
                string fileName = $".\\Users\\{aUsername}.txt";
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
        else
        {
            Correct = false;
        }
    }
    /* public async Task Delete(string username) {
         if (username == "admin") {
             Console.WriteLine("What account do you want to delete?");
             string Menu = Console.ReadLine();
         }
         else
         {
             LoginMenuSetup loginMenuSetup = new LoginMenuSetup();
             DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
             FileInfo[] Files = d.GetFiles("*.txt");
             foreach (FileInfo file in Files)
             {
                 if (username + ".txt" == file.Name)
                 {
                     Console.WriteLine("are you sure you want to delete: " + username);
                 }
             }

         }
     }
       */
}










