namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<IEnumerable<int>> GetAllPostsIds();

        Task<T> GetById<T>(int id);

        Task<int> CreatePostAsync(string title, string content, int categoryId, string userId);
    }
}
