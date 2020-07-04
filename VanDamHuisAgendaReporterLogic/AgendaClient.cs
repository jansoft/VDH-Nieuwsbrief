using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class AgendaClient : BaseAgendaParser
    {
        private readonly string url;
        
        private readonly AgendaEventParserOptions options;

        public AgendaClient(string url, AgendaEventParserOptions options)
        {
            this.url = url;
            this.options = options;
        }


        public List<AgendaEvent> GetEventsForReporting()
        {
            var parsedEvents = FetchEvents();

             var futureEvents = GetFutureEvents(parsedEvents, options.IncludePrivate, options.From, options.Until);
            return ReduceRepeatingEvents(futureEvents);

        }

 

        public List<AgendaEvent> FetchEvents()
        {
            var result = new List<AgendaEvent>();
            var remoteEvents = GetRemoteEvents();
            foreach (var item in remoteEvents)
            {
                if (!string.IsNullOrWhiteSpace(item.event_status) && item.event_status != "0")
                {
                    result.Add(new AgendaEvent { Event = item });
                }
            }

            return ParseReeksen(result);
        }

        public List<CsvAgendaEvent> GetRemoteEvents()
        {
            var client = new HttpClient();
            var json = client.GetStringAsync(url).Result;

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new BooleanConverter());
            return JsonConvert.DeserializeObject<List<CsvAgendaEvent>>(json, settings);
        }

    }
}
