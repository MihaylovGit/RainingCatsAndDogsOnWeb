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

    public class SearchAdsService : ISearchAdsService
    {
        private readonly IDeletableEntityRepository<Ad> adsRepository;

        public SearchAdsService(IDeletableEntityRepository<Ad> adsRepository)
        {
            this.adsRepository = adsRepository;
        }

        public async Task<IEnumerable<T>> GetAllAds<T>()
        {
            var allAds = await this.adsRepository.AllAsNoTracking()
                                       .OrderByDescending(x => x.Id)
                                       .To<T>()
                                       .ToListAsync();

            return allAds;
        }
    }
}
