namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;

    public class AdsService : IAdsService
    {
        private readonly IDeletableEntityRepository<Ad> adsRepository;

        public AdsService(IDeletableEntityRepository<Ad> adsRepository)
        {
            this.adsRepository = adsRepository;
        }

        public async Task CreateAsync(CreateAdViewModel input, string userId)
        {
            var newAd = new Ad
            {
                Title = input.Title,
                Location = input.Location,
                Price = input.Price,
                Description = input.Description,
                CategoryId = input.CategoryId,
                AddedByUserId = userId,
            };

            await this.adsRepository.AddAsync(newAd);

            await this.adsRepository.SaveChangesAsync();
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
    }
}
