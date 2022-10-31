namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ad
{
    using Microsoft.AspNetCore.Http;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
    using System.Collections.Generic;

    public class CreateAdViewModel : BaseAdViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
