using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    public class FastWebScraper
    {
        private const string _url = "https://www.alo.bg/obiavi/domashni-lubimci/kucheta-prodava/";
        public List<Ad> GetAds(string url = _url)
        {
            var uri = new Uri(url);
            List<Ad> ads = new List<Ad>();

            HtmlWeb web = new HtmlWeb();

            HtmlNode nextButton = null;

            do
            {
                var doc = web.Load(url);

                var elements = doc.DocumentNode.SelectNodes("div");
                foreach (var node in elements)
                {
                    var ad = new Ad
                    {
                        Title = node.SelectSingleNode("/[id=title]/div/h1").InnerText,
                        Price = node.SelectSingleNode("/[id=allparams]/div[1]/div[2]/div[2]").InnerText,
                        Location = node.SelectSingleNode("/[id=allparams]/div[1]/div[3]/div[2]").InnerText,
                        Description = node.SelectSingleNode("/[id=main_content]/div[4]/div/div/div[6]/div[1]/div/p").InnerText,
                    };

                    ads.Add(ad);
                }
                nextButton = doc.DocumentNode.SelectSingleNode("/[id=listing-table]/div[2]/nav/div[1]/div[1]/a[2]");
                url = uri.Scheme + "://" + uri.Authority + nextButton.GetAttributeValue<string>("href", null);
            } while (!nextButton.GetAttributeValue<string>("class", null).Contains("disabled"));

            return ads;
        }
    }
}
