namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;
  
    using static RainingCatsAndDogsOnWeb.Infrastructure.DataConstants.Comment;

    public class Comment : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
