using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public enum EventScope { All, Public, Private}

    public class AgendaEventParser : BaseAgendaParser
    {
        private CultureInfo ciNL = new CultureInfo("nl-NL");
        private readonly List<AgendaEvent> parsedEvents = new List<AgendaEvent>();
        private readonly AgendaEventParserOptions options;

        private readonly string filepath;
        public AgendaEventParser(string filepath, AgendaEventParserOptions options)
        {
            this.filepath = filepath;
            this.options = options;
            Initialize();
        }

        private void Initialize()
        {
            var csvParsedEvents = ParseCsv();
            
            foreach(var item in csvParsedEvents)
            {
                parsedEvents.Add(new AgendaEvent { Event = item });
            }

            ParseReeksen(parsedEvents);
        }

        private List<CsvAgendaEvent> ParseCsv()
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(ciNL);
            config.Delimiter = ";";
            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvHelper.CsvReader(reader, config))
                {
                    var records = csv.GetRecords<CsvAgendaEvent>();
                    return records.ToList();
                }
                
            }
        }

        public List<AgendaEvent> GetEventsForReporting()
        {
            var futureEvents = GetFutureEvents(parsedEvents, options.IncludePrivate, options.From, options.Until);
            return ReduceRepeatingEvents(futureEvents);
        }

        public string GenerateReport()
        {
            var mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var reportFolder = Path.Combine(mydocuments, "Van Dam Huis agenda");
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }
            var reportpath = Path.Combine(reportFolder, $"vdh-agenda-{DateTime.Now:yyyy-MM-dd HHmm}.html");
            var eventsToReport = GetEventsForReporting();

            var sb = new StringBuilder();
            sb.AppendLine(@"<html>
<head><title>Van Dam Huis agenda</title>
<style>
@import url('https://fonts.googleapis.com/css2?family=Rubik:wght@300;500&display=swap');

body {
    font-family: 'Rubik', sans-serif;
    font-size: 12pt;
    font-weight: 300;
    margin: 50px;
}

h1 {
    font-weight: 500;
}

.vdh-event {
	padding: 0.25em;
	background-color: rgba($white, 0.4);
	position: relative;
	border-left-style: solid;
	border-left-width: 5px;
	margin-bottom: 0.25em;
}

.vdh-event-title {
	font-weight: 500;
}

.algemeen {
	border-left-color: #39469D;
}

.therapeuticum {
	border-left-color: #2396c9;
}

.vereniging {
	border-left-color: #DE557D;
}

.keerkring {
	border-left-color: #ba79a0;
}

.consultatiebureau {
	border-left-color: #ec744e
}

.vdh-event-filters {
    margin-bottom: 1em;
}

.vdh-event-filter {
	display: inline-block;
	padding: 0.25em;
	padding-top: 0;
	padding-bottom: 0;
	border-left-style: solid;
	border-left-width: 5px;
	margin-right: 0.5em;
	background-color: rgba($white, 0.4);	
}
</style>
</head>
<body>");
            sb.AppendLine($@"
<div><img src='d:\_Jan\Antroposofie\Website\vandamhuis.nl\logo\vdh-logo.png' width='150px'/></div>
<h1>Agenda</h1>
<div class='vdh-event-filters'>{GetAgendaLegend()}</div>
");
            foreach(var agendaEvent in eventsToReport)
            {
                var reeksInfo = "";
                if (!string.IsNullOrWhiteSpace(agendaEvent.Event.reeks) && !string.IsNullOrWhiteSpace(agendaEvent.ReeksInfo) )
                {
                    reeksInfo = agendaEvent.ReeksInfo;
                }
                
                sb.AppendLine($@"
<div class='vdh-event {agendaEvent.Event.organisatie}'>
    <div class='vdh-event-title'><a href='{agendaEvent.Event.url}'>{agendaEvent.Event.event_name}</a></div>
    <div class='vdh-event-date'>{agendaEvent.Event.event_start_date:dd MMMM yyyy} {agendaEvent.Event.event_start_time:HH:mm} - {agendaEvent.Event.event_end_time:HH:mm} {reeksInfo}</div>
</div>
");
            }

            sb.AppendLine("</body></html>");

            var html = sb.ToString();

            File.WriteAllText(reportpath, sb.ToString(), Encoding.UTF8);

            var pdfpath = Path.ChangeExtension(reportpath, "pdf");
            WriteToPdf(html, pdfpath);

            return pdfpath;
            
        }

        private void WriteToPdf(string html, string pdfpath)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            File.WriteAllBytes(pdfpath, res);
        }

        private string GetAgendaLegendPart(string cssClass, string label)
        {
            return $"<span class='vdh-event-filter {cssClass}' org='{cssClass}'>{label}</span>";
        }

        private string GetAgendaLegend()
        {
            return GetAgendaLegendPart("algemeen", "Algemeen") + GetAgendaLegendPart("therapeuticum", "Therapeuticum") + GetAgendaLegendPart("vereniging", "Vereniging") + GetAgendaLegendPart("consultatiebureau", "Consultatiebureau") + GetAgendaLegendPart("keerkring", "Keerkring");
        }
    }
}
