namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Post;

    public class Post : BaseDeletableModel<int>
    {
        public Blog Blog { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; }

        public Post Parent { get; set; }
    }
}
