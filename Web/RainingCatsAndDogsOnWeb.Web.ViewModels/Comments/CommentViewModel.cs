namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Data.Models;

    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
