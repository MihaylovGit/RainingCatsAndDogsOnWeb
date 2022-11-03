namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchAdsService
    {
        public Task<IEnumerable<T>> GetAllAds<T>();
    }
}
