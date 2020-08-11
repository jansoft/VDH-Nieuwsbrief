using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class NewsReporter
    {
        private CultureInfo ciNL = new CultureInfo("nl-NL");

        private const string header = @"<html><head><title>Nieuwsbrief Van Dam Huis (gegenereerd)</title>
<style>
@import url('https://fonts.googleapis.com/css2?family=Rubik:wght@300;500&display=swap');
html, p {
    font-family: 'Rubik', sans-serif;
    font-size: 16pt;
    font-weight: 300;
}

h1 {
    font-size: 2em;
}

h2 {
    font-size: 1.5em;
}

h1, h2, h3 {
    font-weight:300;
}

b, strong {
    font-weight:500;
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
}
</style>
</head><body>
<section class='nieuwsbrief'>";

        public string GenerateNewsLetterReport(NewsLetter newsLetter, bool forPrint)
        {
            var sb = new StringBuilder();
            sb.AppendLine(header);

            foreach (var organization in newsLetter.Organizations)
            {
                sb.AppendLine(GenerateOrganizationReport(organization, forPrint));
            }

            sb.AppendLine("</section></body></html>");

            var html = sb.ToString();
            //var path = GetReportPath();
            //File.WriteAllText(path, html, Encoding.UTF8);

            //return path;
            return html;

        }

        public string GenerateOrganizationReport(Organization organization, bool forPrint, bool asPage = false)
        {
            var sb = new StringBuilder();
            if (asPage)
            {
                sb.AppendLine(header);
            }
            sb.AppendLine($"<h1 style='color:{organization.Color}'>{organization.Name}</h1>");
            foreach (var item in organization.NewsItems)
            {
                sb.AppendLine(GetNewsItemHtml(item, forPrint));
            }
            if (asPage)
            {
                sb.AppendLine("</section></body></html>");
            }
            return sb.ToString();
        }

        public string GenerateNewsItemReport(NewsItem newsItem, bool includeLinkToPost, bool asPage = false)
        {
            var sb = new StringBuilder();
            if (asPage)
            {
                sb.AppendLine(header);
            }
            
            sb.AppendLine(GetNewsItemHtml(newsItem, includeLinkToPost));

            if (asPage)
            {
                sb.AppendLine("</section></body></html>");
            }
            var html = sb.ToString();

            return html;
        }

        private string GetNewsItemHtml(NewsItem item, bool forPrint)
        {
            var sb = new StringBuilder();
            sb.Append("<article>");

            if (!forPrint)
            {
                sb.Append($"<a href='{item.Url}'><h2>{item.Title}</h2></a>");
            }
            else
            {
                sb.Append($"<h2>{item.Title}</h2>");
                sb.Append($"<p>{item.Url}</p>");
            }
            sb.Append("<div class='publishdate'>" + item.PublishDate.ToString("d MMMM yyyy", ciNL.DateTimeFormat) + "</div>");
             sb.Append("<div class='content'>" + item.Content + "</div>");
            sb.Append("</article>");

            return sb.ToString();
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
