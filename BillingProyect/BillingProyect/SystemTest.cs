using BillingSystem.Model;
using BillingSystem.Controller;

namespace BillingProyect
{
    [TestClass]
    public class SystemTest
    {

        [TestMethod]
        public void ShouldRegisterNewMemberInTheSystemWhenAUserIsNotExist()
        {
            var member = new Member();
            member.Id = 1;
            member.Name = "Andres";
            member.Lastname = "Mamani";
            member.Direction = "Direction";

            var app = new BillingSystemApp();
            app.RegisterMember(member);

            var actual = 1;
            var result = app.memberList;

            Assert.AreEqual(result.Count, actual);

        }

        [TestMethod]
        public void ShouldCatchExceptionWhenAUserExist()
        {
            var member = new Member
            {
                Id = 1,
                Name = "Andres",
                Lastname = "Mamani",
                Direction = "Direction"
            };

            var app = new BillingSystemApp();
            app.RegisterMember(member);

            var member2 = new Member
            {
                Id = 1
            };

            var actual = Assert.ThrowsException<Exception>(() => app.RegisterMember(member2)).Message;
            var expected = "The member already exists in the list.";

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void ShouldAddConsumption()
        //{
        //    var member = new Member
        //    {
        //        Id = 1,
        //        Name = "Andres",
        //        Lastname = "Mamani",
        //        Direction = "Direction"
        //    };

        //    var app = new BillingSystemApp();
        //    app.RegisterMember(member);

        //    app.RegisterWaterConsumptionReading(1, "Enero/2022", 100);

        //    var actual = app.memberList[0].WaterConsumptionPerMonth;

        //    for (int i = 0; i < actual.Count; i++)
        //    {
        //        Console.WriteLine(actual[i]);
        //    }



        //    var expected = new Dictionary<string, int>();

        //    Assert.AreEqual(1, 1);
        //}
        [TestMethod]
        public void ShouldAddConsumption()
        {
            var member = new Member
            {
                Id = 1,
                Name = "Andres",
                Lastname = "Mamani",
                Direction = "Direction"
            };

            member.AddConsumption("enero", 100);


            var x = new Dictionary<string, int>();
            x.Add("erey", 200);

            Assert.AreEqual(member.WaterConsumptionPerMonth.Count, 2);
        }
    }
}