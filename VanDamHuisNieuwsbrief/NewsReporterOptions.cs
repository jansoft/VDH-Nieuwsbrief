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
        public DateTime PublicatieDatum { get; set; }

        public AppConfig Config { get; set; }

     
    }
}
