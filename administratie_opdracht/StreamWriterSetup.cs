using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using administratie_opdracht;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
namespace administratie_opdracht
{
    public class StreamWriterSetup
    {
        public async Task AddUser(string aUserName ,string aPassWord , bool IsAdmin)
        {
             string fileName = $".\\Users\\{aUserName}.json";
            var file_name = File.Create(fileName);
            file_name.Close();
            User newuser = new User(aUserName,aPassWord,IsAdmin);
            DataBase dataBase = new DataBase();
            string jsonString = JsonSerializer.Serialize(newuser);
            File.AppendAllText(fileName,jsonString);
            Console.WriteLine("Succesfully created: " + aUserName);
            Task.Delay(1000).Wait();
            MainMenuSetup mainMenuSetup = new MainMenuSetup();
            mainMenuSetup.MainMenu();
            return;
            }

        }
   }