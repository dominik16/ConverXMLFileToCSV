using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExportReportToXml
{
    [Serializable]
    public class ProducedCars : Factory
    {
        public ProducedCars()
        {

        }

        [XmlElement("Car")]
        public List<Car> Car
        {
            get;
            set;
        }
    }
}
