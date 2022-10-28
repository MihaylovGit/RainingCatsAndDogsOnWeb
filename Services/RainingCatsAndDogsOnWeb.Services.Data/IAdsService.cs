namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;

    public interface IAdsService
    {
        Task CreateAsync(CreateAdViewModel input, string userId, string imagePath);

        IEnumerable<T> GetAllAds<T>(int pageNumber, int adsPerPage);

        IEnumerable<T> GetUserAds<T>(string userId);

        int GetAdsCount();

        int GetUserAdsCount(string userId);

        T DetailsById<T>(int adid);

        Task<IEnumerable<T>> GetRandom<T>(int count);
    }
}
