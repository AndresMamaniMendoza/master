using BillingSystem.Model;

namespace BillingSystem.Controller
{
    public class BillingSystemApp
    {
        public List<Associate> associateList = new();
        public void RegisterMember(Associate member)
        {
            if (CheckIfMemberExist(member.Id))
            {
                throw new Exception("ERROR: Associate is already registered.");
            }
            associateList.Add(member);
        }
        public void RegisterWaterConsumptionReading(int Id, WaterConsumption waterConsumption)
        {
            if (!CheckIfMemberExist(Id))
            {
                throw new Exception("ERROR: Associate not found.");
            }
            int index = associateList.FindIndex(x => x.Id == Id);
            associateList[index].AddConsumption(waterConsumption);
        }

        public bool CheckIfMemberExist(int id)
        {
            return associateList.Any(x => x.Id == id);
        }
        public Associate FindAssociateById(int Id)
        {
            return associateList.Find(x => x.Id == Id) ?? throw new Exception($"A Associate with the specified ID: {Id} was not found.");
        }
        public int FindIndexAssociateById(int Id)
        {
            return associateList.FindIndex(x => x.Id == Id);
        }

        public void RegisterPayment(int Id)
        {
            if (!CheckIfMemberExist(Id))
            {
                throw new Exception("ERROR: Associate not found.");
            }
            int index = FindIndexAssociateById(Id);
            var waterConsumptionList = associateList[index].waterConsumptionList;



            var totalDebt = 0;
            var pricePerLiter = 2;

            for (int i = 0; i < waterConsumptionList.Count; i++)
            {
                totalDebt += waterConsumptionList[i].Amount * pricePerLiter;

            }

            if (totalDebt > 0)
            {
                var associate = associateList[index];
                var payment = new Payment
                {
                    IdAssociate = Id,
                    Amount = totalDebt,
                    DateTime = DateTime.Now
                };
                associate.AddPayment(payment);
                associate.debtsList.ForEach(x => x.Status = false);
                associate.debtsList.ForEach(x => x.Amount = 0);

            }
        }
        public int CalculatePayment(List<WaterConsumption> consumptionList)
        {
            const int pricePerLiter = 2;
            return consumptionList.Sum(x => x.Amount * pricePerLiter);
        }
    }
}

