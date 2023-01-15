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
                    int associateTotalAmmount = myApp.CalculateTotalPayment(myApp.FindAssociateById(idNum).waterConsumptionList);
                    if (associateTotalAmmount > 0)
                    {
                        Console.WriteLine($"Total Amount = {associateTotalAmmount} Bs");
                        Console.WriteLine($"By = {myApp.FindAssociateById(idNum).waterConsumptionList.Count} Month(s)");
                        Console.WriteLine("\nDo you want to register the payment?\n1. Yes\n2. No");
                        bool choosing = true;
                        while (choosing)
                        {
                            string selection = Console.ReadLine();
                            switch (selection)
                            {
                                case "1":
                                    myApp.RegisterPayment(idNum);
                                    Console.WriteLine("Payment registered successfully\n");
                                    choosing= false;
                                    MainMenu.Show(myAppI);
                                    break;
                                case "2":
                                    choosing = false;
                                    Console.WriteLine("Payment cancelled");
                                    MainMenu.Show(myAppI);
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid option");                                    
                                    break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("The associate doesn’t has debts ");
                        MainMenu.Show(myAppI);
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

