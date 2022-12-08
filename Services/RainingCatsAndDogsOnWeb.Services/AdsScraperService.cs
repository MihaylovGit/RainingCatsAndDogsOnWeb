namespace RainingCatsAndDogsOnWeb.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using AngleSharp;
    using AngleSharp.Common;
    using AngleSharp.Dom;
    using AngleSharp.Html.Dom;
    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;

    public class AdsScraperService : IAdsScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        private readonly IDeletableEntityRepository<Ad> adsRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public AdsScraperService(IDeletableEntityRepository<Ad> adsRepository, IDeletableEntityRepository<Image> imagesRepository)
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
            this.adsRepository = adsRepository;
            this.imagesRepository = imagesRepository;
        }

        public async Task PopulateDbWithAds(int count)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            List<Image> images = new List<Image>();

            for (int i = 1; i < count; i++)
            {
                var address = $"https://www.alo.bg/obiavi/domashni-lubimci/kucheta-prodava/?page={i}";

                var document = await context.OpenAsync(address);

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
                        Description = descriptionElements[j] ?? titleElements[j],
                        OriginalUrl = "https://alo.bg/" + dogImages[j],
                        CategoryId = 2,
                    };

                    await this.adsRepository.AddAsync(currentAd);

                    await this.adsRepository.SaveChangesAsync();
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
                        Description = descriptionElements[h] ?? titleElements[h],
                        OriginalUrl = "https://alo.bg/" + catImages[h],
                        CategoryId = 1,
                    };

                    await this.adsRepository.AddAsync(currentAd);

                    await this.adsRepository.SaveChangesAsync();
                }

                var allAds = await this.adsRepository.All().ToListAsync();
                foreach (var ad in allAds)
                {
                    var originalUrlSplitted = ad.OriginalUrl.Split('.').ToArray();
                    var image = new Image
                    {
                        RemoteImageUrl = ad.OriginalUrl,
                        Extension = originalUrlSplitted[2],
                        AdId = ad.Id,
                    };

                    await this.imagesRepository.AddAsync(image);

                    await this.imagesRepository.SaveChangesAsync();
                }
            }
        }
    }
}
