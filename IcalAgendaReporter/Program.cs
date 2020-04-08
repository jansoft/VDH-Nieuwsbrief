using Ical.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var icalText = File.ReadAllText(@"d:\_Jan\Antroposofie\Website\vandamhuis.nl\events.ics");
            var calendar = Calendar.Load(icalText);
            var events = calendar.Events.Count;
        }
    }
}
