﻿using Newtonsoft.Json;
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
 
        private string GetAfter()
        {
            return DateFromPicker.Value.ToString("yyyy-MM-ddT00:00:00");
        }

        private int GetMaxPosts()
        {
            if (int.TryParse(tbMaxPosts.Text, out int max))
            {
                return max;
            }
            return 15;
        }

 
        private string Decode(string value)
        {
            return WebUtility.HtmlDecode(value);
        }

        private void GenerateHtml(object sender, EventArgs e)
        {
            var newsLetter = LoadNewsFeeds(GetAfter(), GetMaxPosts(), true);

            var html = reporter.GenerateNewsLetterReport(newsLetter, rbpaper.Checked);
            var reportPath = reporter.GetReportPath();
            File.WriteAllText(reportPath, html, Encoding.UTF8);

            DocPathValue.Text = reportPath;
            Process.Start(reportPath);
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
