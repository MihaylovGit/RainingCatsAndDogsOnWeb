namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Ads = new List<Ad>();
        }

        public string Name { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}
