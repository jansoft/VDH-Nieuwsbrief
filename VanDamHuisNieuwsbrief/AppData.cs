using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class AppData
    {
        public DateTime NieuwsbriefVanaf { get; set; }
        public DateTime AgendaVanaf { get; set; }

        public DateTime AgendaTot { get; set; }

        public DateTime PublicatieDatum { get; set; }

        public bool ForPaper { get; set; }

        public bool ForMedia { get; set; }

        public string Thema { get; set; }

    }
}
