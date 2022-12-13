namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Posts;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<T> GetById<T>(int id);

        Task<int> CreatePostAsync(string title, string content, int categoryId, string userId);
    }
}
