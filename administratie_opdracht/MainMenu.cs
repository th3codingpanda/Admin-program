using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht;


internal class MainMenuSetup
{

    public void MainMenu() {
         string Menu;
        Console.Clear();
        Console.WriteLine("Select Login/Create");
        Menu = Console.ReadLine().ToLower();
        if (Menu == "login")
        {
            LoginMenuSetup loginMenuSetup = new LoginMenuSetup();
            loginMenuSetup.LoginSetup();
        }
        else if (Menu == "create")
        {
            CreateMenu createMenu = new CreateMenu();
            createMenu.Createuser();
        }
        else {
            Console.WriteLine("enter a valid selection");
            Task.Delay(1000).Wait();
            MainMenu();
            return;
        }

    } }
// goes to CreateMenu or LoginMenu depended on userinput