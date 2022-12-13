namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Posts
{
    using System;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }
    }
}
