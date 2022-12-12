namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchBlogPostsService
    {
        public Task<IEnumerable<T>> GetAllPosts<T>();
    }
}
