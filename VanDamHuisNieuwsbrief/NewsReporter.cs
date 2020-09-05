using VanDamHuisAgendaLogic;
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
                    if (options.ForPrint)
                    {
                        sb.AppendLine($"<p><strong>{item.Event.event_name}</strong><br>{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}</p>");
                    }
                    else
                    {
                        sb.AppendLine($"<li><a href='{item.Event.url}'>{item.Event.event_name}</a><br>{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}</li>");
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
</style>");
            return;
            
            var fontsizes = options.ForPrint ? options.Config.PaperFontSize : options.Config.DigitalFontSize;
            var fp = fontsizes.Paragraph;
            var fh1 = fontsizes.Heading1;
            var fh2 = fontsizes.Heading2;

  
            string getBold()
            {
                return options.ForPrint ? "font-family: 'Rubik Medium' !important;" : "font-weight: 500 !important;";
            }

            string getNormal ()
            {
                return "font-weight: 300 !important;";
            }

            var eventTitleWeight = options.Config.EventTitleBold ? getBold() : getNormal();
            var newsTitleWeight = options.Config.NewsTitleBold ? getBold() : getNormal();
            var newsTitleUnderline = options.Config.NewsTitleUnderline ? "text-decoration:underline !important;" : "";
            var organizationTitleWeight = options.Config.OrganizationTitleBold ? getBold() : getNormal();

            sb.AppendLine($@"<style>
@import url('https://fonts.googleapis.com/css2?family=Rubik:wght@300;500&display=swap');
html, body, p, li {{
    font-family: 'Rubik', sans-serif !important;
    font-size: {fp} !important;
    font-weight: 300 !important;
    color: {options.Config.TextColor} !important;
}}

p strong,
li strong,
p b,
li b {{
    font-weight: 500 !important;
}}

section.nieuwsbrief img {{
    max-width:100% !important;
    height: auto !important;
}}

section.nieuwsbrief h1 {{
    font-size: {fh1} !important;
}}

h2.organization-title,
h2.agenda-title,
section.nieuwsbrief h2.organization-title,
section.nieuwsbrief h2.agenda-title {{
    font-size: {fh1} !important;    
    {organizationTitleWeight}
}}

section.nieuwsbrief h2 {{
    font-size: {fh2} !important;
}}

h1, h2, h3 {{
    font-weight:300 !important;
}}

section.nieuwsbrief b, section.nieuwsbrief strong {{
    font-weight:500 !important;
}}

section.nieuwsbrief p span.event-title,
section.nieuwsbrief p span.event-title > a {{
    {eventTitleWeight}

}}
 h2.news-title,
section.nieuwsbrief h2.news-title,
a > h2.news-title,
section.nieuwsbrief a > h2.news-title {{
    {newsTitleWeight}
    {newsTitleUnderline}
}}

a {{
    color: {options.Config.LinkColor} !important;
}}


section.nieuwsbrief {{
    box-sizing: border-box !important;
    padding-left:2em !important;
    padding-right: 2em !important;
    margin-left:auto !important;
    margin-right:auto !important;
}}

article {{
    margin-bottom: 2em !important;
    margin-top:1em !important;
}}


span.bar.algemeen {{
    color: #39469D !important;
}}

span.bar.therapeuticum {{
	color: #2396c9 !important;
}}

span.bar.vereniging {{
	color: #DE557D !important;
}}

span.bar.keerkring {{
	color: #ba79a0 !important;
}}

span.bar.consultatiebureau {{
	color: #ec744e !important;
}}

section.agenda {{
    margin-bottom: 2em !important;
}}

span.title {{
    font-weight:500 !important;
}}

hr.item-divider {{
    border: none !important;
    height: 2px !important;
    background-color: rgb(234, 234, 234) !important;
}}

</style>");
        }

        public Organization GetVanDamHuis(NewsLetter newsLetter)
        {
            return newsLetter.Organizations.FirstOrDefault(p => p.Name == "Van Dam Huis");
        }

        public string GenerateNewsLetterReport(NewsLetter newsLetter, List<AgendaEvent> agenda, NewsReporterOptions options)
        {
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

        private void RenderIntro(StringBuilder sb, NewsLetter newsLetter, NewsReporterOptions options)
        {
            var organization = GetVanDamHuis(newsLetter);
            RenderLogo(sb, organization, options);

            sb.AppendLine($"<h2 class='organization-title' style='color:{organization.Color} !important'>Van Dam Huis | Nieuwsbrief {options.PublicatieDatum:MMMM yyyy}</h1>");

            if (options.ForPrint)
            {
                sb.AppendLine("<p>Het Van Dam Huis biedt onderdak aan vier organisaties: Gezondheidscentrum Therapeuticum Haarlem, Antroposofische Vereniging Haarlem, Bureau Ouder- & Kindzorg en Patiëntenvereniging De Keerkring.</p>");
            }
            else
            {
                sb.AppendLine("<p>Het Van Dam Huis biedt onderdak aan vier organisaties: <a href='https://www.therapeuticumhaarlem.nl/'>Gezondheidscentrum Therapeuticum Haarlem</a>, <a href='https://www.antroposofiehaarlem.nl/'>Antroposofische Vereniging Haarlem</a>, <a href='https://www.therapeuticumhaarlem.nl/consultatiebureau/'>Bureau Ouder- & Kindzorg</a> en <a href='https://keerkring.antroposana.nl/'>Patiëntenvereniging De Keerkring</a>.</p>");
            }

            sb.AppendLine(@"<p>Inhoud van de nieuwsbrief:</p>
<ul>");
            foreach(var contentOrganization in newsLetter.Organizations)
            {
                sb.AppendLine($"<li><a href='#{contentOrganization.Id}'>{contentOrganization.Name}</a></li>");
            }
            sb.AppendLine("<li><a href='#agenda'>Agenda</a></li></ul>");
        }

        private void RenderLogo(StringBuilder sb, Organization organization, NewsReporterOptions options)
        {
            string logo = "";
            int h = options.Config.LogoHeight;
            int w = (int)(h * organization.LogoRatio);

            logo = $"<div class='logo'><img src='{organization.LogoUrl}' style='height:auto;max-width:100%'></div>";

            sb.AppendLine(logo);

        }

        private void ItemDivider(StringBuilder sb)
        {
            sb.AppendLine("<hr style='margin-top:18px;margin-bottom:18px'/>");
        }

        public string GenerateOrganizationReport(Organization organization, NewsReporterOptions options)
        {
            var sb = new StringBuilder();
            ItemDivider(sb);
            sb.AppendLine($"<p><a id='{organization.Id}' name='{organization.Id}'></a>&nbsp;</p>");

            RenderLogo(sb, organization, options);

            var first = true;
            foreach (var item in organization.NewsItems)
            {
                if (!first)
                {
                    ItemDivider(sb);
                }
                else
                {
                    first = false;
                }
                sb.AppendLine(GetNewsItemHtml(item, options));
 
                
            }
            return sb.ToString();
        }

 
        private string GetNewsItemHtml(NewsItem item, NewsReporterOptions options)
        {
            var sb = new StringBuilder();
            sb.Append("<article>");
            sb.Append($"<p style='font-size:13px'><strong>{item.Title}</strong></p>");

            if (options.ForPrint)
            {
                sb.AppendLine($"<p>{item.Url}</p>");
            }
            else
            {
                sb.Append($"<p><a href='{item.Url}'>Lees verder</a></p>");
            }
            
 
 
            if (options.ForPrint)
            {
                sb.Append("<div class='content'>" + Unlink(item.Content) + "</div>");
            }
            else
            {
                sb.Append("<div class='content'>" + CleanUpImages(item.Content) + "</div>");
            }

            sb.Append("</article>");

            return sb.ToString();
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
                    image.Attributes.Remove("height");
                    image.Attributes.Remove("width");
                    image.Attributes.Remove("srcset");
                    image.Attributes.Remove("sizes");
                    image.Attributes.Remove("style");
                    image.Attributes.Add("style", "width:100%;max-width:600px");

                }
            }
            return doc.DocumentNode.OuterHtml;
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
