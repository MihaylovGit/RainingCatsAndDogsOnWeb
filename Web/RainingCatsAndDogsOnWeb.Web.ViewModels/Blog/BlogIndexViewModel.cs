namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using System.Collections.Generic;

    public class BlogIndexViewModel : IMapFrom<Category>
    {
        public BlogIndexViewModel()
        {
            this.Categories = new HashSet<IndexCategoryViewModel>();
        }

        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
