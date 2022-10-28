namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Home
{
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using AutoMapper;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
    using System.Linq;

    public class IndexPageAdViewModel : IMapFrom<Ad>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        public string ApplicationUserFirstName { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ad, IndexPageAdViewModel>()
                  .ForMember(x => x.ImageUrl, opt =>
                  opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                  x.Images.FirstOrDefault().RemoteImageUrl :
                  "/images/ads/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
