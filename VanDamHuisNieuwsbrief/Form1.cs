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
            DateFromPicker.Value = DateTime.Now.AddMonths(-1);
            dpAgendaVanaf.Value = DateTime.Now;
            dpAgendaTot.Value = DateTime.Now.AddMonths(2);
            dpPublicatieDatum.Value = DateTime.Now;
 
        }

        private FeedLoader loader = new FeedLoader();
        private List<Organization> organizations = new List<Organization>();
        private NewsReporter reporter = new NewsReporter();
        

        private NewsLetter LoadNewsFeeds(string after, int maxPosts, bool nieuwsbriefOnly)
        {
            var newsLetter = new NewsLetter();
            newsLetter.Organizations = LoadOrganizations();
            foreach(var organization in newsLetter.Organizations)
            {
                organization.After = after;
                organization.MaxPosts = maxPosts;
                loader.LoadFeed(organization, nieuwsbriefOnly);
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
            var newsLetter = LoadNewsFeeds(GetAfter(), Convert.ToInt32(MaxPosts.Value), true);
            var appconfig = GetAppConfig();

            List<AgendaEvent> agenda = new List<AgendaEvent>();
            agenda = GetAgenda();

            var options = new NewsReporterOptions();
            options.ForPrint = rbpaper.Checked;
            options.Config = GetAppConfig();
 
            options.IncludeNewsSummary = cbIncludeNewsSummary.Checked;
            options.IncludeNewsContent = cbIncludeNewsContent.Checked;
            options.PublicatieDatum = dpPublicatieDatum.Value;

            var html = reporter.GenerateNewsLetterReport(newsLetter, agenda, options);
            var reportPath = reporter.GetReportPath();
            File.WriteAllText(reportPath, html, Encoding.UTF8);

            DocPathValue.Text = reportPath;
            Process.Start(reportPath);
        }

        private string GetExeDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        private AppConfig GetAppConfig()
        {
            var path = Path.Combine(GetExeDir(), "appconfig.json");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<AppConfig>(json);
        }

        private List<Organization> LoadOrganizations()
        {
            var path = Path.Combine(GetExeDir(), "organizations.json");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Organization>>(json);
        }

    }
}
