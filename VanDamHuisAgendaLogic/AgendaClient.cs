using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisAgendaLogic
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


        public List<AgendaEvent> GetEventsForReporting(AgendaEventParserOptions options)
        {
            var parsedEvents = FetchEvents();
            var futureEvents = GetFutureEvents(parsedEvents, options);
            //var event166 = futureEvents.FirstOrDefault(p => p.Event.event_id == 166);
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

            var event166 = result.FirstOrDefault(p => p.Event.event_id == 166);

            return ParseReeksen(result);
        }

        public List<JsonAgendaEvent> GetRemoteEvents()
        {
            var client = new HttpClient();
            var json = client.GetStringAsync(url).Result;

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new BooleanConverter());
            return JsonConvert.DeserializeObject<List<JsonAgendaEvent>>(json, settings);
        }

    }
}
