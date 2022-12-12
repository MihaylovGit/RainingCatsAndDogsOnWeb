namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> CreatePost(string title, string content, int categoryId, string userId);
    }
}
