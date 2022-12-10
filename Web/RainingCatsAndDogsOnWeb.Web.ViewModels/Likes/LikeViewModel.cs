namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Likes
{
    using System.ComponentModel.DataAnnotations;

    public class LikeViewModel
    {
        public int AdId { get; set; }

        [Range(0, int.MaxValue)]
        public int LikesCount { get; set; }
    }
}
