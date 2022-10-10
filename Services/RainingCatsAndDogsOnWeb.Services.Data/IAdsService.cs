namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public interface IAdsService
    {
        Task CreateAsync(CreateAdViewModel input, string userId);

        IEnumerable<T> GetAllAds<T>(int pageNumber, int adsPerPage = 6);

        int GetAdsCount();
    }
}
