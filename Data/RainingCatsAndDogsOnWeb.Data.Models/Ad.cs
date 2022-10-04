namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    public class Ad : BaseDeletableModel<int>
    {
        public Ad()
        {
            this.Images = new HashSet<Image>();
        }

        public string Title { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
