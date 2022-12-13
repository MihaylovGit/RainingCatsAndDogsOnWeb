namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int postId, string userId, string content, int? parentId = null);

        Task<bool> IsInPostId(int commentId, int postId);
    }
}
