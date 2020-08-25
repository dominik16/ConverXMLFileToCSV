using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace ExportReportToXml
{
    public class SerializationClass
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(ProductionReport));
        XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
        ProductionReport report;

        public SerializationClass()
        {

        }
        public void Serialization(string path)
        { 
            try
            {
                
                using StreamReader reader = new StreamReader(path + "ProductionResults.xml");
                report = (ProductionReport)deserializer.Deserialize(reader);

                SerializationToFile(report,path);
            }
            catch(Exception ex)
            {
                using(StreamWriter writer = File.AppendText(path + "serializationError.txt"))
                {
                    writer.WriteLine("Error while deserializing. Error time: " + DateTime.Now.ToString() + ". Reason:");
                    writer.WriteLine(ex.Message.ToString());
                    writer.Close();
                }
            }
        }

        public void SerializationToFile(ProductionReport report, string path)
        {
            try
            {               
                int count;
                count = report.Factories.Factory.ProducedCars.Car.Count;
                List<Car> CarList = introducingToList(count, report);

                
                StreamWriter writer = new StreamWriter(path + "serializerCar.xml");
                serializer.Serialize(writer, CarList);
                writer.Close();
                Console.WriteLine("Serialization Successfull");
            }
            catch(Exception ex)
            {
                using (StreamWriter writer = File.AppendText(path + "serializationError.txt"))
                {
                    writer.WriteLine("Error while serializing. Error time: " + DateTime.Now.ToString()+ ". Reason:");
                    writer.WriteLine(ex.Message.ToString());
                    writer.Close();   
                }
            }
        }

        public List<Car> introducingToList(int count, ProductionReport report)
        {
            List<Car> tmpList = new List<Car>() { };

            for (int i = 0; i < count; i++)
            {
                tmpList.Add(new Car(report.Factories.Factory.ProducedCars.Car[i].Vin, report.Factories.Factory.ProducedCars.Car[i].ProductionYear,
                    report.Factories.Factory.ProducedCars.Car[i].Model));
            }

            return tmpList;
        }
    }
}
