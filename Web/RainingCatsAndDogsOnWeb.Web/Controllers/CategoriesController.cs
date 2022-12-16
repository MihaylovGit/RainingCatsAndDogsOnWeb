namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Categories;
    

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IMemoryCache memoryCache;

        public CategoriesController(ICategoriesService categoriesService, IMemoryCache memoryCache)
        {
            this.categoriesService = categoriesService;
            this.memoryCache = memoryCache;
        }

        public IActionResult PostsByCategoryName(string name)
        {
            const string postsByCategoryCacheKey = "PostsByCategoryCacheKey";
            var cachedPosts = this.memoryCache.Get<CategoryViewModel>(postsByCategoryCacheKey);
            
            if (cachedPosts == null)
            {
                cachedPosts = this.categoriesService.GetByName<CategoryViewModel>(name);
                if (!cachedPosts.Posts.Any())
                {
                    return this.RedirectToAction(nameof(this.CategoryPostsEmpty));
                }

                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                this.memoryCache.Set(postsByCategoryCacheKey, cachedPosts);
            }

            return this.View(cachedPosts);
        }

        public IActionResult AllPostCategories()
        {
            var categories = this.categoriesService.GetAllCategories<Category>();

            return this.View(categories);
        }

        public IActionResult CategoryPostsEmpty()
        {
            return this.View();
        }
    }
}
