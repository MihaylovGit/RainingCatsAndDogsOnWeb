namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Post;

    public class CreatePostViewModel : IMapFrom<Post>
    {
        [Required]
        [Display(Name = "Header Image")]
        public IFormFile PostHeaderImage { get; set; }

        [Required]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}
