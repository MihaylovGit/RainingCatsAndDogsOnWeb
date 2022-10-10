namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }
       
        public string Extension { get; set; }

        // The contents of the image is on the file system!
        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
