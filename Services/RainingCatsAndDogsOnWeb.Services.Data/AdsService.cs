namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Data.Repositories;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
  
    public class AdsService : IAdsService
    {
        private readonly EfDeletableEntityRepository<Ad> adsRepository;

        public AdsService(EfDeletableEntityRepository<Ad> adsRepository)
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

        // TODO: Replace applicationdbcontext with repository

        public IEnumerable<DogAdsInListViewModel> GetAllDogAds(int pageNumber, int adsPerPage = 12)
        {
           var dogAds = this.adsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((pageNumber - 1) * adsPerPage)
                .Take(adsPerPage)
                .Select(x => new DogAdsInListViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Location = x.Location,
                    Price = x.Price,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    Category = x.Category.Name,
                    ImageUrl = x.Images.FirstOrDefault().ToString(),
                }).ToList();

            return dogAds;
        }
    }
}
