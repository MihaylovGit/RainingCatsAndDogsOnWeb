namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    using static RainingCatsAndDogsOnWeb.Infrastructure.DataConstants.Blog;

    public class Blog : BaseDeletableModel<int>
    {
        public ApplicationUser Creator { get; set; }

        [Required]
        [MaxLength(BlogTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(BlogContentMaxLength)]
        public string Content { get; set; }

        public bool Approved { get; set; }

        public bool Published { get; set; }

        public ApplicationUser Approver { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
