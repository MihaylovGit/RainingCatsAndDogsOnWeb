﻿namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
{
    using System.Linq;

    using AutoMapper;
    using RainingCatsAndDogsOnWeb.Data.Models;

    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class AdsInListViewModel : IMapFrom<Ad>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string OriginalUrl { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ad, AdsInListViewModel>()
                       .ForMember(x => x.OriginalUrl, opt =>
                       opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                       x.Images.FirstOrDefault().RemoteImageUrl :
                       "/images/ads/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
