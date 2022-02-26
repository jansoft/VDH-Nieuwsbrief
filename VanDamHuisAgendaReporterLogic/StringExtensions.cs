using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisAgendaLogic
{
    public static class StringExtensions
    {
        public static string RemoveTrailingCharacter(this string value, string trailingCharacter)
        {
            if (value.EndsWith(trailingCharacter))
            {
                return value.Remove(value.Length - 1);
            }
            else
            {
                return value;
            }
        }
    }
}
