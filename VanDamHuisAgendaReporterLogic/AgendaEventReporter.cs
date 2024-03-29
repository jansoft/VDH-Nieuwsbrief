﻿using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Color = MigraDoc.DocumentObjectModel.Color;

namespace VanDamHuisAgendaLogic
{
    public class AgendaEventReporter
    {
        double topmargin = 35;
        double leftmargin = 25;
        double rightmargin = 25;
        double bottommargin = 40; //25;
        double liney = 272.5; // 278.2;

        private readonly List<AgendaEvent> eventsToReport;
        private readonly string reportDirectory;

        public AgendaEventReporter(List<AgendaEvent> eventsToReport, string reportDirectory)
        {
            this.eventsToReport = eventsToReport;
            this.reportDirectory = reportDirectory;
        }

        
        public string Report(ReporterOptions options)
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

            if (options.ShowBackground)
            {
                AddLogo(header);
            }
            
            

            var vdhRgbColor = Color.FromRgb(57, 70, 157);
 
            // Toon Agenda rechtsboven
                
            var agendaframe = header.AddTextFrame();
            agendaframe.Width = Unit.FromMillimeter(80);
            agendaframe.RelativeVertical = RelativeVertical.Page;
            agendaframe.RelativeHorizontal = RelativeHorizontal.Page;
            agendaframe.Top = Unit.FromMillimeter(15);
            agendaframe.Left = document.DefaultPageSetup.PageWidth - XUnit.FromMillimeter(rightmargin) - Unit.FromMillimeter(80);

            var imgqr = header.AddImage(GetQRCode("https://vandamhuis.nl#agenda"));
            imgqr.Width = Unit.FromMillimeter(30);
            imgqr.Height = Unit.FromMillimeter(30);
            imgqr.Left = Unit.FromMillimeter(40);
            imgqr.Top = Unit.FromMillimeter(0);
            var ph1 = agendaframe.AddParagraph();
            ph1.Format.Alignment = ParagraphAlignment.Right;
            var h1 = ph1.AddFormattedText($"Agenda van {options.DateFrom:dd-MM} tot {options.DateUntil:dd-MM}");
            h1.Font.Color = vdhRgbColor;
            h1.Font.Size = Unit.FromPoint(16);
            h1.Font.Name = "Rubik Medium";

            if (options.PrivateEventsIncluded)
            {
                var psub = agendaframe.AddParagraph();
                psub.Format.Alignment = ParagraphAlignment.Right;
                var pscope = psub.AddFormattedText("Voor intern gebruik");
                pscope.Font.Color = vdhRgbColor;
                pscope.Font.Size = Unit.FromPoint(12);
                pscope.Font.Name = "Rubik Light";
            }

            // add footer
            var footer = section.Footers.Primary;

           
            AddFooterText(footer, vdhRgbColor, options.ShowBackground);
            

            

            var pintro = section.AddParagraph();
            pintro.Format.SpaceAfter = Unit.FromPoint(16);
            // var introtext = pintro.AddFormattedText("Deze agenda bevat de evenementen van alle deelnemende organisaties: therapeuticum, vereniging, consultatieburea en keerkring.");

            var events = eventsToReport;
            if (!options.AllEvents)
            {
                events = eventsToReport.GetRange(0, options.MaxEvents);
            }

            foreach (var agendaEvent in events)
            {
                if (agendaEvent.Event.event_status == "-1")
                {
                    continue;
                }
                

                if (options.IncludeQRCodes)
                {

                    var table = section.AddTable();
                    table.Format.SpaceAfter = Unit.FromCentimeter(0.5);
                    var col1 = table.AddColumn();
                    col1.Width = Unit.FromCentimeter(2.5);
                    var col2 = table.AddColumn();
                    col2.Width = Unit.FromCentimeter(15);
                    var row = table.AddRow();


                    var qrimage = row.Cells[0].AddImage(GetQRCode(agendaEvent.Event.url));
                    qrimage.Height = Unit.FromCentimeter(2);
                    qrimage.Width = Unit.FromCentimeter(2);

                    var para2 = row.Cells[1].AddParagraph();
                    var title2 = para2.AddFormattedText(agendaEvent.Event.event_name);
                    title2.Font.Name = "Rubik Medium";
                    para2.AddLineBreak();

                    var reeksInfo2 = agendaEvent.ReeksInfo;
                    var datetext2 = para2.AddFormattedText($"{agendaEvent.Event.event_start_date:dd MMMM yyyy} {agendaEvent.Event.event_start_time:HH:mm} - {agendaEvent.Event.event_end_time:HH:mm} {reeksInfo2}");

                    if (!string.IsNullOrEmpty(agendaEvent.Event.info))
                    {
                        para2.AddLineBreak();
                        para2.AddFormattedText(agendaEvent.Event.info);
                    }

                    para2.AddLineBreak();
                    var orgtext2 = para2.AddFormattedText(GetOrganizationName(agendaEvent.Event.organisatie));
                    orgtext2.Font.Color = GetOrganizationColor(agendaEvent.Event.organisatie);

 
                    continue;
                }

                var para = section.AddParagraph();
                para.Format.SpaceAfter = Unit.FromPoint(12);

                para.Format.KeepTogether = true;
                if (options.IncludeQRCodes)
                {
                    var qrimage = para.AddImage(GetQRCode(agendaEvent.Event.url));
                    qrimage.Height = Unit.FromCentimeter(2);
                    qrimage.Width = Unit.FromCentimeter(2);
                }


                    var privateIndicator = options.PrivateEventsIncluded && options.PublicEventsIncluded && agendaEvent.Event.event_private ? " (intern)" : "";
                    var title = para.AddFormattedText(agendaEvent.Event.event_name + privateIndicator);
                    title.Font.Name = "Rubik Medium";

                para.AddLineBreak();

                var reeksInfo = agendaEvent.ReeksInfo;
                var datetext = para.AddFormattedText($"{agendaEvent.Event.event_start_date:dd MMMM yyyy} {agendaEvent.Event.event_start_time:HH:mm} - {agendaEvent.Event.event_end_time:HH:mm} {reeksInfo}");


                if (!string.IsNullOrEmpty(agendaEvent.Event.info))
                {
                    para.AddLineBreak();
                    para.AddFormattedText(agendaEvent.Event.info);
                }

                para.AddLineBreak();
                var orgtext = para.AddFormattedText(GetOrganizationName(agendaEvent.Event.organisatie));
                orgtext.Font.Color = GetOrganizationColor(agendaEvent.Event.organisatie);


            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;
            renderer.RenderDocument();

            var pdfdoc = renderer.PdfDocument;

            // vandamhuis.nl color #39469D
            var vdhColor = XColor.FromArgb(57, 70, 157);
            var vdhPen = new XPen(vdhColor);

            if (options.ShowBackground)
            {
                foreach (var page in pdfdoc.Pages)
                {
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    var y = XUnit.FromMillimeter(liney);
                    var x2 = page.Width - XUnit.FromMillimeter(rightmargin);


                    gfx.DrawLine(vdhPen, 0, y, x2, y);
                    gfx.DrawLine(vdhPen, x2, y, page.Width, y - XUnit.FromMillimeter(15));
                }
            }

            var reportpath = GetReportPath(options);
            renderer.PdfDocument.Save(reportpath);
            //Process.Start(reportpath);
            return reportpath;
        }

