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
        private readonly IBlogBusinessManager businessManager;
        private readonly IBlogService blogService;

        public BlogController(IBlogBusinessManager businessManager, IBlogService blogService)
        {
            this.businessManager = businessManager;
            this.blogService = blogService;
        }

        public IActionResult Default(int id = 1)
        {
            const int BlogsPerPage = 6;

            var viewModel = new BlogsListViewModel()
            {
                BlogsPerPage = BlogsPerPage,
                PageNumber = id,
                BlogsCount = this.blogService.GetBlogsCount(),
                AllBlogs = this.blogService.GetAllBlogs<BlogsInListViewModel>(id, BlogsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View(new CreateBlogViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogViewModel model)
        {
            await this.businessManager.CreateBlog(model, this.User);

            return this.RedirectToAction("Default");
        }
    }
}
