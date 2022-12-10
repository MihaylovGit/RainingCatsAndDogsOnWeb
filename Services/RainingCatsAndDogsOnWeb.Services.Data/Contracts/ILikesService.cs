namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Models;

    public interface ILikesService
    {
        Task SetLikeAsync(int adid, string userId, int likesCount);
    }
}
