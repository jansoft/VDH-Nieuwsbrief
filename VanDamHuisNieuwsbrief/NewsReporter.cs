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
                sb.AppendLine("<section class='agenda'>");
                sb.AppendLine($"<h1 class='agenda-title' style='color:#39469d !important'>Agenda</h1>");
                if (options.ForPrint)
                {
                    sb.AppendLine("<p>U vindt de actuele agenda op https://vandamhuis.nl en op de prikborden in het Van Dam Huis</p>");
                }
                else
                {
                    sb.AppendLine("<p>U vindt de actuele agenda op <a href='https://vandamhuis.nl'>Van Dam Huis</a></p>");
                }

                // legend 
                // black large square = &#x2B1B;
                var mark = "&#x275A;";
                sb.AppendLine($@"<p><span class='algemeen bar'>{mark}</span> Algemeen</span> <span class='therapeuticum bar'>{mark}</span> Therapeuticum <span class='vereniging bar'>{mark}</span> Vereniging <span class='consultatiebureau bar'>{mark}</span> Consultatiebureau <span class='keerkring bar'>{mark}</span>  Keerkring </p>");
 
                foreach (var item in agenda)
                {
                    if (options.ForPrint)
                    {
                        sb.AppendLine($"<p class='event'><span class='bar {item.Event.organisatie}'>{mark}</span> <span class='event-title'>{item.Event.event_name}</span><br><span>{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}</span></p>");
                    }
                    else
                    {
                        sb.AppendLine($"<p class='event'><span class='bar {item.Event.organisatie}'>{mark}</span> <span class='event-title'><a href='{item.Event.url}'>{item.Event.event_name}</a></span><br><span >{item.Event.event_start_date:d MMMMM yyyy} {item.Event.event_start_time:HH:mm} - {item.Event.event_end_time:HH:mm}</span></p>");
                    }
                }
                sb.AppendLine("</section>");
            }

        }

        private void RenderHeader(StringBuilder sb, NewsReporterOptions options)
        {
            var media = options.ForPrint ? "print" : "digital";
            sb.AppendLine($@"<html><head><title>Van Dam Huis | Nieuwsbrief {options.PublicatieDatum:MMMM yyyy}</title>
</head><body>
<section class='nieuwsbrief {media}' style='max-width:600px;width:100%'>");
        }

        private void RenderStyle(StringBuilder sb, NewsReporterOptions options)
        {
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
            var organizationTitleWeight = options.Config.OrganizationTitleBold ? getBold() : getNormal();

            sb.AppendLine($@"<style>
@import url('https://fonts.googleapis.com/css2?family=Rubik:wght@300;500&display=swap');
html, p, section.nieuwsbrief * {{
    font-family: 'Rubik', sans-serif !important;
    font-size: {fp} !important;
    font-weight: 300 !important;
    color: {options.Config.TextColor} !important;
}}

section.nieuwsbrief img {{
    max-width:100% !important;
    height: auto !important;
}}

section.nieuwsbrief h1 {{
    font-size: {fh1} !important;
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

section.nieuwsbrief h2.news-title,
section.nieuwsbrief a > h2.news-title {{
    {newsTitleWeight}
}}

section.nieuwsbrief a > h2.news-title {{
    color: {options.Config.LinkColor} !important;
}}

section.nieuwsbrief a {{
    color: {options.Config.LinkColor} !important;
}}

section.nieuwsbrief h1.organization-title,
section.nieuwsbrief h1.agenda-title {{
    {organizationTitleWeight}
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
            
            RenderIntro(sb, newsLetter, options);

            RenderAgenda(sb, agenda, options);

            foreach (var organization in newsLetter.Organizations)
            {
                sb.AppendLine(GenerateOrganizationReport(organization, options));
            }

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

            sb.AppendLine($"<h1 class='organization-title' style='color:{organization.Color} !important'>Van Dam Huis | Nieuwsbrief {options.PublicatieDatum:MMMM yyyy}</h1>");

            if (options.ForPrint)
            {
                sb.AppendLine("<p>Het Van Dam Huis biedt onderdak aan vier organisaties: Gezondheidscentrum Therapeuticum Haarlem, Antroposofische Vereniging Haarlem, Bureau Ouder- & Kindzorg en Patiëntenvereniging De Keerkring.</p>");
            }
            else
            {
                sb.AppendLine("<p>Het Van Dam Huis biedt onderdak aan vier organisaties: <a href='https://www.therapeuticumhaarlem.nl/'>Gezondheidscentrum Therapeuticum Haarlem</a>, <a href='https://www.antroposofiehaarlem.nl/'>Antroposofische Vereniging Haarlem</a>, <a href='https://www.therapeuticumhaarlem.nl/consultatiebureau/'>Bureau Ouder- & Kindzorg</a> en <a href='https://keerkring.antroposana.nl/'>Patiëntenvereniging De Keerkring</a>.</p>");
            }
  
            sb.AppendLine(@"<p>Inhoud van de nieuwsbrief</p>
<ul>
    <li>Agenda</li>
    <li>Van Dam Huis</li>
    <li>Gezondheidscentrum Therapeuticum</li>
    <li>Antroposofische Vereniging</li>
    <li>Patiëntenvereniging De Keerkring</li>
</ul>");
        }

        private void RenderLogo(StringBuilder sb, Organization organization, NewsReporterOptions options)
        {
            string logo = "";
            int h = options.Config.LogoHeight;
            int w = (int)(h * organization.LogoRatio);

            if (options.ForPrint)
            {
                logo = $"<div class='logo'><img src='{organization.LogoUrl}'width='{w}px' height='{h}px'></div>";
            }
            else
            {
                logo = $"<div class='logo'><img src='{organization.LogoUrl}' width='{w}px' height='{h}px'></div>";
            }
            sb.AppendLine(logo);

        }

        public string GenerateOrganizationReport(Organization organization, NewsReporterOptions options)
        {
            var sb = new StringBuilder();
            
            if (!options.Config.LogoAfterHeading)
            {
                RenderLogo(sb, organization, options);
            }

            sb.AppendLine($"<h1 class='organization-title' style='color:{organization.Color} !important'>{organization.Name}</h1>");

            if (options.Config.LogoAfterHeading)
            {
                RenderLogo(sb, organization, options);
            }

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
                sb.Append($"<a href='{item.Url}'><h2 class='news-title'>{item.Title}</h2></a>");
            }
            else
            {
                sb.Append($"<h2 class='news-title'>{item.Title}</h2>");
            }

            if (options.IncludeNewsSummary && !string.IsNullOrWhiteSpace(item.Summary))
            {
                sb.Append("<div class='content'>" + item.Summary + "</div>");
            }

            if (options.IncludeNewsContent)
            {
                if (options.ForPrint)
                {
                    sb.Append("<div class='content'>" + Unlink(item.Content) + "</div>");
                }
                else
                {
                    sb.Append("<div class='content'>" + CleanUpImages(item.Content) + "</div>");
                }
            }
            sb.Append("</article>");

            return sb.ToString();
        }

        private string CleanUpImages(string content)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            var images = doc.DocumentNode.SelectNodes(".//img");
            foreach (var image in images)
            {
                image.Attributes.Remove("height");
                image.Attributes.Remove("width");
                image.Attributes.Remove("srcset");
                image.Attributes.Remove("sizes");
                image.Attributes.Remove("style");
                image.Attributes.Add("style", "width:100%;max-width:600px");
                
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
