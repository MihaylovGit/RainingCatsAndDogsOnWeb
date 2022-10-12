namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
{
    using System;
    using System.Collections.Generic;

    public class AdsListViewModel : PagingViewModel
    {
        public AdsListViewModel()
        {
            this.AllAds = new HashSet<AdsInListViewModel>();
        }

        public IEnumerable<AdsInListViewModel> AllAds { get; set; }
    }
}
