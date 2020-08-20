using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class NewsReporterOptions
    {
        public bool ForPrint { get; set; }
        public bool PrintLinks { get; set; }
        public bool IncludeNewsPublicationDate { get; set; }
        public bool IncludeAgenda { get; set; }
        public bool IncludeNewsContent { get; set; }
        public bool IncludeNewsSummary { get; set; }
        public bool AgendaVooraan { get; set; }
        public bool LargeFont { get; set; }
        public bool IncludeLogos { get; set; }
        public int LogoHeight { get; set; }
        public bool LogoAfterHeading { get; set; }
        public bool EventTitleBold { get; set; }
        public bool NewsTitleBold { get; set; }
        public bool OrganizationTitleBold { get; set; }
     
    }
}
