using BillingSystem.Model;

namespace BillingSystem.Controller
{
    public class BillingSystemApp
    {
        public List<Associate> associateList = new();
        
        private List<Associate> associateListTest;

        public BillingSystemApp(List<Associate> associateListTest)
        {
            this.associateList = associateListTest;
        }

        public BillingSystemApp()
        {
        }

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

            var amountWater = waterConsumption.Amount;

            var newDebt = new Debt();
            newDebt.Status = true;
            newDebt.Amount = amountWater;
            associateList[index].AddDebts(newDebt);

        }
        public void RegisterPayment(int Id)
        {
            if (!CheckIfMemberExist(Id))
            {
                throw new Exception("ERROR: Associate not found.");
            }
            
            int index = FindIndexAssociateById(Id);
            var waterConsumptionList = associateList[index].waterConsumptionList;

            var totalDebt = CalculateTotalPayment(waterConsumptionList);


            if (totalDebt <= 0)
            {
                throw new Exception("ERROR: Associate dont have debts.");
            }
            
            var associate = associateList[index];
            
            var payment = new Payment
            {
                Amount = totalDebt,
                DateTime = DateTime.Now
            };
            
            associate.AddPayment(payment);
            associate.debtsList.ForEach(x => x.Status = false); 
            associate.debtsList.ForEach(x => x.Amount = 0);
        }
        
        public int CalculateTotalPayment(List<WaterConsumption> consumptionList)
        {
            const int pricePerLiter = 2;
            return consumptionList.Sum(x => x.Amount * pricePerLiter);
        }
        
        
        //Metodos auxiliares
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
    }
}

