using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace administratie_opdracht
{
    internal class AddUsersToClass
    {

        public void SetupClass()
        {
            DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
            FileInfo[] Files = d.GetFiles("*.json"); 

            string Username = "";
            string Password = "";
            string IsAdmin = "";
            bool IsAdministrator = false;
            foreach (FileInfo file in Files)
            {
                string json = System.IO.File.ReadAllText($".\\Users\\{file.Name}");
                User deserialize = JsonConvert.DeserializeObject<User>(json);
                Console.WriteLine(deserialize.Username);
                Console.WriteLine(deserialize.Password);
                Console.WriteLine(deserialize.IsAdmin);
                int currentLineNumber = 0;


                StreamReader sr = new StreamReader($".\\Users\\{file.Name}");
                string[] lines = File.ReadAllLines($".\\Users\\{file.Name}");
                foreach (string line in lines)
                {
                    IsAdministrator = false;
                    currentLineNumber++;
                    switch (currentLineNumber) {
                    //case 0:
                    }

                    if (currentLineNumber == 1) {
                     

                    }
                    if (currentLineNumber == 2) {
                        Password = line.Replace("Password:\t\t\t", "");
                    }
                    if (currentLineNumber == 3) {
                        IsAdmin = line.Replace("IsAdmin:\t\t\t", "");
                        if (IsAdmin.ToLower() == "true") {
                        IsAdministrator = true;

                        }

                    }

                }

                User user1 = new User(Username, Password, IsAdministrator);
                DataBase dataBase = new DataBase();
                dataBase.ListAdd(user1);
                sr.Close();
                

            }


        }

    }
    }

