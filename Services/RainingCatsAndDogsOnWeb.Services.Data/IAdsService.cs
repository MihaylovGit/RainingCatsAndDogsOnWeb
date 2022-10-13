namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;

    public interface IAdsService
    {
        Task CreateAsync(CreateAdViewModel input, string userId, string imagePath);

        IEnumerable<T> GetAllAds<T>(int pageNumber, int adsPerPage);

        int GetAdsCount();
    }
}
