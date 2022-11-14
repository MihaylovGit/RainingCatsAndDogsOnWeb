namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    public class Like : BaseModel<int>
    {
        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int LikesCount { get; set; }
    }
}
