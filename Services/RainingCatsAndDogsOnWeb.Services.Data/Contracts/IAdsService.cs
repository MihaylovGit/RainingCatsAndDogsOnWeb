namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdsService
    {
        Task CreateAsync(CreateAdViewModel input, string userId, string imagePath);

        IEnumerable<T> GetAllAds<T>(int pageNumber, int adsPerPage);

        IEnumerable<T> GetUserAds<T>(string userId);

        int GetAdsCount();

        int GetUserAdsCount(string userId);

        T DetailsById<T>(int adid);

        Task<IEnumerable<T>> GetRandom<T>(int count);

        Task UpdateAsync(int id, EditAdViewModel model);
    }
}
