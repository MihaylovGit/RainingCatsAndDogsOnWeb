namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Blog;
    using System.Threading.Tasks;

    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult Default()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View(new CreateBlogViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogViewModel model)
        {
            await this.blogService.CreateBlog(model, this.User);

            return this.View();
        }
    }
}
