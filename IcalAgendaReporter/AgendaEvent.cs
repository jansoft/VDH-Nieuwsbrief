using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class AgendaEvent
    {
        public string event_name { get; set; }
        public DateTime event_start_date { get; set; }
        public DateTime event_end_date { get; set; }
        public DateTime event_start_time { get; set; }
        public DateTime event_end_time { get; set; }
        public string organisatie { get; set; }
        public string url { get; set; }
        public string reeks { get; set; }

        public bool event_private { get; set; }
    }
}
