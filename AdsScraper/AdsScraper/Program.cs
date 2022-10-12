using AngleSharp;
using AngleSharp.Dom;
using System.Text;

namespace AdsScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            GetAd(context, 1, 2);
            //Parallel.For(1, 24, (i) =>
            //{
            //    try
            //    {
            //        var ad = GetAd(i)
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}
        }

        private static List<Ad> GetAd(IBrowsingContext context, int id, int limit)
        {
            var address = $"https://www.alo.bg/obiavi/domashni-lubimci/kucheta-prodava/r-{id}";
            var document = context.OpenAsync(address)
                .GetAwaiter()
                .GetResult();

            var ads = new List<Ad>();

            while (id <= limit)
            {
                if (document.StatusCode == System.Net.HttpStatusCode.NotFound || document.GetElementsByTagName("h1")[0].TextContent.Contains("404 Not Found"))
                {
                    throw new InvalidOperationException();
                }

                var items = document.GetElementsByClassName("listvip-item-content")
                    .Select(x => x.TextContent).ToList();

                foreach (var item in items)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------");
                }
               

                return ads;
                //var titleElements = document.GetElementsByClassName("listvip-item-title").Select(x => x.TextContent).ToList();
                //var priceElements = document.GetElementsByClassName("nowrap").ToList().Select(x => x.TextContent).ToList();
                //var locationElements = document.GetElementsByClassName("listvip-item-address").Select(x => x.TextContent).ToList();
                //var descriptionElements = document.GetElementsByClassName("listvip-desc").Select(x => x.TextContent).ToList();

                
            }

            Console.WriteLine(ads.Count);
            return ads;
        }
    }
}
