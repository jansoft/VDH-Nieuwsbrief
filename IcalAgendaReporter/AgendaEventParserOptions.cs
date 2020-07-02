using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class AgendaEventParserOptions
    {
        public bool IncludePrivate { get; set; }
 
        public DateTime From { get; set; }
        public DateTime Until { get; set; }

    }
}
