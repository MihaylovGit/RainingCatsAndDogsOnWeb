namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using System.Collections.Generic;

    using RainingCatsAndDogsOnWeb.Data.Models;

    public class IndexViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
