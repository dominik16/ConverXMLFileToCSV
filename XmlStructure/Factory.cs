using System;
using System.Xml.Serialization;

namespace ExportReportToXml
{
    [Serializable]
    public class Factory
    {
        public Factory()
        {

        }

        public ProducedCars ProducedCars
        {
            get;
            set;
        }

        [XmlAttribute("Name"), XmlIgnore]
        private string Name
        {
            get;
            set;
        }
    }
}
