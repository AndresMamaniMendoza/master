using BillingSystem.Controller;
using BillingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystemTest
{
    [TestClass]
    public class PaymentTest
    {
        [TestMethod]
        public void ShouldRegisterPaymentWhenTheAssociateHaveDebts()
        {

            List<Debt> debtListTest = new List<Debt>();
            debtListTest.Add(new Debt { Amount = 100, DateTime = new DateTime(2021, 10, 10), Status = true });

            List<Associate> associateListTest = new List<Associate>();
            associateListTest.Add(new Associate { Id = 1234, Name = "Andres", Lastname = "Mamani", Direction = "Direction", debtsList = debtListTest });

            var member = new Associate();
                member.Id = 1234;
            
            BillingSystemApp app = new BillingSystemApp(associateListTest);

            app.RegisterPayment(member.Id);

            var actual = app.associateList[0].debtsList[0].Amount;
            var result = 100;

            Assert.AreEqual(result, actual);


        }

        [TestMethod]
        public void ShoulCatchExceptionOnRegisterPaymentWhenAssociateIsNotExist()
        {
            var member = new Associate();
            member.Id = 1234567;
            member.Name = "Sabrina";
            member.Lastname = "Rodriguez";
            member.Direction = "Direction";

            //If I do not pass information to the constructor, the associate is not registered
            BillingSystemApp app = new BillingSystemApp();

            var actual = Assert.ThrowsException<Exception>(() => app.RegisterPayment(member.Id)).Message;
            var expected = "ERROR: Associate not found.";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCatchExceptionOnRegisterPaymentWhenTheDebtsAssociateIsZero()
        {

            List<Debt> debtListTest = new List<Debt>();
            debtListTest.Add(new Debt { Amount = 100, DateTime = new DateTime(2021, 10, 10), Status = false });

            List<Associate> associateListTest = new List<Associate>();
            associateListTest.Add(new Associate { Id = 123456, Name = "Sabrina", Lastname = "Rodriguez", Direction = "Direction", debtsList = debtListTest });

            var member = new Associate();
            member.Id = 123456;

            BillingSystemApp app = new BillingSystemApp(associateListTest);

            var actual = Assert.ThrowsException<Exception>(() => app.RegisterPayment(member.Id)).Message;
            var expected = "ERROR: Associate dont have debts.";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCalculateTotalPayment()
        {
            List<WaterConsumption> waterConsumptionListTest = new List<WaterConsumption>();
            waterConsumptionListTest.Add(new WaterConsumption { Amount = 100, DateTime = new DateTime(2021, 10, 10) });
            waterConsumptionListTest.Add(new WaterConsumption { Amount = 100, DateTime = new DateTime(2021, 10, 10) });
            waterConsumptionListTest.Add(new WaterConsumption { Amount = 100, DateTime = new DateTime(2021, 10, 10) });

            BillingSystemApp app = new BillingSystemApp();

            var actual = app.CalculateTotalPayment(waterConsumptionListTest);
            var expected = 600;

            Assert.AreEqual(expected, actual);
        }

    }
}
