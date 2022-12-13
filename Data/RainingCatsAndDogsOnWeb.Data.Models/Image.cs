namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
