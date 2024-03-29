﻿using System;
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
            if (commands.ContainsKey("include")) {
                options.IncludePrivate = commands["include"] == "private";
            }

            if (commands.ContainsKey("weeks"))
            {
                options.From = DateTime.Now.AddDays(1).Date;
                options.Until = options.From.AddDays(7 * int.Parse(commands["weeks"])).Date;
            }
            else
            {

                if (commands.ContainsKey("from"))
                {
                    options.From = DateTime.Parse(commands["from"]);

                }
                else
                {
                    options.From = DateTime.Now;
                }

                if (commands.ContainsKey("until"))
                {
                    options.Until = DateTime.Parse(commands["until"]);
                }
                else
                {
                    options.Until = DateTime.Now.AddYears(1);
                }
            }

            List<AgendaEvent> eventsToReport;
            var sourceType = "api";

            if (sourceType == "api")
            {

                //var url = "https://localhost/vandamhuis/wp-json/vdh/agenda?bop=2020-01-01&eop=2020-08-01";
                var url = "https://www.vandamhuis.nl/wp-json/vdh/agenda";
                var client = new AgendaClient(url, options);
                eventsToReport = client.GetEventsForReporting();
            }
            else
            {

                var filepath = GetCsvPath();
                var parser = new AgendaEventParser(filepath, options);
                eventsToReport = parser.GetEventsForReporting();
            }

            var reporter = new AgendaEventReporter(eventsToReport, GetMyDocsAppPath());
            var showBackground = commands.ContainsKey("bg") && commands["bg"] == "true";
            var reportpath = reporter.Report(showBackground);

            Console.WriteLine("Agenda PDF staat in:");
            Console.WriteLine(reportpath);
            Console.ReadLine();
            

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
