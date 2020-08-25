using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ExportReportToXml
{
    [Serializable]
    public class ProductionReport
    {
        public ProductionReport() { }

        [XmlAttribute("Manufacturer"), XmlIgnore]
        public string Manufacturer
        {
            get;
            set;
        }

        [XmlAttribute("Date"), XmlIgnore]
        public string Date
        {
            get;
            set;
        }

        public Factories Factories;
    }
}
