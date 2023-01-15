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
            List<Associate> associateListTest = new List<Associate>();
            associateListTest.Add(new Associate { Id = 123456, Name = "Sabrina", Lastname = "Rodriguez", Direction = "Direction" });
            
            var member = new Associate
            {
                Id = 123456
            };

            var app = new BillingSystemApp(associateListTest);

            WaterConsumption waterConsumption = new WaterConsumption();
            
            var attributes = new List<string>
            {
                "10/12/2022",
                "200"
            };

            waterConsumption.LoadAttributes(attributes);

            app.RegisterWaterConsumptionReading(member.Id, waterConsumption);

            var actual = 1;
            var result = app.associateList[0].waterConsumptionList.Count;
            Assert.AreEqual(result, actual);
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

            var actual = Assert.ThrowsException<Exception>(() => app.RegisterWaterConsumptionReading(123456, waterConsumption)).Message;
            var expected = "ERROR: Associate not found.";
            Assert.AreEqual(expected, actual);
            
        }

    }
}