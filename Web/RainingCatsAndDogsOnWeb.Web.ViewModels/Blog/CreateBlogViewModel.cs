namespace RainingCatsAndDogsOnWeb.Web.ViewModels.Blog
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using RainingCatsAndDogsOnWeb.Data.Models;

    public class CreateBlogViewModel
    {
        [Required]
        [Display(Name = "Header Image")]
        public IFormFile BlogHeaderImage { get; set; }

        public Blog Blog { get; set; }
    }
}
