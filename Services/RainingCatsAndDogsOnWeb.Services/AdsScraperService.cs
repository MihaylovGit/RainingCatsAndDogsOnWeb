﻿namespace RainingCatsAndDogsOnWeb.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using AngleSharp;
    using AngleSharp.Dom;
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

            List<Ad> ads = new List<Ad>();
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
                        OriginalUrl = "alo.bg/" + dogImages[j],
                        CategoryId = 2,
                    };

                    var image = new Image
                    {
                        RemoteImageUrl = currentAd.OriginalUrl,
                        Extension = dogImages[j].Split('.', StringSplitOptions.RemoveEmptyEntries)[1],
                        AdId = currentAd.Id,
                    };

                    await this.adsRepository.AddAsync(currentAd);
                    await this.imagesRepository.AddAsync(image);

                    await this.adsRepository.SaveChangesAsync();
                    await this.imagesRepository.SaveChangesAsync();
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
                        OriginalUrl = "alo.bg/" + catImages[h],
                        CategoryId = 1,
                    };

                    var image = new Image
                    {
                        RemoteImageUrl = currentAd.OriginalUrl,
                        Extension = catImages[h].Split('.', StringSplitOptions.RemoveEmptyEntries)[1],
                        AdId = currentAd.Id,
                    };

                    await this.adsRepository.AddAsync(currentAd);
                    await this.imagesRepository.AddAsync(image);

                    await this.adsRepository.SaveChangesAsync();
                    await this.imagesRepository.SaveChangesAsync();
                }
            }
        }
    }
}
