namespace BillingSystem.Model
{
    public class Associate : User
    {
        public List<WaterConsumption> waterConsumptionList = new List<WaterConsumption>();
        public void AddConsumption(WaterConsumption waterConsumption)
        {
            waterConsumptionList.Add(waterConsumption);
        }
    }
}
