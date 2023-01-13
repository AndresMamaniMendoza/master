using BillingSystem.Controller;
using BillingSystem.Model;
using System.Collections.Generic;

namespace BillingProyect
{
    [TestClass]
    public class SystemTest
    {

        [TestMethod]
        public void ShouldRegisterNewMemberInTheSystemWhenAUserIsNotExist()
        {
            var member = new Associate();
            member.Id = 1;
            member.Name = "Andres";
            member.Lastname = "Mamani";
            member.Direction = "Direction";

            var app = new BillingSystemApp();
            app.RegisterMember(member);

            var actual = 1;
            var result = app.associateList;

            Assert.AreEqual(result.Count, actual);
        }

        [TestMethod]
        public void ShouldCatchExceptionWhenAUserExist()
        {
            var member = new Associate
            {
                Id = 1,
                Name = "Andres",
                Lastname = "Mamani",
                Direction = "Direction"
            };

            var app = new BillingSystemApp();
            app.RegisterMember(member);

            var member2 = new Associate
            {
                Id = 1
            };

            var actual = Assert.ThrowsException<Exception>(() => app.RegisterMember(member2)).Message;
            var expected = "ERROR: Associate is already registered.";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldRegisterNewWaterConsumptionInTheSystemWhenAUserExist()
        {
            var member = new Associate
            {
                Id = 1,
                Name = "Andres",
                Lastname = "Mamani",
                Direction = "Direction"
            };

            var app = new BillingSystemApp();
            app.RegisterMember(member);

            WaterConsumption waterConsumption = new WaterConsumption();
            var attributes = new List<string>
            {
                "10/12/2022",
                "200"
            };

            waterConsumption.LoadAttributes(attributes);
           
            app.RegisterWaterConsumptionReading(member.Id, waterConsumption);

            var actual = 1;
            var expected = member.waterConsumptionList.Count;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ShouldCatchExceptionOnWaterConsumptionRegistrationWhenAssociateIsNotExist()
        {
            var app = new BillingSystemApp();
            WaterConsumption waterConsumption = new WaterConsumption();
            var attributes = new List<string>
            {
                "10/12/2022",
                "200"
            };
            waterConsumption.LoadAttributes(attributes);

            var actual = Assert.ThrowsException<Exception>(() => app.RegisterWaterConsumptionReading(2, waterConsumption)).Message;
            var expected = "ERROR: Associate not found.";

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Shoult()
        {
            var member = new Associate();
            member.Id = 1234;
            member.Name = "Andres";
            member.Lastname = "Mamani";
            member.Direction = "Direction";

            var w = new Debts();
            w.Status = true;
            w.Amount = 40;

            var t = new List<Debts>();
            t.Add(w);

            member.debtsList = t;

            var app = new BillingSystemApp();
            app.RegisterMember(member);

            var attributesWaterConsumption = new List<string>
            {
                "01/01/2022",
                "200"
            };
            WaterConsumption waterConsumption = new WaterConsumption();
            waterConsumption.LoadAttributes(attributesWaterConsumption);


            app.RegisterWaterConsumptionReading(1234, waterConsumption);

            app.RegisterPayment(1234);


            var actual = member.debtsList[0].Amount;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }






















    }
}