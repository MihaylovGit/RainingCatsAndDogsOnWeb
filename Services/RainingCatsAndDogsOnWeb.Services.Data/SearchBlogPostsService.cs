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
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Categories;

    public class SearchBlogPostsService : ISearchBlogPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public SearchBlogPostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task<IEnumerable<PostInCategoryViewModel>> GetAllMatchedPosts<T>(string searchString)
        {
            var allPosts = await this.postsRepository.AllAsNoTracking()
                                                     .OrderByDescending(x => x.Id)
                                                     .To<PostInCategoryViewModel>()
                                                     .ToListAsync();

            var matchedPosts = allPosts.Where(x => x.Title.ToLower()
                                       .Contains(searchString.ToLower()) || x.Content.ToLower().Contains(searchString.ToLower()))
                                       .ToList();

            return matchedPosts;
        }
    }
}



