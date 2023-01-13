using System.Globalization;

namespace BillingSystem.Helper
{
    public static class DateTimeHandler
    {
        private static readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("es-BO");

        //This converts string to dateTime
        public static DateTime ConvertStringToDateTime(string strDateTime)
        {
            return DateTime.Parse(strDateTime, culture); //"31/03/2017"
        }

        //This one converts a dateTime to String
        public static string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }

        //This verifies if the string is able to be converted to a dateTime
        public static bool CheckIfStringIsDateTime(string dateTime)
        {
            return DateTime.TryParse(dateTime, out var date);
        }


    }
}
