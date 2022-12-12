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

    public class SearchBlogPostsService : ISearchBlogPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public SearchBlogPostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task<IEnumerable<T>> GetAllPosts<T>()
        {
            var allPosts = await this.postsRepository.AllAsNoTracking()
                                       .OrderByDescending(x => x.Id)
                                       .To<T>()
                                       .ToListAsync();

            return allPosts;
        }
    }
}



