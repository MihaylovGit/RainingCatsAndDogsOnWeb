namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task<int> CreatePost(string title, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                UserId = userId,
            };

            await this.postsRepository.AddAsync(post);

            await this.postsRepository.SaveChangesAsync();

            return post.Id;
        }

        public async Task<T> GetById<T>(int id)
        {
           var post = await this.postsRepository.All()
                                .Where(x => x.Id == id)
                                .To<T>()
                                .FirstOrDefaultAsync();

            return post;
        }
    }
}
