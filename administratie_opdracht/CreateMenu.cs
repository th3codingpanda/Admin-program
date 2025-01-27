using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{
    internal class CreateMenu
    {
        public async Task Createuser(bool AdminStatus) {
            Console.Clear();
            Console.WriteLine("enter a username");
            string aUserName = Console.ReadLine();
            if (aUserName.Length > 15) {
                Console.WriteLine("Please create a Username that is shorter than 15 characters");
                Task.Delay(1000).Wait();
                Createuser(AdminStatus);
                return;
            }
            DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
            FileInfo[] Files = d.GetFiles("*.json"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                if ((aUserName + ".json").ToLower() == file.Name.ToLower())
                {
                    Console.WriteLine("username is already taken");
                    Task.Delay(1000).Wait();
                    Createuser(AdminStatus);
                    return;
                    // reading thru all the txt files to see if user is not already taken
                } 
            }
            Console.WriteLine("Create password max 15 char");
            string aPassWord = Console.ReadLine();
            if (aPassWord.Length > 15)
            {
                Console.WriteLine("Please create a Password that is shorter than 15 characters");
                Createuser(AdminStatus);
                return;
            }
            Encrypt encrypt = new Encrypt();
            aPassWord = encrypt.encrypt(aPassWord);
            StreamWriterSetup streamWriterSetup = new StreamWriterSetup();
            streamWriterSetup.AddUser(aUserName, aPassWord , AdminStatus);
            // encrypt and give info to StreamWriter.AddUser which adds user
        }
    }
}
