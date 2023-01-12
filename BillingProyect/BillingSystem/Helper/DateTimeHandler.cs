using System.Globalization;

namespace BillingSystem.Helper
{
    public static class DateTimeHandler
    {
        private static readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("es-BO");

        public static DateTime ConvertStringToDateTime(string strDateTime)
        {
            return DateTime.Parse(strDateTime, culture); //"31/03/2017"
        }
        public static string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }
        public static bool CheckIfStringIsDateTime(string dateTime)
        {
            return DateTime.TryParse(dateTime, out var date);
        }
    }
}
