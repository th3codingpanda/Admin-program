using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace administratie_opdracht
{
    public class StreamWriterSetup
    {
        public async Task AddUser(string aUserName ,string aPassWord)
        {
             string fileName = $".\\Users\\{aUserName}.txt";



                var file_name = File.Create(fileName);
                file_name.Close();
                File.AppendAllText(fileName, $"Username:\t\t\t{aUserName}\nPassword:\t\t\t{aPassWord}\nIsAdmin:\t\t\tFalse");
                Console.WriteLine("Succesfully created: " + aUserName);
            Task.Delay(1000).Wait();
            MainMenuSetup mainMenuSetup = new MainMenuSetup();
            mainMenuSetup.MainMenu();
            
            return;

            }
        }
   }


