namespace WebScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var scraper = new FastWebScraper();

           var ads = scraper.GetAds();
            Console.WriteLine($"Total number of ads: {ads.Count}");
        }
    }
}