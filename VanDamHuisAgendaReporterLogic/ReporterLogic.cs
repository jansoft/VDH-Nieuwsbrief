using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisAgendaLogic
{
    public class ReporterLogic
    {


        public string ReportEvents(List<AgendaEvent> eventsToReport, ReporterOptions options)
        {
            var reporter = new AgendaEventReporter(eventsToReport, GetMyDocsAppPath());
            return reporter.Report(options);
        }

        private string GetMyDocsAppPath()
        {
            var mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var mydocsAppPath = Path.Combine(mydocs, "Van Dam Huis agenda");
            if (!Directory.Exists(mydocsAppPath))
            {
                Directory.CreateDirectory(mydocsAppPath);
            }
            return mydocsAppPath;
        }
    }
}
