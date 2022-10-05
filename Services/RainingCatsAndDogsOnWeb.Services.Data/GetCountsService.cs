namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Linq;

    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Models;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Ad> adsRepository;

        public GetCountsService(IDeletableEntityRepository<Category> categoriesRepository, IDeletableEntityRepository<Ad> adsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.adsRepository = adsRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto()
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                AdsCount = this.adsRepository.All().Count(),
            };

            return data;
        }
    }
}
