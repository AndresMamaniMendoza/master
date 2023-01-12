using BillingSystem.Helper;

namespace BillingSystem.Model
{
    public class WaterConsumption
    {
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }

        public void LoadAttributes(List<string> attributesList)
        { 
            if (!DateTimeHandler.CheckIfStringIsDateTime(attributesList[0])) // 10/10/2022
            {
                throw new Exception("Invalid Date.");
            }
            int number;
            if (!int.TryParse(attributesList[1], out number))
            {
                throw new Exception("ERROR: please enter integers only.");
            }
            DateTime = DateTimeHandler.ConvertStringToDateTime(attributesList[0]);
            Amount = int.Parse(attributesList[1]); ;
        }
    }
}
