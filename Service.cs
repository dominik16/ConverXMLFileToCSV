using System;
using System.ServiceProcess;
using System.IO;
using System.Threading;

namespace ExportReportToXml
{
    public class Service : ServiceBase
    {
        public string path = @"C:\";

        public Thread Worker = null;

        public void Log(string logMessage)
        {
            using (StreamWriter writer = File.AppendText(path + "serialLog.txt")) 
            {
                writer.WriteLine("Serialization was " + logMessage + " in " + DateTime.Now.ToString());
                writer.Close();
            }
        }

        protected override void OnStart(string[] args)
        {
            ThreadStart start = new ThreadStart(Working);
            Worker = new Thread(start);
            Worker.Start();
            Log("started");
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            Log("stopped");
            base.OnStop();
        }

        protected override void OnPause()
        {
            Log("paused");
            base.OnPause();
        }

        public void Working()
        {
            int nsleep = 1;
            try
            {
                while (true)
                {
                    SerializationClass serializationObject = new SerializationClass();
                    serializationObject.Serialization(path);

                    ConvertToCSV convert = new ConvertToCSV();
                    convert.convertToCSV(path);
                    Thread.Sleep(nsleep * 60 * 1000);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

