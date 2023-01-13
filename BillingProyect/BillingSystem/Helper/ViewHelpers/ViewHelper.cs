using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Helper.ViewHelpers
{
    static class ViewHelper
    {
        public static bool VerifyNumber(string id)
        {
            return int.TryParse(id, out var idNum);
        }

        public static int ConvertNumber(string num)
        {
            return int.Parse(num);
        }




            //int idNum = 0;
            //bool success = int.TryParse(id, out idNum);
            //if (!success)
            //{
            //    Console.WriteLine("ERROR: Wrong Identification document");
            //    return 0;
            //}
            //return idNum;
    }
}
