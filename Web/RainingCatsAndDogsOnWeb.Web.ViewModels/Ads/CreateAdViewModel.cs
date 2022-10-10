namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ad
{
    using System.Collections.Generic;
    using RainingCatsAndDogsOnWeb.Data.Models;

    public class CreateAdViewModel
    {
        public CreateAdViewModel()
        {
            this.Images = new HashSet<Image>();
        }

        public string Title { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }
        
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
