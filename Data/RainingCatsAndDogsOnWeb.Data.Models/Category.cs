namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Category;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<Ad> Ads { get; set; } = new List<Ad>();

        public virtual ICollection<Post> Posts { get; set; }
    }
}
