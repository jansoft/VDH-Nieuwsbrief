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
        public DateTime PublicatieDatum { get; set; }
        public bool ForExternalMedia { get; set; }

        public bool HideCanceledEvents { get; set; }

        public string Thema { get; set; }

    }
}
