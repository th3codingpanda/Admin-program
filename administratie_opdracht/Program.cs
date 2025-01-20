using administratie_opdracht;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Timers;

namespace Administration_Program;

public class Administration_Program()
{

    public static void Main() {
        MainMenuSetup menuSetup = new MainMenuSetup();
        menuSetup.MainMenu();
        //just runs the start program (could just be put in program lol)
        
    }
}
