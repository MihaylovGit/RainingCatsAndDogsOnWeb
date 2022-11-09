namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ILikesService
    {
        Task SetLikeAsync(int adid, string userId, int likesCount);
    }
}
