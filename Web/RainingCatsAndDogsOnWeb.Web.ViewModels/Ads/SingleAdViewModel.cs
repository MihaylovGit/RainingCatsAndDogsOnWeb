namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
{
    using System;
    using System.Linq;

    using AutoMapper;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class SingleAdViewModel : IMapFrom<Ad>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public string AddedByUserUserName { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string AddedByAdmin { get; set; } = "Admin";

        public string AdminPhoneNumber { get; set; } = "088 33 68 290";

        public string CategoryName { get; set; }

        public string OriginalUrl { get; set; }

        public int LikesCount { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ad, SingleAdViewModel>()
                  //.ForMember(x => x.LikesCount, opt =>
                  //opt.MapFrom(x => x.Likes.Select(l => l.LikesCount)))
                  .ForMember(x => x.OriginalUrl, opt =>
                       opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                       x.Images.FirstOrDefault().RemoteImageUrl :
                       "/images/ads/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
                  .ForMember(x => x.PhoneNumber, opt =>
                  opt.MapFrom(x => x.AddedByUser.PhoneNumber));
        }
    }
}
