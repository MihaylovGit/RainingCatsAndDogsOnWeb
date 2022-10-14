﻿namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
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

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ad, SingleAdViewModel>()
                  .ForMember(x => x.ImageUrl, opt =>
                  opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                  x.Images.FirstOrDefault().RemoteImageUrl :
                  "/images/ads/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
