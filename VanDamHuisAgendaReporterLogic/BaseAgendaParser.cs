using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class BaseAgendaParser
    {
        private readonly Dictionary<string, AgendaEvent> allReeksen = new Dictionary<string, AgendaEvent>();

        protected List<AgendaEvent> GetFutureEvents(List<AgendaEvent> records, bool includePrivate, DateTime from, DateTime until)
        {
            if (includePrivate)
            {
                return records.Where(p => p.Event.recurrence != "1" && p.Event.event_start_date >= from.Date && p.Event.event_start_date < until).OrderBy(p => p.Event.event_start_date).ToList();
            }
            else
            {
                return records.Where(p => p.Event.recurrence != "1" && p.Event.event_start_date >= from.Date && p.Event.event_start_date < until && !p.Event.event_private).OrderBy(p => p.Event.event_start_date).ToList();
            }
        }
        /// <summary>
        /// Extracts all RecurrenceEvents
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        protected List<AgendaEvent> ParseReeksen(List<AgendaEvent> events)
        {
            var result = new List<AgendaEvent>();
            foreach (var item in events)
            {
                if (item.Event.recurrence == "1")
                {
                    allReeksen[item.Event.event_id.ToString()] = item;
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }

        protected List<AgendaEvent> ReduceRepeatingEvents(List<AgendaEvent> records)
        {
            var reeksen = new Dictionary<string, bool>();
            var result = new List<AgendaEvent>();

            foreach (var record in records)
            {
                var reeks = record.Event.recurrence_id;//  .reeks;
                if (string.IsNullOrWhiteSpace(reeks))
                {
                    result.Add(record);
                }
                else
                {
                    if (!reeksen.ContainsKey(reeks))
                    {
                        reeksen[reeks] = true;
                        var reeksEvent = allReeksen.ContainsKey(reeks) ? allReeksen[reeks] : null;
                        if (reeksEvent == null && !record.Event.event_private)
                        {
                            result.Add(record);
                        }
                        else if (!reeksEvent.Event.event_private)
                        {
                            record.ReeksInfo = GetReeksInfo(reeksEvent);
                            result.Add(record);
                        }
                    }
                }
            }

            return result;
        }

        public string GetReeksInfo(AgendaEvent item)
        {
            var freq = item.Event.recurrence_freq;
            var interval = item.Interval();
            var byweekno = item.ByWeekNo();
            var byday = item.ByDay();

            if (freq == "weekly")
            {
                return $"(wekelijks op {GetDayNames(byday)} tot {item.Event.event_end_date:dd MMMM yyyy})";
            }
            else if (freq == "monthly")
            {
                if (byweekno != 0)
                {
                    return $"(elke {GetSequenceName(byweekno)} {GetDayNames(byday)} van de maand tot {item.Event.event_end_date:dd MMMM yyyy})";
                }
                return "Elke maand";
            }
            return "TODO";
        }

        private string GetDayName(int day)
        {
            switch (day)
            {
                case 0: return "zondag";
                case 1: return "maandag";
                case 2: return "dinsdag";
                case 3: return "woensdag";
                case 4: return "donderdag";
                case 5: return "vrijdag";
                case 6: return "zaterdag";
                default: return "onbekende dag";
            }
        }

        private string GetDayNames(List<int> daynames)
        {
            var result = new List<string>();
            foreach (var day in daynames)
            {
                result.Add(GetDayName(day));
            }

            return string.Join(", ", result);
        }

        private string GetSequenceName(int sequence)
        {
            switch (sequence)
            {
                case 1: return "eerste";
                case 2: return "tweede";
                case 3: return "derde";
                case 4: return "vierde";
                case 5: return "vijfde";
                default: return "onbekende volgorde";
            }
        }
    }
}
