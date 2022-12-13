namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesServise;

        public CategoriesController(ICategoriesService categoriesServise)
        {
            this.categoriesServise = categoriesServise;
        }

        public IActionResult PostsByCategoryName(string name)
        {
            var viewModel = this.categoriesServise.GetByName<CategoryViewModel>(name);
            if (!viewModel.Posts.Any())
            {
                return this.RedirectToAction(nameof(this.CategoryPostsEmpty));
            }

            return this.View(viewModel);
        }

        public IActionResult AllPostCategories()
        {
            var categories = this.categoriesServise.GetAllCategories<Category>();

            return this.View(categories);
        }

        public IActionResult CategoryPostsEmpty()
        {
            return this.View();
        }
    }
}
