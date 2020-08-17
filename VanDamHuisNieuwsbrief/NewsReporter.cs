﻿using VanDamHuisAgendaLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class NewsReporter
    {
        private CultureInfo ciNL = new CultureInfo("nl-NL");

        private const string header = @"<html><head><title>Nieuwsbrief Van Dam Huis (gegenereerd)</title>
</head><body>
<section class='nieuwsbrief'>";

        private const string style = @"<style>
@import url('https://fonts.googleapis.com/css2?family=Rubik:wght@300;500&display=swap');
html, p, section.nieuwsbrief * {
    font-family: 'Rubik', sans-serif;
    font-size: 12pt;
    font-weight: 300;
    color: #222;
}

h1 {
    font-size: 1.5em !important;
}

h2 {
    font-size: 1.2em !important;
}

h1, h2, h3 {
    font-weight:300 !important;
}

b, strong {
    font-weight:500;
}

a {
    color: #222 !important;
}

section.nieuwsbrief {
    width: 1000px;
    max-width:100%;
    box-sizing: border-box;
    padding-left:2em;
    padding-right: 2em;
    margin-left:auto;
    margin-right:auto;
}

article {
    margin-bottom: 2em;
    margin-top:1em;
}

.event {
	padding-left: 0.25em;
	border-left-style: solid;
	border-left-width: 5px;
	margin-bottom: 0.25em;
}

.legend {
    display: inline-block;
    padding-left: 0.25em;
	border-left-style: solid;
	border-left-width: 5px;
    margin-right: 1em;
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

section.agenda {
    margin-bottom: 2em;
}

span.title {
    font-weight:500;
}

</style>";

        private void RenderAgenda(StringBuilder sb, List<AgendaEvent> agenda, NewsReporterOptions options)
        {
            if (agenda.Count > 0)
            {
                sb.AppendLine("<section class='agenda'>");
                sb.AppendLine($"<h1 style='color:#39469d'>Agenda</h1>");
                if (options.ForPrint)
                {
                    sb.AppendLine("<p>U vindt de actuele agenda op https://vandamhuis.nl en op de prikborden in het Van Dam Huis</p>");
                }
                else
                {
                    sb.AppendLine("<p>U vindt de actuele agenda op <a href='https://vandamhuis.nl'>Van Dam Huis</a></p>");
                }
                if (!options.ForPrint)
                {
                    sb.AppendLine("<p><span class='algemeen legend'>Algemeen</span><span class='therapeuticum legend'>Therapeuticum</span><span class='vereniging legend'>Vereniging</span><span class='consultatiebureau legend'>Consultatiebureau</span><span class='keerkring legend'>Keerkring</span></p>");
                }
                foreach (var item in agenda)
                {
                    if (options.ForPrint)
                    {
                        sb.AppendLine($"<p><b>{item.Event.event_name}</b><br><span>{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}</span><br>{item.Event.organisatie}</p>");
                    }
                    else
                    {
                        sb.AppendLine($"<div class='event {item.Event.organisatie}'><a href='{item.Event.url}'>{item.Event.event_name}</a><br><span >{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}</span></div>");
                    }
                }
                sb.AppendLine("</section>");
            }

        }

        public string GenerateNewsLetterReport(NewsLetter newsLetter, List<AgendaEvent> agenda, NewsReporterOptions options)
        {
            var sb = new StringBuilder();
            sb.AppendLine(header);

            if (options.IncludeAgenda && options.AgendaVooraan)
            {
                RenderAgenda(sb, agenda, options);
            }

            foreach (var organization in newsLetter.Organizations)
            {
                sb.AppendLine(GenerateOrganizationReport(organization, options));
            }

            if (options.IncludeAgenda && !options.AgendaVooraan)
            {
                RenderAgenda(sb, agenda, options);
            }

            sb.AppendLine(style);

            sb.AppendLine("</section></body></html>");

            var html = sb.ToString();
            //var path = GetReportPath();
            //File.WriteAllText(path, html, Encoding.UTF8);

            //return path;
            return html;

        }

        public string GenerateOrganizationReport(Organization organization, NewsReporterOptions options)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<p>&nbsp;</p>");
            sb.AppendLine($"<h1 style='color:{organization.Color}'>{organization.Name}</h1>");
            sb.AppendLine("<p>&nbsp;</p>");
            foreach (var item in organization.NewsItems)
            {
                sb.AppendLine(GetNewsItemHtml(item, options));
            }
            return sb.ToString();
        }

 
        private string GetNewsItemHtml(NewsItem item, NewsReporterOptions options)
        {
            var sb = new StringBuilder();
            sb.Append("<article>");

            if (!options.ForPrint)
            {
                sb.Append($"<a href='{item.Url}'><h2>{item.Title}</h2></a>");
            }
            else
            {
                sb.Append($"<p><b>{item.Title}</b></p>");
                if (options.PrintLinks)
                {
                    sb.Append($"<p>{item.Url}</p>");
                }
            }
            if (options.IncludeNewsPublicationDate)
            {
                sb.Append("<div class='publishdate'>" + item.PublishDate.ToString("d MMMM yyyy", ciNL.DateTimeFormat) + "</div>");
            }
            if (options.ForPrint)
            {
                sb.Append("<div class='content'>" + Unlink(item.Content) + "</div>");
            }
            else
            {
                sb.Append("<div class='content'>" + item.Content + "</div>");
            }
            sb.Append("</article>");

            return sb.ToString();
        }

        private string Unlink(string source)
        {
            return Regex.Replace(source, @"<a[^>]+>([^<]+)</a>", "$1");
        }

        private string GetOutPutPath()
        {
            var docpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var outputpath = Path.Combine(docpath, "VanDamHuis-Nieuwsbrief");
            if (!Directory.Exists(outputpath))
            {
                Directory.CreateDirectory(outputpath);
            }
            return outputpath;
        }

        public string GetReportPath()
        {
            return Path.Combine(GetOutPutPath(), $"VanDamHuis-Nieuwsbrief-{DateTime.Now:yyyy-MM-dd}.html");
        }

    }
}
