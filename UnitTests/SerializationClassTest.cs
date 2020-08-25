using ExportReportToXml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class SerializationClassTest
    {
        [TestMethod]
        public void introducingToListTest()
        {
            ProductionReport report = new ProductionReport()
            {
                Factories = new Factories()
                {
                    Factory = new Factory()
                    {
                        ProducedCars = new ProducedCars() { Car = new List<Car>() {} }
                    }
                }
            };

            int count = 1;
            report.Factories.Factory.ProducedCars.Car.Add(new Car("XXXX", "YYYY", "MMMM"));

            SerializationClass serialization = new SerializationClass();
            List<Car> list = serialization.introducingToList(count, report);

            Assert.AreEqual(list[0].Model, report.Factories.Factory.ProducedCars.Car[0].Model);
            Assert.AreEqual(list[0].Vin, report.Factories.Factory.ProducedCars.Car[0].Vin);
            Assert.AreEqual(list[0].ProductionYear, report.Factories.Factory.ProducedCars.Car[0].ProductionYear);
        }
    }
}
