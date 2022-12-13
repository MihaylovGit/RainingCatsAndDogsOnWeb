namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    using static RainingCatsAndDogsOnWeb.Infrastructure.DataConstants.Comment;

    public class CreateCommentViewModel : IMapFrom<Comment>
    {
        public int PostId { get; set; }

        public int ParentId { get; set; }

        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }
    }
}
