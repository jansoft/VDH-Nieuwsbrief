using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class AppConfig
    {
        public string LinkColor { get; set; }
        public string TextColor { get; set; }
        public FontSizes DigitalFontSize { get; set; }
        public FontSizes PaperFontSize { get; set; }
        public int LogoHeight { get; set; }
        public bool EventTitleBold { get; set; }
        public bool NewsTitleBold { get; set; }
        public bool NewsTitleUnderline { get; set; }
        public bool NewsItemDivider { get; set; }
        public bool OrganizationTitleBold { get; set; }
        public bool AgendaLast { get; set; }
        public bool ShowOrganizationName { get; set; }
    }
}
