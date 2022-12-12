using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RainingCatsAndDogsOnWeb.Data.Models;
using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
using RainingCatsAndDogsOnWeb.Web.ViewModels.Posts;
using System.Threading.Tasks;

namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            // TODO
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View(new CreatePostViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var post = new Post
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                Content = model.Content,
                UserId = user.Id,
            };

            await this.postsService.CreatePost(post);

            return this.RedirectToAction("ById", new { id = post.Id });
        }
    }
}
