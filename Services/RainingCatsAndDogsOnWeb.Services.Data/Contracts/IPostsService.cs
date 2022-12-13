namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task<T> GetAllPosts<T>();

        Task<T> GetById<T>(int id);

        Task<int> CreatePostAsync(string title, string content, int categoryId, string userId);
    }
}
