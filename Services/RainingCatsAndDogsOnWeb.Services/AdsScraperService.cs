namespace RainingCatsAndDogsOnWeb.Services
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AngleSharp;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;

    public class AdsScraperService : IAdsScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        private readonly IDeletableEntityRepository<Ad> adsRepository;

        public AdsScraperService(IDeletableEntityRepository<Ad> adsRepository)
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
            this.adsRepository = adsRepository;
        }
        
        public void PopulateDbWithAds()
        {
            Parallel.For(1, 20, (i) =>
            {
                try
                {
                    GetAd(this.context, i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        private void GetAd(IBrowsingContext context, int id)
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
            var userElements = document.GetElementsByClassName("listvip-publisher").Select(x => x.TextContent).ToList();

            for (int i = 0; i < priceElements.Count; i++)
            {
                var currentAd = new Ad
                {
                    Title = titleElements[i],
                    Price = decimal.Parse(priceElements[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ElementAt(0)),
                    Location = locationElements[i],
                    Description = descriptionElements[i],
                };

                this.adsRepository.AddAsync(currentAd);
            }

            this.adsRepository.SaveChangesAsync();
        }
    }
}
