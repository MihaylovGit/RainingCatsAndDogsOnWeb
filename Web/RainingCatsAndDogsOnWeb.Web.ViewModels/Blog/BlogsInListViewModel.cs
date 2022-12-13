namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using RainingCatsAndDogsOnWeb.Data.Models;

    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class BlogsInListViewModel : IMapFrom<Blog>
    {
        public int Id { get; set; }

        public ApplicationUser Creator { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
