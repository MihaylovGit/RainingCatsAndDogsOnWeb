namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<T> GetById<T>(int id);

        Task<int> CreatePost(string title, string content, int categoryId, string userId);
    }
}
