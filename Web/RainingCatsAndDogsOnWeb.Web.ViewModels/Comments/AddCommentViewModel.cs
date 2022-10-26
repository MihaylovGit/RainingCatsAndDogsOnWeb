namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Comment;

    public class AddCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }
    }
}
