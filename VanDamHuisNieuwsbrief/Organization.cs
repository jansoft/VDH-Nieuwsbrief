﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class Organization
    {
        public string Name { get; set; }
        public List<NewsItem> NewsItems { get; set; } = new List<NewsItem>();
        public string Color { get; set; }
        public string Url { get; set; }
        public string After { get; set; } = "";
        public int MaxPosts { get; set; } = 15;
        public string Categories { get; set; } = "";


    }
}