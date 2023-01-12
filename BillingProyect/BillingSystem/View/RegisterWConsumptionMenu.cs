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
        public static void Show(BillingSystemApp myApp)
        {
            var myAppI = myApp;
            Console.WriteLine("(To cancel enter the letter C)");
            Console.WriteLine("Reading in liters:");
            string reading = Console.ReadLine();
            int readingNum = verificateReading(reading);
            if (readingNum != 0)
            {
                Console.WriteLine("Date:");
                string name = Console.ReadLine();
            }
            else
            {
                Show(myAppI);
            }

        }

        public static int verificateReading(string id)
        {
            int idNum = 0;
            bool success = int.TryParse(id, out idNum);
            if (!success)
            {
                Console.WriteLine("ERROR: Wrong Identification document");
                return 0;
            }
            return idNum;

        }

    }
}
