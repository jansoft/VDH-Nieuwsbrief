using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisAgendaLogic
{
    public class ReporterOptions
    {
        public bool ShowBackground { get; set; }
        public bool PrivateEventsIncluded { get; set; }
        public bool PublicEventsIncluded { get; set; }
        public int MaxEvents { get; set; }
        public bool AllEvents { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateUntil { get; set; }
         public bool IncludeQRCodes { get; set; }
    }
}
