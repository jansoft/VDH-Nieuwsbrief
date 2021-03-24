using VanDamHuisAgendaLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace VanDamHuisNieuwsbriefGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var data = LoadAppData();
            DateFromPicker.Value = data.NieuwsbriefVanaf;
            dpAgendaVanaf.Value = data.AgendaVanaf;
            dpAgendaTot.Value = data.AgendaTot;
            dpPublicatieDatum.Value = data.PublicatieDatum;
            ExterneMedia.Checked = data.ForMedia;
            rbpaper.Checked = data.ForPaper;
 
        }

        private FeedLoader loader = new FeedLoader();
        private List<Organization> organizations = new List<Organization>();
        private NewsReporter reporter = new NewsReporter();
        

        private NewsLetter LoadNewsFeeds(string after, int maxPosts, bool nieuwsbriefOnly)
        {
            var newsLetter = new NewsLetter();
            newsLetter.Organizations = LoadOrganizations();
            var useOrganizations = new List<Organization>();
            foreach(var organization in newsLetter.Organizations)
            {
                if (string.IsNullOrWhiteSpace(organization.Use))
                {
                    organization.After = after;
                    organization.MaxPosts = maxPosts;
                    loader.LoadFeed(organization, nieuwsbriefOnly);
                }
                else
                {
                    useOrganizations.Add(organization);
                }
            }

            if (useOrganizations.Count > 0)
            {
                foreach(var organization in useOrganizations)
                {
                    var useId = organization.Use;
                    var useOrganization = newsLetter.Organizations.FirstOrDefault(predicate => predicate.Id == useId);
                    if (useOrganization != null)
                    {
                        foreach(var newsItem in useOrganization.NewsItems)
                        {
                            if (newsItem.HasCategory(organization.Include))
                            {
                                organization.NewsItems.Add(newsItem);
                            }
                        }

                        if (useOrganization.Exclude != 0)
                        {
                            var remaining = new List<NewsItem>();
                            foreach (var newsItem in useOrganization.NewsItems)
                            {
                                if (!newsItem.HasCategory(useOrganization.Exclude))
                                {
                                    remaining.Add(newsItem);
                                }
                            }
                            useOrganization.NewsItems = remaining;
                        }
                    }
                }
            }
            return newsLetter;
        }

        private List<AgendaEvent> GetAgenda()
        {
            var logic = new AgendaLogic();
            var parserOptions = new AgendaEventParserOptions();
            parserOptions.From = dpAgendaVanaf.Value;
            parserOptions.Until = dpAgendaTot.Value;
            parserOptions.IncludePrivate = false;
            parserOptions.IncludePublic = true;
            return logic.GetEventsForReporting(parserOptions);
        }
 
        private string GetAfter()
        {
            return DateFromPicker.Value.ToString("yyyy-MM-ddT00:00:00");
        }

         private string Decode(string value)
        {
            return WebUtility.HtmlDecode(value);
        }

        private void GenerateHtml(object sender, EventArgs e)
        {
            SaveAppData();
            DocPathValue.Text = "Bezig met genereren. Even geduld...";
            DocPathValue.Refresh();



            var newsLetter = LoadNewsFeeds(GetAfter(), Convert.ToInt32(MaxPosts.Value), true);

            List<AgendaEvent> agenda = new List<AgendaEvent>();
            agenda = GetAgenda();

            var options = new NewsReporterOptions();
            options.ForPrint = rbpaper.Checked;
            options.ForExternalMedia = ExterneMedia.Checked;
            options.HideCanceledEvents = HideCanceledEvents.Checked;
 
 
            options.PublicatieDatum = dpPublicatieDatum.Value;

            var html = reporter.GenerateNewsLetterReport(newsLetter, agenda, options);
            var reportPath = reporter.GetReportPath();
            File.WriteAllText(reportPath, html, Encoding.UTF8);

            DocPathValue.Text = reportPath;
            var docsize = Convert.ToInt32(html.Length / 1000);
            DocSizeLabel.Text = docsize > 102 ? $"Document lengte is {docsize}KB. Te lang voor GMail (Max 102KB)" : $"Document lengte is {docsize}KB";
            Process.Start(reportPath);
        }

        private void SaveAppData()
        {
            var data = new AppData();
            data.NieuwsbriefVanaf = DateFromPicker.Value;
            data.AgendaVanaf = dpAgendaVanaf.Value;
            data.AgendaTot = dpAgendaTot.Value;
            data.PublicatieDatum = dpPublicatieDatum.Value;
            data.ForMedia = ExterneMedia.Checked;
            data.ForPaper = rbpaper.Checked;

            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(GetAppDataFile(), json);

        }

        private AppData LoadAppData()
        {
            var filepath = GetAppDataFile();
            AppData data;
            if (File.Exists(filepath))
            {
                var json = File.ReadAllText(filepath);
                data = JsonConvert.DeserializeObject<AppData>(json);
                if (data.PublicatieDatum == DateTime.MinValue)
                {
                    data.PublicatieDatum = DateTime.Now;
                }
            }
            else
            {
                data = new AppData();
                data.NieuwsbriefVanaf = DateTime.Now.AddMonths(-1);
                data.AgendaVanaf = DateTime.Now;
                data.AgendaTot = DateTime.Now.AddMonths(2);
                data.PublicatieDatum = DateTime.Now;
                
            }
            return data;
        }

        private string GetAppDataDirectory()
        {
            var appDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VDH Nieuwsbrief");
            if (!Directory.Exists(appDataDirectory))
            {
                Directory.CreateDirectory(appDataDirectory);
            }

            return appDataDirectory;
        }

        private string GetAppDataFile()
        {
            return Path.Combine(GetAppDataDirectory(), "appdata.json");
        }

        private string GetExeDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        private List<Organization> LoadOrganizations()
        {
            var path = Path.Combine(GetExeDir(), "organizations.json");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Organization>>(json);
        }

    }
}
