using BillingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Controller;
using BillingSystem.Helper.ViewHelpers;

namespace BillingSystem.View
{
    static class RegisterAssociateMenu
    {
        public static void Show (BillingSystemApp myApp, WaterConsumption myWCR)
        {
            var myAppI = myApp;
            Console.WriteLine("Associate’s ID:");
            string id = Console.ReadLine();
            bool convert = ViewHelper.VerifyNumber(id);

            if(convert)
            {
            int idNum = ViewHelper.ConvertNumber(id);
            Console.WriteLine("Associate’s Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Associate’s Last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Associate’s direction:");
            string direction = Console.ReadLine();
            var associate = new Associate();
            associate.Id = idNum;
            associate.Name = name;
            associate.Lastname = lastName;
            associate.Direction = direction;
            try
            {
                myApp.RegisterMember(associate);
                Console.WriteLine("Associate Added Succesfully!");
                MainMenu.Show(myApp, myWCR);

            }
            catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
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
