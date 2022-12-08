namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class BlogIndexViewModel : IMapFrom<Category>
    {
        public BlogIndexViewModel()
        {
            this.Categories = new HashSet<IndexCategoryViewModel>();
        }

        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
