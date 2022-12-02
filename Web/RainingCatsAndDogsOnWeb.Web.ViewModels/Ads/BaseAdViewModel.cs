
namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Ads
{
    using RainingCatsAndDogsOnWeb.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Ad;

    public abstract class BaseAdViewModel
    {
        [Required]
        [StringLength(AdTitleMaxLength, MinimumLength = AdTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(AdLocationMaxLength, MinimumLength = AdLocationMinLength)]
        public string Location { get; set; }

        public string Price { get; set; }

        [Required]
        [StringLength(AdDescriptionMaxLength, MinimumLength = AdDescriptionMinLength)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
