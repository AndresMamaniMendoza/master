using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Controller;
using BillingSystem.Helper.ViewHelpers;
using BillingSystem.Model;

namespace BillingSystem.View
{
    static class RegisterWConsumptionMenu
    {
        public static void Show(BillingSystemApp myApp)
        {
            var myAppI = myApp;
            Console.WriteLine("Associate’s ID:");
            string id = Console.ReadLine();
            bool convert = ViewHelper.VerifyNumber(id);
            if (convert)
            {
                int idNum = ViewHelper.ConvertNumber(id);
                bool memberExists = myApp.CheckIfMemberExist(idNum);
                if (memberExists)
                {
                    Console.WriteLine("Reading in liters:");
                    string reading = Console.ReadLine();
                    //Verify reading
                    bool convertRead = ViewHelper.VerifyNumber(reading);
                    if (convertRead)
                    {                    
                        Console.WriteLine("Date (DD/MM/YY):");
                        string date = Console.ReadLine();
                        List<string> attributes = new();
                        attributes.Add(date);
                        attributes.Add(reading);
                        WaterConsumption associateWConsumption = new WaterConsumption();
                        try
                        {
                            associateWConsumption.LoadAttributes(attributes);
                            myApp.RegisterWaterConsumptionReading(idNum, associateWConsumption);
                            Console.WriteLine("Reading registered");
                            MainMenu.Show(myApp);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Show(myAppI);
                        }
                    }else
                    {
                        Console.WriteLine("ERROR: please enter integers only");
                        Show(myAppI);
                    }

                }
                else
                {
                    Console.WriteLine("ERROR: associate not found");
                    Show(myAppI);
                }
            }
            else
            {
                Console.WriteLine("ERROR: Wrong Identification document");
                Show(myAppI);
            }

        }

    }
}
