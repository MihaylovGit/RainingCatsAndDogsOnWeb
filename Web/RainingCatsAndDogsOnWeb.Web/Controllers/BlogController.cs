namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Blog;

    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoriesService categoriesService;

        public BlogController(IBlogService blogService, ICategoriesService categoriesService)
        {
            this.blogService = blogService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new BlogIndexViewModel
            {
                Categories = this.categoriesService.GetAllCategories<IndexCategoryViewModel>(),
            };

            return this.View(viewModel);
        }

       

    }
}
