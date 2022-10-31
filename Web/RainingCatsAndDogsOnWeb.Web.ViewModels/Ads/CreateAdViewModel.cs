namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ad
{
    using Microsoft.AspNetCore.Http;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
    using System.Collections.Generic;

    public class CreateAdViewModel : BaseAdViewModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
