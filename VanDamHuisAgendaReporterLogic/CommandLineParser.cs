using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisAgendaLogic
{
    public static class CommandLineParser
    {
        public static Dictionary<string, string> GetCommands(string[] args)
        {
            var result = new Dictionary<string, string>();

            foreach(var arg in args)
            {
                if (!string.IsNullOrWhiteSpace(arg)) {

                    var terms = arg.Trim().Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (terms.Length == 2)
                    {
                        result[terms[0]] = terms[1];
                    }
                }
            }

            return result;
        }
    }
}
