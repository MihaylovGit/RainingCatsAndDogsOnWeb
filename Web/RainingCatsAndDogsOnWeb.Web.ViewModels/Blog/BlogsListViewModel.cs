namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class BlogsListViewModel : BlogsPagingViewModel
    {
        public BlogsListViewModel()
        {
            this.AllBlogs = new HashSet<BlogsInListViewModel>();
        }

        public IEnumerable<BlogsInListViewModel> AllBlogs { get; set; }
    }
}
