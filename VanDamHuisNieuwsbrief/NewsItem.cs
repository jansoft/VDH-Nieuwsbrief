using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string Url { get; set; }

        public List<int> Categories { get; set; } = new List<int>();

        public bool HasCategory(int categorie)
        {
            return Categories.Contains(categorie);
        }

    }
}
