namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Categories
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    using static RainingCatsAndDogsOnWeb.Infrastructure.DataConstants.Post;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; }

        public string ShortContent => this.Content?.Length > 100 ? this.Content.Substring(0, 100) + "..." : this.Content;

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
