using VanDamHuisAgendaLogic;
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
            var agendaLogic = new AgendaLogic();
            var parserOptions = new AgendaEventParserOptions();
            parserOptions.From = dpFrom.Value;
            parserOptions.Until = dpUntil.Value;
            parserOptions.IncludePrivate = cbPrivate.Checked;
            parserOptions.IncludePublic = cbPublic.Checked;

            if (!parserOptions.IncludePrivate && ! parserOptions.IncludePublic)
            {
                MessageBox.Show("Kies privé of openbare evenementen opnemen of beide", "Maak uw keuze");
                return;
            }

            var eventsToPreport = agendaLogic.GetEventsForReporting(parserOptions);

            var reporterLogic = new ReporterLogic();
            var reportOptions = new ReporterOptions();
            reportOptions.ShowBackground = cbShowBackground.Checked;
            reportOptions.PrivateEventsIncluded = cbPrivate.Checked;
            reportOptions.PublicEventsIncluded = cbPublic.Checked;
            reportOptions.MaxEvents = Convert.ToInt32(udMaxEvents.Value);
            reportOptions.AllEvents = cbAllEvents.Checked;
            reportOptions.DateFrom = dpFrom.Value;
            reportOptions.DateUntil = dpUntil.Value;
            var reportPath = reporterLogic.ReportEvents(eventsToPreport, reportOptions);
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
    }
}
