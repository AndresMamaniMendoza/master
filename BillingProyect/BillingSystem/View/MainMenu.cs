using BillingSystem.Controller;
using BillingSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.View
{
    public static class MainMenu
    {
        public static void Show(BillingSystemApp myApp, WaterConsumption myWCR)
        {
            var myAppI = myApp;
            Console.WriteLine("*--------------------- WELCOME TO WACO 3.8 ---------------------*\n");
            Console.WriteLine("ENTER A NUMBER ACCORDING TO YOUR SELECTION");
            Console.WriteLine("1- Register a new associate." + "\n2- Register a new water consumption reading.");
            string selection = (Console.ReadLine());
            switch(selection)
            {
                case "1":
                    {
                        RegisterAssociateMenu.Show(myAppI, myWCR);
                    }
                    break;
                case "2":
                    {
                        RegisterWConsumptionMenu.Show(myAppI, myWCR);
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Please enter a valid number");
                        Show(myApp, myWCR);
                    }
                    break;
            }
        }

    }
}