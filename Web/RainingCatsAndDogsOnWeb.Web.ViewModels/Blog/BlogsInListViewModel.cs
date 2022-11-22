namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using AutoMapper;
    using RainingCatsAndDogsOnWeb.Data.Models;

    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class BlogsInListViewModel : IMapFrom<Blog>
    {
        public int Id { get; set; }

        public ApplicationUser Creator { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Blog, BlogsInListViewModel>()
        //         .ForMember(x => x.ImageUrl, opt =>
        //         opt.MapFrom(x => $"/images/blogs/1/HeaderImage.jpg"));
        //}
    }
}
