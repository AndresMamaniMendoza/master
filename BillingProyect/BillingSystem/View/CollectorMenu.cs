using BillingSystem.Controller;
using BillingSystem.Helper.ViewHelpers;
using BillingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.View
{
    internal class CollectorMenu
    {
        public static void Show(BillingSystemApp myApp, WaterConsumption myWCR)
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
                    Console.WriteLine($"Total Amount = {myApp.associateList.Find(x => x.Id = idNum)}");
                    string reading = Console.ReadLine();
                    //Verify reading
                    bool convertRead = ViewHelper.VerifyNumber(reading);
                    if (convertRead)
                    {
                        int readingNum = ViewHelper.ConvertNumber(reading);

                        Console.WriteLine("Date:");
                        string date = Console.ReadLine();
                        List<string> attributes = new();
                        attributes.Add(date);
                        attributes.Add(reading);
                        try
                        {
                            myWCR.LoadAttributes(attributes);
                            Console.WriteLine("Reading registered");
                            MainMenu.Show(myApp, myWCR);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Show(myAppI, myWCR);
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR: please enter integers only");
                        Show(myAppI, myWCR);
                    }

                }
                else
                {
                    Console.WriteLine("ERROR: associate not found");
                    Show(myAppI, myWCR);
                }
            }
            else
            {
                Console.WriteLine("ERROR: Wrong Identification document");
                Show(myAppI, myWCR);
            }

        }

    }
}

