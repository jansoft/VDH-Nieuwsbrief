using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class Reporter
    {
        private CultureInfo ciNL = new CultureInfo("nl-NL");
        private readonly List<AgendaEvent> parsedEvents;
        private readonly bool includePrivateEvents;

        private readonly string filepath;
        public Reporter(string filepath, bool includePrivateEvents)
        {
            this.filepath = filepath;
            this.includePrivateEvents = includePrivateEvents;
            parsedEvents = Parse();
        }

        private List<AgendaEvent> Parse()
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(ciNL);
            config.Delimiter = ";";
            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvHelper.CsvReader(reader, config))
                {
                    var records = csv.GetRecords<AgendaEvent>();
                    return records.ToList();
                }
                
            }
        }

        private List<AgendaEvent> GetFutureEvents(List<AgendaEvent> records)
        {
            if (includePrivateEvents)
            {
                return records.Where(p => p.event_start_date >= DateTime.Now.Date).OrderBy(p => p.event_start_date).ToList();
            }
            else
            {
                return records.Where(p => p.event_start_date >= DateTime.Now.Date && !p.event_private).OrderBy(p => p.event_start_date).ToList();
            }
        }

        private List<AgendaEvent> ReduceRepeatingEvents(List<AgendaEvent> records)
        {
            var reeksen = new Dictionary<string, bool>();
            var result = new List<AgendaEvent>();

            foreach(var record in records)
            {
                var reeks = record.reeks;
                if (string.IsNullOrWhiteSpace(reeks))
                {
                    result.Add(record);
                }
                else
                {
                    if (!reeksen.ContainsKey(reeks))
                    {
                        reeksen[reeks] = true;
                        result.Add(record);
                    }
                }
            }

            return result;
        }

        public List<AgendaEvent> GetEventsForReporting()
        {
            var futureEvents = GetFutureEvents(parsedEvents);
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
<p>Deze agenda bevat de evenementen van alle deelnemende organisaties: therapeuticum, vereniging, consultatieburea en keerkring</p>
<div class='vdh-event-filters'>{GetAgendaLegend()}</div>
");
            foreach(var agendaEvent in eventsToReport)
            {
                sb.AppendLine($@"
<div class='vdh-event {agendaEvent.organisatie}'>
    <div class='vdh-event-title'><a href='{agendaEvent.url}'>{agendaEvent.event_name}</a></div>
    <div class='vdh-event-date'>{agendaEvent.event_start_date:dd MMMM yyyy} {agendaEvent.event_start_time:HH:mm} - {agendaEvent.event_end_time:HH:mm}</div>
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
