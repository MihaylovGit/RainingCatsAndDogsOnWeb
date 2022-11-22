namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using System;

    public class BlogsPagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.BlogsCount / this.BlogsPerPage);

        public int NextPageNumber => this.PageNumber + 1;

        public int BlogsCount { get; set; }

        public int BlogsPerPage { get; set; }
    }
}
