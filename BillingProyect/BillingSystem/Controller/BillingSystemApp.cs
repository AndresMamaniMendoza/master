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
    }
}
