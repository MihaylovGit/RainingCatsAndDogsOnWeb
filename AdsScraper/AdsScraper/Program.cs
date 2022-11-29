using AngleSharp;
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

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            Parallel.For(1, 24, (i) =>
            {
                try
                {
                    GetAd(context, i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        public static void GetAd(IBrowsingContext context, int id)
        {
            var address = $"https://www.alo.bg/obiavi/domashni-lubimci/kucheta-prodava/r-{id}";
            var document = context.OpenAsync(address)
                                        .GetAwaiter()
                                        .GetResult();

            if (document.StatusCode == HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException();
            }

            var titleElements = document.GetElementsByClassName("listvip-item-title").Select(x => x.TextContent).ToList();
            var priceElements = document.GetElementsByClassName("nowrap").ToList().Select(x => x.TextContent).ToList();
            var locationElements = document.GetElementsByClassName("listvip-item-address").Select(x => x.TextContent).ToList();
            var descriptionElements = document.GetElementsByClassName("listvip-desc").Select(x => x.TextContent).ToList();
            List<Ad> ads = new List<Ad>();

            for (int i = 0; i < priceElements.Count; i++)
            {
                var currentAd = new Ad
                {
                    Title = titleElements[i],
                    Price = priceElements[i],
                    Location = locationElements[i],
                    Description = descriptionElements[i]
                };

                //Console.WriteLine(currentAd.Title);
                //Console.WriteLine(currentAd.Price);
                //Console.WriteLine(currentAd.Location);
                //Console.WriteLine(currentAd.Description);
                //Console.WriteLine("------------------------");

                ads.Add(currentAd);
            }

            Console.WriteLine(ads.Count);
        }
    }
}

