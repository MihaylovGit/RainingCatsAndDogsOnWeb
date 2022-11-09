using System.ComponentModel.DataAnnotations;

namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Likes
{
    public class PostLikeViewModel
    {
        public int AdId { get; set; }

        [Range(0, int.MaxValue)]
        public int LikesCount { get; set; }
    }
}
