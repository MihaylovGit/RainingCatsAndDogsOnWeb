namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using RainingCatsAndDogsOnWeb.Data.Common.Models;
    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Ad;

    public class Ad : BaseDeletableModel<int>
    {
        public Ad()
        {
            this.Images = new HashSet<Image>();
            this.Likes = new HashSet<Like>();
        }

        [Required]
        [MaxLength(AdTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(AdLocationMaxLength)]
        public string Location { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(AdDescriptionMaxLength)]
        public string Description { get; set; }

        public string OriginalUrl { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
