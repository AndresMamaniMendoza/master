using BillingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Controller;

namespace BillingSystem.View
{
    static class RegisterAssociateMenu
    {
        public static void Show (BillingSystemApp myApp)
        {
            var myAppI = myApp;
            Console.WriteLine("(To cancel enter the letter C)");
            Console.WriteLine("Associate’s ID:");
            string id = Console.ReadLine();
            int idNum = verificateID(id);
            if(idNum !=0)
            {
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
                MainMenu.Show(myApp);

            }
            catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            }
            else
            {
                Show(myAppI);
            }

        }

        public static int verificateID(string id)
        {
            int idNum = 0;
            bool success = int.TryParse(id, out idNum);
            if(!success)
            {
                Console.WriteLine("ERROR: Wrong Identification document"); 
                return 0;
            }
            return idNum;
            
        }


    }
}
