using System;
using System.IO;
using System.Xml.Xsl;

namespace ExportReportToXml
{
    public class ConvertToCSV
    {
        XslCompiledTransform transform = new XslCompiledTransform();
        public void convertToCSV(string path)
        {
            try
            {
                transform.Load(path + "stylesheet.xslt");
                transform.Transform(path + "serializerCar.xml", path + "csvCar.txt");
            }
            catch(Exception ex)
            {
                using(StreamWriter writer = File.AppendText(path + "serializationError.txt"))
                {
                    writer.WriteLine("Error converting to CSV file. Error time: " + DateTime.Now.ToString() + ". Reason:");
                    writer.WriteLine(ex.Message.ToString());
                    writer.Close();
                }
            }
        }
    }
}
