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
            bool includePrivateEvents = false;
            bool includeRepeatingEvens = false;

            var commands = CommandLineParser.GetCommands(args);
            if (commands.ContainsKey("scope")) {
                includePrivateEvents = commands["scope"] == "private";
            }

            if (commands.ContainsKey("repeating")) {
                includeRepeatingEvens  = commands["repeating"] == "include";
            }

            var filepath = @"d:\_Jan\Antroposofie\Website\vandamhuis.nl\events.csv";
            var parser = new AgendaEventParser(filepath, includePrivateEvents, includeRepeatingEvens);
            var eventsToReport = parser.GetEventsForReporting();
            var reporter = new AgendaEventReporter(eventsToReport);
            reporter.Report();
            

        }
        
    }
}
