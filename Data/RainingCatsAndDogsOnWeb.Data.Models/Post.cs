namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using RainingCatsAndDogsOnWeb.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RainingCatsAndDogsOnWeb.Infrastructure.DataConstants.Post;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

    }
}
