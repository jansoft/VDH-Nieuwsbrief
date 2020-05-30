using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class AgendaEventReporter
    {
        double topmargin = 35;
        double leftmargin = 25;
        double rightmargin = 25;
        double bottommargin = 25;
        double liney = 278.2;

        private readonly List<AgendaEvent> eventsToReport;
        private readonly string reportDirectory;

        public AgendaEventReporter(List<AgendaEvent> eventsToReport, string reportDirectory)
        {
            this.eventsToReport = eventsToReport;
            this.reportDirectory = reportDirectory;
        }

        
        public void Report()
        {
            var document = new Document();
            document.DefaultPageSetup.TopMargin = Unit.FromMillimeter(topmargin);
            document.DefaultPageSetup.LeftMargin = Unit.FromMillimeter(leftmargin);
            document.DefaultPageSetup.RightMargin = Unit.FromMillimeter(rightmargin);
            document.DefaultPageSetup.BottomMargin = Unit.FromMillimeter(bottommargin);

            Style normal = document.Styles["normal"];
            normal.Font.Name = "Rubik Light";
            normal.Font.Size = Unit.FromPoint(12);

            // Add a section to the document
            Section section = document.AddSection();

            // add header
            var header = section.Headers.Primary;
            // @"d:\_Jan\Antroposofie\Website\Sanne Schuurman\Logoset\PNG (150x150px)\Logo Van Dam Huis (150x150 px).png"
            var logoPath = GetLogoPath();
            var headerimg = header.AddImage(logoPath);
            headerimg.Height = Unit.FromCentimeter(3);
            headerimg.RelativeHorizontal = RelativeHorizontal.Page;
            headerimg.RelativeVertical = RelativeVertical.Page;
            headerimg.Left = Unit.FromMillimeter(20);
            headerimg.Top = Unit.FromMillimeter(5);

            // add footer
            var footer = section.Footers.Primary;

            var vdhRgbColor = Color.FromRgb(57, 70, 157);
            AddFooterText(footer, vdhRgbColor);

            var ph1 = section.AddParagraph();
            ph1.Format.SpaceAfter = Unit.FromPoint(16);
            var h1 = ph1.AddFormattedText("Agenda");
            h1.Font.Color = Color.FromRgb(34, 57, 103);
            h1.Font.Size = Unit.FromPoint(16);
            h1.Font.Name = "Rubik Medium";

            var pintro = section.AddParagraph();
            pintro.Format.SpaceAfter = Unit.FromPoint(16);
           // var introtext = pintro.AddFormattedText("Deze agenda bevat de evenementen van alle deelnemende organisaties: therapeuticum, vereniging, consultatieburea en keerkring.");

            AddLegend(section);
            var plegendspacer = section.AddParagraph("");
            plegendspacer.Format.SpaceAfter = Unit.FromMillimeter(15);


            foreach(var agendaEvent in eventsToReport)
            {
                var para = section.AddParagraph();

                para.Format.SpaceAfter = Unit.FromPoint(12);
                para.Format.Borders.Left.Style = BorderStyle.Single;
                para.Format.Borders.Left.Width = Unit.FromMillimeter(2);
                para.Format.Borders.Left.Color = GetOrganizationColor(agendaEvent.Event.organisatie);
                para.Format.Borders.DistanceFromLeft = Unit.FromMillimeter(2);
                para.Format.KeepTogether = true;
                
                var hyperlink = para.AddHyperlink(agendaEvent.Event.url, HyperlinkType.Web);
                var linktext = hyperlink.AddFormattedText(agendaEvent.Event.event_name);
                linktext.Underline = Underline.Single;
                linktext.Color = Color.FromRgb(53, 90, 162);
                linktext.Font.Name = "Rubik Medium";

                para.AddLineBreak();

                var reeksInfo = "";
                if (!string.IsNullOrWhiteSpace(agendaEvent.Event.reeks) && !string.IsNullOrWhiteSpace(agendaEvent.ReeksInfo))
                {
                    reeksInfo = agendaEvent.ReeksInfo;
                }

                var datetext = para.AddFormattedText($"{agendaEvent.Event.event_start_date:dd MMMM yyyy} {agendaEvent.Event.event_start_time:HH:mm} - {agendaEvent.Event.event_end_time:HH:mm} {reeksInfo}");
            }

 
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;
            renderer.RenderDocument();

            var pdfdoc = renderer.PdfDocument;

            // vandamhuis.nl color #39469D
            var vdhColor = XColor.FromArgb(57, 70, 157);
            var vdhPen = new XPen(vdhColor);

            foreach (var page in pdfdoc.Pages)
            {
                XGraphics gfx = XGraphics.FromPdfPage(page);
                var y = XUnit.FromMillimeter(liney);
                var x2 = page.Width - XUnit.FromMillimeter(rightmargin);
               
               
                gfx.DrawLine(vdhPen, 0, y, x2, y);
                gfx.DrawLine(vdhPen, x2, y, page.Width, y - XUnit.FromMillimeter(15));
            }

            var reportpath = GetReportPath();
            renderer.PdfDocument.Save(reportpath);
            Process.Start(reportpath);
        }

 
        private void AddLegend(Section section)
        {
            var table = section.AddTable();
            var col1 = table.AddColumn();
            var col2 = table.AddColumn();
            var col3 = table.AddColumn();
            var col4 = table.AddColumn();
            var col5 = table.AddColumn();
            var row = table.AddRow();
            
            var orgs = new[] { "Algemeen", "Therapeuticum", "Vereniging", "Consultatiebureau", "Keerkring"};
            var orgwidths = new[] { 25, 35, 30, 40, 30 };
            var cellindex = 0;

            foreach(var org in orgs)
            {
                table.Columns[cellindex].Width =  Unit.FromMillimeter(orgwidths[cellindex]);
                var p = row.Cells[cellindex].AddParagraph();
                var ptext = p.AddFormattedText(org);
                var border = row.Cells[cellindex].Borders.Left;
                border.Width = Unit.FromMillimeter(2);
                border.Color = GetOrganizationColor(org);
                
                cellindex++;
            }
  
            
        }

        private string GetLogoPath()
        {
            var appDirectory = Path.GetDirectoryName(new Uri(this.GetType().Assembly.GetName().CodeBase).LocalPath);
            return Path.Combine(appDirectory, "Assets", "logo.png");
        }

        private Color GetOrganizationColor(string organisatie)
        {
            switch(organisatie.ToLowerInvariant())
            {
                case "therapeuticum":
                    return HexToColor("2396c9");
                case "vereniging":
                    return HexToColor("DE557D");
                case "consultatiebureau":
                    return HexToColor("ec744e");
                case "keerkring":
                    return HexToColor("ba79a0");
                case "algemeen":
                    return HexToColor("39469D");
                default:
                    return HexToColor("FFFFFF");

            }
        }

        private  Color HexToColor(string hexString)
        {
            //replace # occurences
            if (hexString.IndexOf('#') != -1)
                hexString = hexString.Replace("#", "");

            byte r, g, b = 0;

            r = byte.Parse(hexString.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            g = byte.Parse(hexString.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            b = byte.Parse(hexString.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            return Color.FromRgb(r, g, b);
        }

        private void AddFooterText(HeaderFooter footer, Color fontcolor)
        {
            
            var leftcell = footer.AddTextFrame();
            leftcell.RelativeVertical =RelativeVertical.Page;
            leftcell.RelativeHorizontal = RelativeHorizontal.Page;
            leftcell.Top = Unit.FromMillimeter(280);
            leftcell.Left = Unit.FromMillimeter(leftmargin);
            leftcell.Width = Unit.FromMillimeter(80);
            
            var rightcell = footer.AddTextFrame();
            rightcell.RelativeVertical = RelativeVertical.Page;
            rightcell.RelativeHorizontal = RelativeHorizontal.Page;
            rightcell.Top = Unit.FromMillimeter(280);
            rightcell.Width = Unit.FromMillimeter(80);
            rightcell.Left = Unit.FromMillimeter(210 - rightmargin - 80);
           
            var fontname = "Rubik Light";

            var pf1 = leftcell.AddParagraph();
            pf1.Format.Font.Color = fontcolor;
            pf1.Format.Font.Name = "Rubik Medium";
            pf1.Format.Font.Size = Unit.FromPoint(9);
            pf1.AddText("Van Dam Huis");

            
           
            var pf2 = leftcell.AddParagraph();
            pf2.Format.Font.Color = fontcolor;
            pf2.Format.Font.Name = fontname;
            pf2.Format.Font.Size = Unit.FromPoint(9);
            pf2.AddText("Prinsen Bolwerk 3B");

            var pf3 = leftcell.AddParagraph();
            pf3.Format.Font.Color = fontcolor;
            pf3.Format.Font.Name = fontname;
            pf3.Format.Font.Size = Unit.FromPoint(9);
            pf3.AddText("2011 MA Haarlem");

            var pf4 = rightcell.AddParagraph();
            pf4.Format.Font.Color = fontcolor;
            pf4.Format.Font.Name = fontname;
            pf4.Format.Font.Size = Unit.FromPoint(9);
            pf4.AddText("");

            var pf5 = rightcell.AddParagraph();
            pf5.Format.Font.Color = fontcolor;
            pf5.Format.Font.Name = fontname;
            pf5.Format.Font.Size = Unit.FromPoint(9);
            pf5.AddText("");

            var pf6 = rightcell.AddParagraph();
            pf6.Format.Font.Color = fontcolor;
            pf6.Format.Font.Name = fontname;
            pf6.Format.Font.Size = Unit.FromPoint(9);
            pf6.Format.Alignment = ParagraphAlignment.Right;
            pf6.AddText("www.vandamhuis.nl");

        }

        private string GetReportPath()
        {
            var reportpath = Path.Combine(reportDirectory, $"Agenda-report-{DateTime.Now:yyyy-MM-dd HHmm}.pdf");
            return reportpath;

        }

 
    }
}
