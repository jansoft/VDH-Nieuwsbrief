using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisAgendaLogic
{
    public class JsonAgendaEvent
    {
        public int event_id { get; set; }
        public string event_name { get; set; }
        public DateTime event_start_date { get; set; }
        public DateTime event_end_date { get; set; }
        public DateTime event_start_time { get; set; }
        public DateTime event_end_time { get; set; }
        public string recurrence_id { get; set; }
        public string recurrence { get; set; }
        public string recurrence_interval { get; set; }
        public string recurrence_freq { get; set; }
        public string recurrence_byday { get; set; }
        public string recurrence_byweekno { get; set; }
        public string recurrence_days { get; set; }
        public string organisatie { get; set; }
        public string url { get; set; }
        public bool event_private { get; set; }
        public string event_status { get; set; }
        public string info { get; set; }
    }
}
