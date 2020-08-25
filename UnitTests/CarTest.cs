using ExportReportToXml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void CarConstructorTest()
        {
            string vinTest = "00000000";
            string productionYearTest = "9999";
            string modelTest = "XXXXX";

            Car carTest = new Car(vinTest, productionYearTest, modelTest);

            Assert.AreEqual(vinTest, carTest.Vin);
            Assert.AreEqual(productionYearTest, carTest.ProductionYear);
            Assert.AreEqual(modelTest, carTest.Model);
        }
    }
}
