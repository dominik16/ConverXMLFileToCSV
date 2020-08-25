using System.ServiceProcess;

namespace ExportReportToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new Service());

        }
    }
}

