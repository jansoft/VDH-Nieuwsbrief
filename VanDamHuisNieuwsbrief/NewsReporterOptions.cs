using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public enum BodyFontSize { Small, Medium, Large}
    public class NewsReporterOptions
    {
        public bool ForPrint { get; set; }
        public bool IncludeAgenda { get; set; }
        public bool IncludeNewsContent { get; set; }
        public bool IncludeNewsSummary { get; set; }
        public bool AgendaVooraan { get; set; }
        public BodyFontSize FontSize { get; set; }
        public string FontColor { get; set; }
        public string LinkColor { get; set; }
        public int LogoHeight { get; set; }
        public bool LogoAfterHeading { get; set; }
        public bool EventTitleBold { get; set; }
        public bool NewsTitleBold { get; set; }
        public bool OrganizationTitleBold { get; set; }
        public DateTime PublicatieDatum { get; set; }

     
    }
}
