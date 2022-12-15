namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public interface ISearchAdsService
    {
        public Task<IEnumerable<AdsInListViewModel>> GetAllMatchedAds<T>(string searchString);
    }
}
