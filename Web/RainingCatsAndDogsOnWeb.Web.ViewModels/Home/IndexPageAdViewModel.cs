﻿namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Home
{
    using AutoMapper;
    using System.Linq;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;


    public class IndexPageAdViewModel : IMapFrom<Ad>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Price { get; set; }

        public string ApplicationUserFirstName { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ad, IndexPageAdViewModel>()
                  .ForMember(x => x.ImageUrl, opt =>
                  opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                  x.Images.FirstOrDefault().RemoteImageUrl : x.OriginalUrl));
                  //"/images/ads/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
