using BillingSystem.Helper;

namespace BillingSystemTest
{
    [TestClass]
    public class DatetimeHandlerTest
    {
        [TestMethod]
        public void TestShouldConvertStringDateToDateTimeDate()
        {
            DateTime actual = DateTimeHandler.ConvertStringToDateTime("31/03/2017");
            DateTime expected = DateTime.Parse("31/03/2017");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConvertToString()
        {
            DateTime dateT = DateTime.Parse("31/03/2017");
            var actual = DateTimeHandler.ConvertDateTimeToString(dateT);
            var expected = "31/03/2017";
            Assert.AreEqual(expected, actual);
        }

    }
}
