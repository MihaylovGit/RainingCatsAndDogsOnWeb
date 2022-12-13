namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    using static RainingCatsAndDogsOnWeb.Infrastructure.DataConstants.Reply;

    public class Reply : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(ReplyContentMaxLength)]
        public string Content { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
