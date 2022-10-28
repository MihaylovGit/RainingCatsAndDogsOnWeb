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

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string AddedByUserUserName { get; set; }

        public string AddedByUserFirstName { get; set; }

        public string AddedByUserLastName { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ad, SingleAdViewModel>()
                  .ForMember(x => x.ImageUrl, opt =>
                  opt.MapFrom(x => x.Images.Select(x => $"/images/{x.AddedByUserId}.{x.Extension}")));

            configuration.CreateMap<Ad, SingleAdViewModel>()
                         .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.AddedByUser.PhoneNumber));
        }
    }
}
