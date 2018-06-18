using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using Capstone.CLIMenus;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
			MainMenu mainMenu = new MainMenu();
			mainMenu.Display();
        }
    }
}
