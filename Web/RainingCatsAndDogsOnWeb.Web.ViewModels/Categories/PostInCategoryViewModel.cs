namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Categories
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    using static RainingCatsAndDogsOnWeb.Common.DataConstants.Post;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        [Required]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
