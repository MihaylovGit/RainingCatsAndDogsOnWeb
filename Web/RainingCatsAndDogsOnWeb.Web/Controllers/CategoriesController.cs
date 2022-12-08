namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesServise;

        public CategoriesController(ICategoriesService categoriesServise)
        {
            this.categoriesServise = categoriesServise;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesServise.GetByName<CategoryViewModel>(name);

            return this.View(viewModel);
        }
    }
}
