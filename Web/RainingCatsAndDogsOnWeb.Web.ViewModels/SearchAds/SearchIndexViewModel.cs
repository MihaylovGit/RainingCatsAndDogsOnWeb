namespace RainingCatsAndDogsOnWeb.Web.ViewModels.SearchAds
{
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class SearchIndexViewModel
    {
       public IEnumerable<AdsInListViewModel> Ads { get; set; }
    }
}
