using IcalAgendaReporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanDamHuisAgendaReporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void InitializeApp()
        {
            dpFrom.Value = DateTime.Now;
            dpUntil.Value = DateTime.Now.AddDays(6 * 7);
        }

        private void btGenerateReport_Click(object sender, EventArgs e)
        {
            var logic = new Logic();
            var parserOptions = new AgendaEventParserOptions();
            parserOptions.From = dpFrom.Value;
            parserOptions.Until = dpUntil.Value;
            var eventsToPreport = logic.GetEventsForReporting(parserOptions);

            var reportPath = logic.ReportEvents(eventsToPreport, false);
            LocationLabel.Text = reportPath;

            Process.Start(reportPath);
        }

        private void btOpenLocation_Click(object sender, EventArgs e)
        {
            var path = LocationLabel.Text;
            if (File.Exists(path))
            {
                string argument = "/select, \"" + path + "\"";
                Process.Start("explorer.exe", argument);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var logic = new Logic();
            var parserOptions = new AgendaEventParserOptions();
            parserOptions.From = dpFrom.Value;
            parserOptions.Until = dpUntil.Value;
            var eventsToReport = logic.FetchEvents(parserOptions);
            var reeksItem = logic.GetEvensInReeks(eventsToReport, "meerlucht");
        }
    }
}
