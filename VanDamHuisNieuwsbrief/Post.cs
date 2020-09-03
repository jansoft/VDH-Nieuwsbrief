using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class Post
    {
        public DateTime date { get; set; }

        public string status { get; set; }
        public string link { get; set; }

        public PostText title { get; set; }

        public PostText content { get; set; }

        public PostText excerpt { get; set; }

        public List<int> categories { get; set; } = new List<int>();

    }
}
