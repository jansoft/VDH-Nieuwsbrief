using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class Logic
    {
        public List<AgendaEvent> GetEventsForReporting(AgendaEventParserOptions options)
        {
            var bop = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
            var eop = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            var url = "https://www.vandamhuis.nl/wp-json/vdh/agenda?bop=" + bop + "&eop=" + eop;
            var client = new AgendaClient(url, options);
            return client.GetEventsForReporting();
        }

        public List<AgendaEvent> FetchEvents(AgendaEventParserOptions options)
        {
            var bop = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
            var eop = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            var url = "https://www.vandamhuis.nl/wp-json/vdh/agenda?bop=" + bop + "&eop=" + eop;
            var client = new AgendaClient(url, options);
            return client.FetchEvents();
        }

        public string ReportEvents(List<AgendaEvent> eventsToReport, bool showBackground)
        {
            var reporter = new AgendaEventReporter(eventsToReport, GetMyDocsAppPath());
            return reporter.Report(showBackground);
        }

        public List<AgendaEvent> GetEvensInReeks(List<AgendaEvent> eventsToReport, string reeks)
        {
            var result = new List<AgendaEvent>();
            foreach(var item in eventsToReport)
            {
                if (item.Event.reeks == reeks)
                {
                    result.Add(item);
                }
            }

            return result;
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
