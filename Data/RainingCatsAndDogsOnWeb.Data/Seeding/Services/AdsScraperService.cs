namespace RainingCatsAndDogsOnWeb.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using AngleSharp;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;

    public class AdsScraperService : IAdsScraperService
    {
        private readonly IBrowsingContext context;

        public AdsScraperService(IBrowsingContext context)
        {
            this.context = context;
        }

        public List<Ad> GetData(IBrowsingContext context, int id)
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

            var ads = new List<Ad>();

            for (int i = 0; i < priceElements.Count; i++)
            {
                if (titleElements[i] == null || priceElements[i] == null || locationElements[i] == null || descriptionElements[i] == null)
                {
                    continue;
                }

                var currentAd = new Ad
                {
                    Title = titleElements[i],
                    Price = decimal.Parse(priceElements[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ElementAt(0)),
                    Location = locationElements[i],
                    Description = descriptionElements[i],
                };

                ads.Add(currentAd);
            }

            return ads;
        }
    }
}
