namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexPageAdViewModel> RandomAds { get; set; }

        public int AdsCount { get; set; }
    }
}
