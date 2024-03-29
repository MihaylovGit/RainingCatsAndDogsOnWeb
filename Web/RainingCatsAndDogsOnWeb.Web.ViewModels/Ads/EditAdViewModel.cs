﻿namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
{
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class EditAdViewModel : BaseAdViewModel, IMapFrom<Ad>
    {
        public int Id { get; set; }
    }
}
