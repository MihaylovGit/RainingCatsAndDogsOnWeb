namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class SearchAdsService : ISearchAdsService
    {
        private readonly IDeletableEntityRepository<Ad> adsRepository;

        public SearchAdsService(IDeletableEntityRepository<Ad> adsRepository)
        {
            this.adsRepository = adsRepository;
        }

        public async Task<IEnumerable<AdsInListViewModel>> GetAllMatchedAds<T>(string searchString)
        {
            var allAds = await this.adsRepository.AllAsNoTracking()
                                                 .OrderByDescending(x => x.Id)
                                                 .To<AdsInListViewModel>()
                                                 .ToListAsync();

            var matchedAds = allAds.Where(x => x.Title.ToLower().Contains(searchString.ToLower()) ||
            x.Location.ToLower().Contains(searchString.ToLower()) || x.Description.ToLower().Contains(searchString.ToLower()))
                                .ToList();

            return matchedAds;
        }
    }
}
