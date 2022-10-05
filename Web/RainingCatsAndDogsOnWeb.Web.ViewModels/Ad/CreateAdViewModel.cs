namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ad
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CreateAdViewModel
    {
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^(?![\W_]+$)(?!\d+$)[\w .&',-]+(?:\s[\w .&',-]+)+$", ErrorMessage = "The title of the ad should be at least of two words!")]
        [Required]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Location { get; set; }

        [Range(1, 100000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [StringLength(255, MinimumLength = 10)]
        [RegularExpression(@"^(?![\W_]+$)(?!\d+$)[\w .&',-]+(?:\s[\w .&',-]+)+$", ErrorMessage = "The description of the ad should be at least of two words!")]
        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
