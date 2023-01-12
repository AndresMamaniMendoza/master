using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Controller;
using BillingSystem.Model;

namespace BillingSystem.View
{
    static class RegisterWConsumptionMenu
    {
        public static void Show(BillingSystemApp myApp, WaterConsumption myWCR)
        {
            var myAppI = myApp;
            Console.WriteLine("(To cancel enter the letter C)");
            Console.WriteLine("Reading in liters:");
            string reading = Console.ReadLine();
            int readingNum = verificateReading(reading);
            string date = "any";
            if (readingNum != 0)
            {
                Console.WriteLine("Date:");
                date = Console.ReadLine();
            }
            else
            {
                Show(myAppI, myWCR);
            }
            List<string> attributes = new();
            attributes.Add(date);
            attributes.Add(reading);
            try
            {
                myWCR.LoadAttributes(attributes);
                Console.WriteLine("Reading registered");
                MainMenu.Show(myApp, myWCR);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static int verificateReading(string rNum)
        {
            int rNumI = 0;
            bool success = int.TryParse(rNum, out rNumI);
            if (!success)
            {
                Console.WriteLine("ERROR: please enter integers only.");
                return 0;
            }
            return rNumI;

        }

    }
}
