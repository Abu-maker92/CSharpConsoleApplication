using ProjectA.MyApp;
using ProjectA.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory.SelectedPackage = Packages.Restaurant;
            IMyApps app = Factory.GetApp();

            app.ReadMenuSelection();

            Console.ReadLine();
        }
    }
}
