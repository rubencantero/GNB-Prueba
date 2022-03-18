using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussinsess.Utils.Utils
{
    public class LogManager
    {
        private const string URL_LOG = @"C:\Logs/";
        private static string Year = DateTime.Now.Year.ToString();
        private static string Month = DateTime.Now.Month.ToString();
        private static string Day = DateTime.Now.Day.ToString();

        public static void Write(string log)
        {

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(URL_LOG)))
                    Directory.CreateDirectory(Path.GetDirectoryName(URL_LOG));
                string urlLog = URL_LOG + Year + "/";
                urlLog = urlLog + Month + "/";
                urlLog = urlLog + Day + ".txt";

                string finalText = "[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "] - " + log + Environment.NewLine;

                if (!File.Exists(urlLog))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(urlLog));
                }

                File.AppendAllText(urlLog, finalText);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
