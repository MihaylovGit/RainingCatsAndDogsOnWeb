namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Update;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdsService : IAdsService
    {
        private readonly IDeletableEntityRepository<Ad> adsRepository;
        private readonly string[] allowedExtensions = new string[] { "jpg", "png", "jpeg", "gif" };

        public AdsService(IDeletableEntityRepository<Ad> adsRepository)
        {
            this.adsRepository = adsRepository;
        }

        // IF I Have enough time to make CreateAsync<T>
        public async Task CreateAsync(CreateAdViewModel input, string userId, string imagePath)
        {
            var newAd = new Ad
            {
                Title = input.Title,
                Location = input.Location,
                Price = input.Price,
                Description = input.Description,
                CategoryId = input.CategoryId,
                Category = input.Category,
                AddedByUserId = userId,
            };

            // /wwwroot/images/ads/gjgjk-gfkf34556-=g4565.jpeg
            Directory.CreateDirectory($"{imagePath}/ads/");

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };

                var physicalPath = $"/{imagePath}/ads/{dbImage.Id}.{extension}";

                newAd.Images.Add(dbImage);

                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.adsRepository.AddAsync(newAd);
            await this.adsRepository.SaveChangesAsync();
        }

        public T DetailsById<T>(int id)
        {
            var ad = this.adsRepository.AllAsNoTracking().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return ad;
        }



        public int GetAdsCount()
        {
            return this.adsRepository.All().Count();
        }

        public IEnumerable<T> GetAllAds<T>(int pageNumber, int adsPerPage)
        {
            var allAds = this.adsRepository.AllAsNoTracking()
                                           .OrderByDescending(x => x.Id)
                                           .Skip((pageNumber - 1) * adsPerPage)
                                           .To<T>()
                                           .ToList();

            return allAds;
        }

        public async Task<IEnumerable<T>> GetRandom<T>(int count)
        {
            return await this.adsRepository.All()
                               .OrderBy(x => x.Id)
                               .Take(count)
                               .To<T>().ToListAsync();
        }

        public IEnumerable<T> GetUserAds<T>(string userId)
        {
            var userAds = this.adsRepository.AllAsNoTracking()
                                            .OrderByDescending(x => x.AddedByUserId)
                                            .To<T>()
                                            .ToList();

            return userAds;
        }

        public int GetUserAdsCount(string userId)
        {
            int userAdsCount = this.adsRepository.AllAsNoTracking()
                              .Where(x => x.AddedByUserId == userId).Count();

            return userAdsCount;
        }

        public async Task UpdateAsync(int id, EditAdViewModel model)
        {
            var ad = await this.adsRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            ad.Title = model.Title;
            ad.Location = model.Location;
            ad.Description = model.Description;
            ad.Price = model.Price;
            ad.CategoryId = model.CategoryId;
            ad.Category = model.Category;

            await this.adsRepository.SaveChangesAsync();
        }
    }
}
