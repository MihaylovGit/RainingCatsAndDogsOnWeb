namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }
    }
}
