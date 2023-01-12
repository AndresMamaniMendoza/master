using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Model
{
    public class Member : User
    {
        public List<Dictionary<string, int>> WaterConsumptionPerMonth = new List<Dictionary<string, int>>();


        public void AddConsumption(string mes, int amount)
        {
            var consumption = new Dictionary<string, int>();
            consumption.Add(mes, amount);
            WaterConsumptionPerMonth.Add(consumption);


        }
        public override string ToString()
        {
            return $"Id: {Id}, Name :{Name}, LastName: {Lastname}, Direction: {Direction}";
        }

        public void PrintWater()
        {
            for (int i = 0; i < WaterConsumptionPerMonth.Count; i++)
            {
                Console.WriteLine(WaterConsumptionPerMonth[i]);
            }
        }
    }
}
