﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcalAgendaReporter
{
    public class AgendaEventParserOptions
    {
        public EventScope Scope { get; set; } = EventScope.Public;
        public bool IncludeRepeating { get; set; } = false;

        public DateTime Until { get; set; }
    }
}
