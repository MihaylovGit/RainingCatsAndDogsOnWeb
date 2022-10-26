using RainingCatsAndDogsOnWeb.Data.Models;
namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Comments
{
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using System.Collections.Generic;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
