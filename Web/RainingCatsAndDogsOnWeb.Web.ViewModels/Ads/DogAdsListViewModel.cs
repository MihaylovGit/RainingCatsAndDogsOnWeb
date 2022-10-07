namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
{
    using System.Collections.Generic;

    public class DogAdsListViewModel
    {
        public DogAdsListViewModel()
        {
            this.DogAds = new HashSet<DogAdsInListViewModel>();
        }

        public IEnumerable<DogAdsInListViewModel> DogAds { get; set; }

        public int PageNumber { get; set; }
    }
}
