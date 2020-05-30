using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class AgendaEvent
    {
        public CsvAgendaEvent Event { get; set; }
        public string ReeksInfo { get; set; }

        public int Interval()
        {
            if (int.TryParse(Event.recurrence_interval, out int value)) {
                return value;
            }
            return 0;
        }

        public int ByWeekNo()
        {
            if (int.TryParse(Event.recurrence_byweekno, out int value))
            {
                return value;
            }
            return 0;
        }

        public List<int> ByDay()
        {
            var result = new List<int>();
            var terms = Event.recurrence_byday.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var term in terms)
            {
                if (int.TryParse(term, out int value))
                {
                    result.Add(value);
                }
            }
            return result;
        }
    }
}
