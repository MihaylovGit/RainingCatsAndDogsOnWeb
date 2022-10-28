namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ad
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using RainingCatsAndDogsOnWeb.Data.Models;

    public class CreateAdViewModel
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
