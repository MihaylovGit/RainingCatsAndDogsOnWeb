namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Categories;

    [Authorize]
    public class SearchBlogPostsController : Controller
    {
        private readonly ISearchBlogPostsService searchBlogPostsService;

        public SearchBlogPostsController(ISearchBlogPostsService searchBlogPostsService)
        {
            this.searchBlogPostsService = searchBlogPostsService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
            {
                return this.View(nameof(this.NoResultsFound));
            }

            var posts = await this.searchBlogPostsService.GetAllMatchedPosts<PostInCategoryViewModel>(searchString);
            if (!posts.Any())
            {
                return this.View(nameof(this.NoResultsFound));
            }

            return this.View(posts);
        }

        public IActionResult NoResultsFound()
        {
            return this.View();
        }
    }
}
