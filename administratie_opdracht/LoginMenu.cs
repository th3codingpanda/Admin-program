using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace administratie_opdracht
{
    internal class LoginMenuSetup
    {
        public async Task LoginSetup()
        {
            StreamReaderSetup streamReaderSetup = new StreamReaderSetup();

            string Menu;

            Console.Clear();
            Console.WriteLine("Enter username:");
            Menu = Console.ReadLine();
            streamReaderSetup.Login(Menu);
            //have this so that i can go back to it if u entered wrong username
            }

        }
    }