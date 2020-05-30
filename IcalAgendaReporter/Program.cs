using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new AgendaEventParserOptions();

            var commands = CommandLineParser.GetCommands(args);
            if (commands.ContainsKey("scope")) {
                options.IncludePrivate = commands["scope"] == "private";
            }

            if (commands.ContainsKey("repeating")) {
                options.IncludeRepeating  = commands["repeating"] == "include";
            }
            if (commands.ContainsKey("until"))
            {
                options.Until = DateTime.Parse(commands["until"]);
            }
            else
            {
                options.Until = DateTime.Now.AddYears(1);
            }

            var filepath = GetCsvPath();
            var parser = new AgendaEventParser(filepath, options);
            var eventsToReport = parser.GetEventsForReporting();

            var reporter = new AgendaEventReporter(eventsToReport, GetMyDocsAppPath());
            reporter.Report();
            

        }

        static private string GetMyDocsAppPath()
        {
            var mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var mydocsAppPath = Path.Combine(mydocs, "Van Dam Huis agenda");
            if (!Directory.Exists(mydocsAppPath))
            {
                Directory.CreateDirectory(mydocsAppPath);
            }
            return mydocsAppPath;
        }

        static private string GetCsvPath()
        {
            return Path.Combine(GetMyDocsAppPath(), "events.csv");
        }
        
    }
}
