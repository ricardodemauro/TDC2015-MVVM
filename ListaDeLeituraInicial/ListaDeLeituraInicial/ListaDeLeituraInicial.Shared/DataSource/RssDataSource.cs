using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;
using ListaDeLeituraInicial.Model;

namespace ListaDeLeituraInicial.DataSource
{
    public static class RssDataSource
    {
        private static string NewsPageUrl = "http://rss.cnn.com/rss/edition.rss";

        public static async Task<IList<RssArticle>> GetArticles()
        {
            var feed = await GetRssFeed(NewsPageUrl);

            var reader = new StringReader(feed);
            var document = XDocument.Load(reader);

            XNamespace dcM = "http://search.yahoo.com/mrss/";

            // Assume that feed is always well formed

            var list = document
                .Element("rss")
                .Element("channel")
                .Descendants("item")
                .Select(
                    itemXml => new RssArticle
                    {
                        Link = new Uri(itemXml.Element("link").Value),
                        Titulo = itemXml.Element("title").Value,
                        Descricao = itemXml.Element("description").Value,
                        DataPublicacao = ConvertPubDate(itemXml.Element("pubDate").Value)
                    })
                .Take(3).ToList();

            return list;
        }

        private static DateTime ConvertPubDate(string pubDate)
        {
            //Sat, 02 May 2015 21:18:52 EDT
            DateTime pubDateConvert = DateTime.Now;
            if (DateTime.TryParseExact(pubDate.Remove(25, pubDate.Length - 25), "ddd, dd MMM yyyy HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out pubDateConvert))
            {
                return pubDateConvert;
            }
            return DateTime.MinValue;
        }

        private static async Task<string> GetRssFeed(string feedUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create(feedUrl);
            request.Method = "GET";

            var response = (HttpWebResponse)await request.GetResponseAsync();
            var stream = new StreamReader(response.GetResponseStream());
            var result = stream.ReadToEnd();
            return result;
        }
    }
}
