using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VanDamHuisNieuwsbriefGenerator
{
    public class FeedLoader
    {
        private WebClient jsonClient = new WebClient();

 

        public void LoadFeed(Organization organization, bool nieuwsbriefOnly)
        {
 
            var list = new List<NewsItem>();
            var categories = string.IsNullOrWhiteSpace(organization.Categories) || !nieuwsbriefOnly ? "" : "&categories=" + organization.Categories;
            var after = string.IsNullOrWhiteSpace(organization.After) ? "" : "&after=" + organization.After;

            var postsUrl = $"{organization.Url}/wp-json/wp/v2/posts?per_page={organization.MaxPosts}{after}{categories}";
            var json = jsonClient.DownloadString(postsUrl);

            var posts = JsonConvert.DeserializeObject<List<Post>>(json);

            foreach (var post in posts)
            {
                if (post.status == "publish")
                {

                    var newsItem = new NewsItem();
                    newsItem.Title = post.title.rendered;
                    newsItem.PublishDate = post.date;
                    newsItem.Content = CleanupJsonText(post.content.rendered);
                    newsItem.Summary = CleanupJsonText(post.excerpt.rendered);
                    newsItem.Url = post.link;
                    newsItem.Categories = post.categories;

                    list.Add(newsItem);
                }
            }
            organization.NewsItems = list;
        }


        private string CleanupJsonText(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                return "";
            }

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(RemoveShortCodes(html));
            var nodes = doc.DocumentNode.SelectNodes("//h1 | //h2 | //h3 | //h4 | //p | //img | //ul");

            var sbc = new StringBuilder();
            foreach (HtmlNode node in nodes)
            {
                if (node.Name == "img")
                {
                    // append only if not inside paragraph
                    if (node.Ancestors("p").ToList().Count == 0)
                    {
                        var fig = node.Ancestors("figure").FirstOrDefault();
                        if (fig != null && fig.HasClass("alignright"))
                        {
                            node.AddClass("alignright");
                        }

                        sbc.AppendLine(node.OuterHtml);
                    }
                }
                else
                {
                    sbc.AppendLine(node.OuterHtml);
                }
            }
            return sbc.ToString();

        }

        private string RemoveShortCodes(string html)
        {
            return Regex.Replace(html, @"\[[^\]]+]", "");
        }
    }
}
