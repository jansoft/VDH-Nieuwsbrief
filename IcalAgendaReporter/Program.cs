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

            var filepath = @"d:\_Jan\Antroposofie\Website\vandamhuis.nl\events.csv";
            var parser = new AgendaEventParser(filepath, options);
            var eventsToReport = parser.GetEventsForReporting();
            var reporter = new AgendaEventReporter(eventsToReport);
            reporter.Report();
            

        }
        
    }
}
