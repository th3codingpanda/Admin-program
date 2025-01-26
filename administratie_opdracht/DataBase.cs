using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace administratie_opdracht
{

    internal class DataBase
    {
        public List<User> userslist = new List<User>();
        public void PopulateUserList(User temp)
        {            
            userslist.Add(temp);

        }
        public void SetupClass()
        {
            DirectoryInfo d = new DirectoryInfo(@".\\Users\\");
            FileInfo[] Files = d.GetFiles("*.json");
            foreach (FileInfo file in Files)
            {
                string json = System.IO.File.ReadAllText($".\\Users\\{file.Name}");
                User User1 = JsonConvert.DeserializeObject<User>(json);

                PopulateUserList(User1);
            }
        }

        }
}
