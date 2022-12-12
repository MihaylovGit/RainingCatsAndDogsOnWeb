namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Posts
{
    using System;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string PostHeaderImage { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
