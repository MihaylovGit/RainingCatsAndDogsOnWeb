namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ad
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CreateAdViewModel
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }
        
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
