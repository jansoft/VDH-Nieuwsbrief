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
using System.Linq.Expressions;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class NewsReporter
    {
        private CultureInfo ciNL = new CultureInfo("nl-NL");
        private int newsId = 0; 

        private void RenderAgenda(StringBuilder sb, List<AgendaEvent> agenda, NewsReporterOptions options)
        {
            if (agenda.Count > 0)
            {
                ItemDivider(sb);
                sb.AppendLine("<p><a id='agenda' name='agenda'></a>&nbsp;</p>");
                sb.AppendLine($"<h1>Agenda</h1>");
                if (options.ForPrint)
                {
                    sb.AppendLine("<p>U vindt de actuele agenda op https://vandamhuis.nl en op de prikborden in het Van Dam Huis</p>");
                }
                else
                {
                    sb.AppendLine(@"<p>U vindt de actuele agenda op <a href='https://vandamhuis.nl'>Van Dam Huis</a>
<br/>Klik op de titel van een activiteit voor alle info over de activiteit zoals beschrijving, aanmelden en kosten.</p>");
                }

                // legend 
                // black large square = &#x2B1B;
                if (!options.ForPrint)
                {
                    sb.AppendLine("<ul>");
                }
                foreach (var item in agenda)
                {
                    if (options.HideCanceledEvents)
                    {
                        var eventname = item.Event.event_name.ToLowerInvariant();
                        if (eventname.Contains("afgelast") || eventname.Contains("vervallen") || eventname.Contains("vervalt"))
                        {
                            continue;
                        }
                    }
                    if (options.ForPrint)
                    {
                        sb.AppendLine($"<p><strong>{item.Event.event_name}</strong><br>{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}</p>");
                    }
                    else
                    {
                        var samenvatting = "";
                        if (options.ToonSamenvattingActiviteit && !string.IsNullOrWhiteSpace(item.Event.post_excerpt))
                        {
                            samenvatting = "<br/>" +  item.Event.post_excerpt.Trim();

                        }
                        sb.AppendLine($"<li><a href='{item.Event.url}'>{item.Event.event_name}</a><br>{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}{samenvatting}</li>");
                    }
                }
                if (!options.ForPrint)
                {
                    sb.AppendLine("</ul>");
                }
            }

        }

        private void RenderHeader(StringBuilder sb, NewsReporterOptions options)
        {
            var media = options.ForPrint ? "print" : "digital";
            sb.AppendLine($@"<html><head><title>Van Dam Huis | Nieuwsbrief {options.PublicatieDatum:MMMM yyyy}</title>
</head><body style='background-color:#FAFAFA'>
<section style='color:#202020;background-color:#FFFFFF;max-width:600px;margin-left:auto;margin-right:auto;font-family:Verdana, geneva, sans-serif;font-size:12px;padding:9px'>");
        }

        private void RenderStyle(StringBuilder sb, NewsReporterOptions options)
        {
            sb.AppendLine(@"<style>
a {
    color: #007C89 !important;
    text-decoration: underline !important;
}

.clearfix::after {
  content: '';
  clear: both;
  display: table;
}

.expandable {
    display:none;
}

.expandable:target {
    display:block;
}
</style>");
        }

        public Organization GetVanDamHuis(NewsLetter newsLetter)
        {
            return newsLetter.Organizations.FirstOrDefault(p => p.Name == "Van Dam Huis");
        }

        public string GenerateNewsLetterReport(NewsLetter newsLetter, List<AgendaEvent> agenda, NewsReporterOptions options)
        {
            newsId = 1;
            var sb = new StringBuilder();
            RenderHeader(sb, options);
            
            //RenderIntro(sb, newsLetter, options);

 
            foreach (var organization in newsLetter.Organizations)
            {
                sb.AppendLine(GenerateOrganizationReport(organization, options));
            }

            RenderAgenda(sb, agenda, options);

            RenderStyle(sb, options);

            sb.AppendLine("</section></body></html>");

            var html = sb.ToString();
            //var path = GetReportPath();
            //File.WriteAllText(path, html, Encoding.UTF8);

            //return path;
            return html;

        }

        private void RenderLogo(StringBuilder sb, Organization organization, NewsReporterOptions options)
        {
            var logo = $"<div class='logo'><img src='{organization.LogoUrl}' style='height:auto;max-width:100%'></div>";

            sb.AppendLine(logo);

        }

        private void ItemDivider(StringBuilder sb)
        {
            sb.AppendLine("<hr style='margin-top:18px;margin-bottom:18px'/>");
        }

        private void AddFixedVdhNews(StringBuilder sb, NewsReporterOptions options)
        {
            sb.AppendLine($@"<h1 class='null' style='text-align: left;'><span style='font-size:20px'><span style='font-family:verdana,geneva,sans-serif'>De nieuwsbrief van het Van Dam Huis</span></span></h1>

<p>Preview nieuwsbrief {options.PublicatieDatum.ToString("MMMM yyyy")} met als thema: {options.Thema}</p>

<p>Het Van Dam Huis biedt onderdak aan vier organisaties: <a href='https://www.therapeuticumhaarlem.nl/'>Gezondheidscentrum Therapeuticum Haarlem</a>, <a href='https://www.antroposofiehaarlem.nl/'>Antroposofische Vereniging Haarlem</a>, <a href='https://www.therapeuticumhaarlem.nl/consultatiebureau/'>Bureau Ouder- &amp; Kindzorg</a> en <a href='https://keerkring.antroposana.nl/'>Pati&euml;ntenvereniging De Keerkring</a>.</p>

<p>Inhoud van de nieuwsbrief:</p>

<ul>
	<li><a href='#vdh'>Van Dam Huis</a></li>
	<li><a href='#gth'>Gezondheidscentrum Therapeuticum Haarlem</a></li>
	<li><a href='#bok'>Bureau Ouder- &amp; Kindzorg Haarlem</a></li>
	<li><a href='#pvkh'>Pati&euml;ntenvereniging De Keerkring Haarlem</a></li>
	<li><a href='#avh'>Antroposofische Vereniging Haarlem</a></li>
	<li><a href='#agenda'>Agenda</a></li>
</ul>
");
        }

        public string GenerateOrganizationReport(Organization organization, NewsReporterOptions options)
        {
            var sb = new StringBuilder();
            if (organization.Id != "vdh")
            {
                ItemDivider(sb);
            }
            sb.AppendLine($"<p><a id='{organization.Id}' name='{organization.Id}'></a>&nbsp;</p>");

            RenderLogo(sb, organization, options);
            var first = true;

            if (organization.Id == "vdh")
            {
                AddFixedVdhNews(sb, options);
                //ItemDivider(sb);
            }

            var newsitems = organization.NewsItems.OrderBy(p => p.Url);
            
            foreach (var item in newsitems)
            {
                if (options.ForExternalMedia && ! item.Categories.Contains(organization.MediaCategory))
                {
                    continue;
                }
                if (!first)
                {
                    ItemDivider(sb);
                }
                else
                {
                    first = false;
                }
                sb.AppendLine(GetNewsItemHtml(item, options, "nieuws" + newsId));
                newsId++;   
 
                
            }
            return sb.ToString();
        }

 
        private string GetNewsItemHtml(NewsItem item, NewsReporterOptions options, string id)
        {
            var sb = new StringBuilder();
            sb.Append("<article>");
            sb.Append($"<p><strong>{item.Title}</strong></p>");

            string expandable = options.Uitklapbaar ? "expandable" : "";

            if (options.ForPrint)
            {
                sb.AppendLine($"<p>{item.Url}</p>");
            }


            var content = CleanupStyle(item.Content);
 
            if (options.ForPrint)
            {
                sb.Append("<div class='content clearfix'>" + Unlink(CleanUpImages(content)) + "</div>");
            }
            else
            {
                sb.Append($"<div id='{id}' class='content clearfix {expandable}'>" + CleanUpImages(content) + "</div>");

                if (options.Uitklapbaar)
                {
                    sb.Append($"<p><a href='#{id}'>Lees verder</a></p>");
                }
                else
                {
                    sb.Append($"<p><a href='{item.Url}'>Lees verder</a></p>");
                }
            }

            sb.Append("</article>");

            return sb.ToString();
        }

        private string CleanupStyle(string content)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            var nodes = doc.DocumentNode.SelectNodes(".//*[@style]");
            if (nodes != null)
            {
                foreach(var node in nodes)
                {
                    node.Attributes.Remove("style");
                }
            }
            return doc.DocumentNode.OuterHtml;

        }

        private string CleanUpImages(string content)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            var images = doc.DocumentNode.SelectNodes(".//img");
            if (images != null)
            {
                foreach (var image in images)
                {
                    var imgstyle = "max-width:100%;max-height:300px";
                    if (image.HasClass("alignright"))
                    {
                        imgstyle += ";float:right";
                    }
                    
                    image.Attributes.Remove("height");
                    image.Attributes.Remove("width");
                    image.Attributes.Remove("srcset");
                    image.Attributes.Remove("sizes");
                    image.Attributes.Remove("style");
                    image.Attributes.Add("style", imgstyle);

                }
            }
            return doc.DocumentNode.OuterHtml;
        }

        private string Unlink(string source)
        {
            return Regex.Replace(source, @"<a[^>]+>([^<]+)</a>", "$1");
        }

        public string GetOutPutPath()
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
