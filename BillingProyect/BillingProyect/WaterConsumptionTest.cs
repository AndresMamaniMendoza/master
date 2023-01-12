using BillingSystem.Helper;
using BillingSystem.Model;


namespace BillingSystemTest
{
    [TestClass]
    public class WaterConsumptionTest
    {
        [TestMethod]
        public void ShouldLoadAttributesWhenTheDateIsValid()
        {
            WaterConsumption waterConsumption = new WaterConsumption();
            var attributes = new List<string>
            {
                "10/12/2020",
                "200"
            };
            waterConsumption.LoadAttributes(attributes);
            var actualDatetime = DateTimeHandler.ConvertStringToDateTime("10/12/2020");
            var expectedDatetime =  waterConsumption.DateTime;

            Assert.AreEqual(expectedDatetime, actualDatetime);

            var actualAmount = waterConsumption.Amount;
            var expectedAmount = 200;
            Assert.AreEqual(expectedAmount, actualAmount);

        }

        [TestMethod]
        public void ShouldCatchExceptionWhenTheDateTimeIsInvalid()
        {
            WaterConsumption waterConsumption = new WaterConsumption();
            var attributes = new List<string>
            {
                "10/12/2Any",
                "200"
            };
           ;
            var actual = Assert.ThrowsException<Exception>(() => waterConsumption.LoadAttributes(attributes)).Message;
            var expected = "Invalid Date.";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCatchExceptionWhenTheAmountIsNotInteger()
        {
            WaterConsumption waterConsumption = new WaterConsumption();
            var attributes = new List<string>
            {
                "10/12/2022",
                "123Is not Integer asdas"
            };
            ;
            var actual = Assert.ThrowsException<Exception>(() => waterConsumption.LoadAttributes(attributes)).Message;
            var expected = "ERROR: please enter integers only.";

            Assert.AreEqual(expected, actual);
        }
    }
}
