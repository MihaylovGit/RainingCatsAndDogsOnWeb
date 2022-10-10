namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
{
    using System;
    using System.Collections.Generic;

    public class AdsListViewModel
    {
        public AdsListViewModel()
        {
            this.AllAds = new HashSet<AdsInListViewModel>();
        }

        public IEnumerable<AdsInListViewModel> AllAds { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.AdsCount / this.AdsPerPage);

        public int NextPageNumber => this.PageNumber + 1;

        public int AdsCount { get; set; }

        public int AdsPerPage { get; set; }
    }
}
