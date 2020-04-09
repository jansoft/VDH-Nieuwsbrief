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
            var commands = CommandLineParser.GetCommands(args);
            var includePrivateEvents = commands["scope"] == "private";

            var filepath = @"d:\_Jan\Antroposofie\Website\vandamhuis.nl\events.csv";
            var reporter = new Reporter(filepath, includePrivateEvents);
            var pdfpath = reporter.GenerateReport();

            Process.Start(pdfpath);

        }
        
    }
}
