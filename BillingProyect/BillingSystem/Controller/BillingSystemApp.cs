using BillingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Controller
{
    public class BillingSystemApp
    {
        public List<Member> memberList = new();
        public void RegisterMember(Member member)
        {
            if (CheckIfMemberExist(member.Id))
            {
                throw new Exception("The member already exists in the list.");
            }
            memberList.Add(member);
        }

        public void RegisterWaterConsumptionReading(int Id, string mes, int amount)
        {
            if (!CheckIfMemberExist(Id))
            {
                throw new Exception("The member does not exist in the list.");
            }
            int index = memberList.FindIndex(x => x.Id == Id);
            memberList[index].AddConsumption(mes, amount);
        }

        public bool CheckIfMemberExist(int id)
        {
            return memberList.Any(x => x.Id == id);
        }
        public Member FindMemberById(int Id)
        {
            return memberList.Find(x => x.Id == Id) ?? throw new Exception($"A member with the specified ID: {Id} was not found.");
        }
    }
}
