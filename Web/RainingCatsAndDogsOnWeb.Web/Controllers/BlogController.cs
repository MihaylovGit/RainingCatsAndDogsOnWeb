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
        //private readonly IBlogService blogService;
        private readonly IBlogBusinessManager businessManager;

        public BlogController(IBlogBusinessManager businessManager)
        {
            //this.blogService = blogService;
            this.businessManager = businessManager;
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
            await this.businessManager.CreateBlog(model, this.User);

            return this.RedirectToAction("Create");
        }
    }
}
