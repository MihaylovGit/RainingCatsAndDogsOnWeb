namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ad
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class CreateAdViewModel : BaseAdViewModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
