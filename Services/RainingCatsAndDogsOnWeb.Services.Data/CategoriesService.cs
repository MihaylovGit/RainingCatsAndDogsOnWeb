namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
           return this.categoriesRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAllCategories<T>()
        {
            return this.categoriesRepository.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
          var category = this.categoriesRepository.All()
                                                  .Where(x => x.Name == name)
                                                  .To<T>()
                                                  .FirstOrDefault();

            return category;
        }
    }
}
