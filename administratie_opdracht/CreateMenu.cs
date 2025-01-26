using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{
    internal class CreateMenu
    {
        public async Task Createuser(bool adming) {
            Console.Clear();
            Console.WriteLine("enter a username");
            string aUserName = Console.ReadLine();
            DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                if ((aUserName + ".txt").ToLower() == file.Name.ToLower())
                {
                    Console.WriteLine("username is already taken");
                    Task.Delay(1000).Wait();
                    Createuser(adming);
                    return;
                    // reading thru all the txt files to see if user is not already taken
                } 
            }
            Console.WriteLine("Create password");
            string aPassWord = Console.ReadLine();
            Encrypt encrypt = new Encrypt();
            aPassWord = encrypt.encrypt(aPassWord);
            StreamWriterSetup streamWriterSetup = new StreamWriterSetup();
            streamWriterSetup.AddUser(aUserName, aPassWord , adming);
            // encrypt and give info to StreamWriter.AddUser which adds user
        }
    }
}
