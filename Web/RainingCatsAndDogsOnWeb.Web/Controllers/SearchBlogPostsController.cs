namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Categories;

    public class SearchBlogPostsController : Controller
    {
        private readonly ISearchBlogPostsService searchBlogPostsService;

        public SearchBlogPostsController(ISearchBlogPostsService searchBlogPostsService)
        {
            this.searchBlogPostsService = searchBlogPostsService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var posts = await this.searchBlogPostsService.GetAllPosts<PostInCategoryViewModel>();

            if (!string.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(x => x.Title.ToLower().Contains(searchString.ToLower()) ||
                x.Content.ToLower().Contains(searchString.ToLower()));
            }

            return this.View(posts);
        }
    }
}
