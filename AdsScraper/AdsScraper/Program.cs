using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Net;
using System.Text;

namespace AdsScraper
{
    public class Program
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;

        public Program(IConfiguration config, IBrowsingContext context)
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
        }

        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Ad> ads = new List<Ad>();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            for (int i = 1; i < 24; i++)
            {
                var firstAddress = $"https://www.alo.bg/obiavi/domashni-lubimci/kucheta-prodava/?page={i}";
                var secondAddress = $"https://www.alo.bg/obiavi/domashni-lubimci/kotki-prodava/?page={i}";

                var document = await context.OpenAsync(firstAddress);

                if (document.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new InvalidOperationException();
                }

                var titleElements = document.GetElementsByClassName("listvip-item-title").Select(x => x.TextContent).ToList();
                var priceElements = document.GetElementsByClassName("nowrap").ToList().Select(x => x.TextContent).ToList();
                var locationElements = document.GetElementsByClassName("listvip-item-address").Select(x => x.TextContent).ToList();
                var descriptionElements = document.GetElementsByClassName("listvip-desc").Select(x => x.TextContent).ToList();
                var dogImages = document.GetElementsByClassName("listvip-image-img ").Attr("src").ToList();

                for (int j = 0; j < priceElements.Count; j++)
                {
                    var currentAd = new Ad
                    {
                        Title = titleElements[j],
                        Price = priceElements[j],
                        Location = locationElements[j],
                        Description = descriptionElements[j],
                        OriginalUrl = "alo.bg" + dogImages[j],
                    };

                    Console.WriteLine(currentAd.Title);
                    Console.WriteLine(currentAd.Price);
                    Console.WriteLine(currentAd.Location);
                    Console.WriteLine(currentAd.Description);
                    Console.WriteLine(currentAd.OriginalUrl);
                    Console.WriteLine("------------------------");

                    ads.Add(currentAd);
                }
            }

            for (int k = 1; k < 4; k++)
            {
                var address = $"https://www.alo.bg/obiavi/domashni-lubimci/kotki-prodava/?page={k}";

                var document = await context.OpenAsync(address);


                if (document.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new InvalidOperationException();
                }

                var titleElements = document.GetElementsByClassName("listvip-item-title").Select(x => x.TextContent).ToList();
                var priceElements = document.GetElementsByClassName("nowrap").ToList().Select(x => x.TextContent).ToList();
                var locationElements = document.GetElementsByClassName("listvip-item-address").Select(x => x.TextContent).ToList();
                var descriptionElements = document.GetElementsByClassName("listvip-desc").Select(x => x.TextContent).ToList();
                var catImages = document.GetElementsByClassName("listvip-image-img ").Attr("src").ToList();

                for (int h = 0; h < priceElements.Count; h++)
                {
                    var currentAd = new Ad
                    {
                        Title = titleElements[h],
                        Price = priceElements[h],
                        Location = locationElements[h],
                        Description = descriptionElements[h],
                        OriginalUrl = "alo.bg" + catImages[h],
                    };

                    Console.WriteLine(currentAd.Title);
                    Console.WriteLine(currentAd.Price);
                    Console.WriteLine(currentAd.Location);
                    Console.WriteLine(currentAd.Description);
                    Console.WriteLine(currentAd.OriginalUrl);
                    Console.WriteLine("------------------------");

                    ads.Add(currentAd);
                }
            }

            Console.WriteLine(ads.Count);
        }
    }
}


