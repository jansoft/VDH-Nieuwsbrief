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
            var filepath = @"d:\_Jan\Antroposofie\Website\vandamhuis.nl\events.csv";
            var reporter = new Reporter(filepath);
            var reportpath = reporter.GenerateReport();
            Console.WriteLine(reportpath);
            Console.ReadLine();
        }
    }
}
