namespace RainingCatsAndDogsOnWeb.Web.BlogBusinessManager
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Blog;
    using System.IO;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class BlogBusinessManager : IBlogBusinessManager
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogService blogService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BlogBusinessManager(UserManager<ApplicationUser> userManager, IBlogService blogService, IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.blogService = blogService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<Blog> CreateBlog(CreateBlogViewModel model, ClaimsPrincipal claimsPrincipal)
        {
            Blog blog = model.Blog;
            blog.Creator = await this.userManager.GetUserAsync(claimsPrincipal);

            blog = await this.blogService.Add(blog);

            //Directory.CreateDirectory($"{imagePath}/ads/");

            string webRootPath = this.webHostEnvironment.WebRootPath;

            string pathToImage = $@"{webRootPath}\images\blogs\{blog.Id}\HeaderImage.jpg";

            this.EnsureFolder(pathToImage);

            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await model.BlogHeaderImage.CopyToAsync(fileStream);
            }

            return blog;
        }

        //public async Task<IndexViewModel> Index(ClaimsPrincipal claimsPrincipal)
        //{
        //    ApplicationUser user = await this.userManager.GetUserAsync(claimsPrincipal);
        //    return this.blogService.GetBlogs(user);
        //}

        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
