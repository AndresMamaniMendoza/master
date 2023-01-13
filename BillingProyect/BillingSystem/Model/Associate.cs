namespace BillingSystem.Model
{
    public class Associate : User
    {
        public List<WaterConsumption> waterConsumptionList = new List<WaterConsumption>();

        public List<Payment> paymentList = new List<Payment>();

        public List<Debts> debtsList = new List<Debts>();
        public void AddConsumption(WaterConsumption waterConsumption)
        {
            waterConsumptionList.Add(waterConsumption);
        }
        public void AddPayment(Payment payment)
        {
            paymentList.Add(payment);
        }
        public void AddDebts(Debts debts)
        {
            debtsList.Add(debts);
        }
    }
}
