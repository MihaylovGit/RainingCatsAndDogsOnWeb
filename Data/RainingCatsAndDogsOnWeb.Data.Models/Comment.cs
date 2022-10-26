namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Comment;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
