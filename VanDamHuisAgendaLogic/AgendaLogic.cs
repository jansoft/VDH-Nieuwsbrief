using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisAgendaLogic
{
    public class AgendaLogic
    {
        public List<AgendaEvent> GetEventsForReporting(AgendaEventParserOptions options)
        {
            var bop = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
            var eop = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            var url = "https://www.vandamhuis.nl/wp-json/vdh/agenda?bop=" + bop + "&eop=" + eop;
            var client = new AgendaClient(url, options);
            return client.GetEventsForReporting(options);
        }

        public List<AgendaEvent> FetchEvents(AgendaEventParserOptions options)
        {
            var bop = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
            var eop = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            var url = "https://www.vandamhuis.nl/wp-json/vdh/agenda?bop=" + bop + "&eop=" + eop;
            var client = new AgendaClient(url, options);
            return client.FetchEvents();
        }
    }
}
