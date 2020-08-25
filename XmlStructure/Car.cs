using System.Xml.Serialization;


namespace ExportReportToXml
{

    public class Car : ProducedCars
    {
        private string vin;
        private string productionYear;
        private string model;

        public Car()
        {

        }

        public Car(string VIN, string PRODUCTIONYEAR, string MODEL)
        {
            this.vin = VIN;
            this.productionYear = PRODUCTIONYEAR;
            this.model = MODEL;
        }

        [XmlAttribute("VIN")]
        public string Vin
        {
            get => vin;
            set { vin = value; }
        }
        [XmlElement("ProductionYear")]
        public string ProductionYear
        {
            get => productionYear;
            set { productionYear = value; }
        }

        [XmlElement("Model")]
        public string Model
        {
            get => model;
            set { model = value; }
        }
    }

}




