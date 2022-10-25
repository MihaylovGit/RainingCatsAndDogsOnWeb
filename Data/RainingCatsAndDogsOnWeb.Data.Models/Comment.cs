using RainingCatsAndDogsOnWeb.Data.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RainingCatsAndDogsOnWeb.Common.DataConstants.Comment;

namespace RainingCatsAndDogsOnWeb.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CommentTextMaxLength)]
        public string Text { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