        private string GetQRCode(string url)
        {
            string imageFilename = GetPngImageFileName(url);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(imageFilename, ImageFormat.Png);
            return imageFilename;
        }

        private string GetPngImageFileName(string url)
        {
            string directory = GetAppDirectory();
            string filename = url.ToLowerInvariant().Replace("https://", "").Replace("http://", "").Replace("/", ".").RemoveTrailingCharacter(".") + ".qrcode.png";
            return Path.Combine(directory, filename);
        }



        private string GetAppDirectory()
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Van Dam Huis agenda\\QRCodes");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }
        private void AddLogo(HeaderFooter header)
        {
            var logoPath = GetLogoPath();
            var headerimg = header.AddImage(logoPath);
            headerimg.Height = Unit.FromCentimeter(3);
            headerimg.RelativeHorizontal = RelativeHorizontal.Page;
            headerimg.RelativeVertical = RelativeVertical.Page;
            headerimg.Left = Unit.FromMillimeter(20);
            headerimg.Top = Unit.FromMillimeter(5);
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
                    return HexToColor("901d6a"); // HexToColor("ba79a0");
                case "algemeen":
                    return HexToColor("39469D");
                default:
                    return HexToColor("FFFFFF");

            }
        }

        private string GetOrganizationName(string organisatie)
        {
            switch (organisatie.ToLowerInvariant())
            {
                case "therapeuticum":
                    return "Gezondheidscentrum Therapeuticum Haarlem";
                case "vereniging":
                    return "Antroposofische Vereniging Haarlem";
                case "consultatiebureau":
                    return "Bureau Ouder- & Kindzorg";
                case "keerkring":
                    return "Patiëntenvereniging De Keerkring"; 
                case "algemeen":
                    return "Van Dam Huis";
                default:
                    return "";

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

        private void AddWebsiteReference(PdfPage page)
        {
            
        }

        private void AddFooterText(HeaderFooter footer, Color fontcolor, bool showBackground)
        {
            var notice = footer.AddTextFrame();
            notice.RelativeVertical = RelativeVertical.Page;
            notice.RelativeHorizontal = RelativeHorizontal.Page;
            notice.Top = Unit.FromMillimeter(262);
            notice.Left = Unit.FromMillimeter(leftmargin);
            notice.Width = Unit.FromMillimeter(150);
            var pnotice = notice.AddParagraph();
            //pnotice.AddText("De meest recente agenda vindt u op www.vandamhuis.nl");
            pnotice.AddText("Kijk voor meer info op www.vandamhuis.nl of op de flyers op het prikbord of in de wachtruimte.");

            pnotice.Format.Font.Name = "Rubik Light";
            pnotice.Format.Font.Color = fontcolor;
            pnotice.Format.Font.Size = Unit.FromPoint(10.5);

            if (showBackground)
            {
                var leftcell = footer.AddTextFrame();
                leftcell.RelativeVertical = RelativeVertical.Page;
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

        }

        private string GetReportPath(ReporterOptions options)
        {
            var scope = "";
            if (options.PrivateEventsIncluded)
            {
                scope = "voor-intern-gebruik";
            }
            else if (options.PublicEventsIncluded)
            {
                scope = "voor-publiek-gebruik";
            }
             
            var reportpath = Path.Combine(reportDirectory, $"VDH-Agenda-{scope}-{DateTime.Now:yyyy-MM-dd HHmm}.pdf");
            return reportpath;

        }

 
    }
}
