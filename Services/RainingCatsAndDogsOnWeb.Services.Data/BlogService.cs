namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Data.Repositories;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Blog;

    public class BlogService : IBlogService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Blog> blogRepository;

        public BlogService(UserManager<ApplicationUser> userManager, IDeletableEntityRepository<Blog> blogRepository)
        {
            this.userManager = userManager;
            this.blogRepository = blogRepository;
        }

        public async Task<Blog> Add(Blog blog)
        {
            await this.blogRepository.AddAsync(blog);

            await this.blogRepository.SaveChangesAsync();

            return blog;
        }

        public async Task<Blog> CreateBlog(CreateBlogViewModel model, ClaimsPrincipal claimsPrincipal)
        {
            Blog blog = model.Blog;
            blog.Creator = await this.userManager.GetUserAsync(claimsPrincipal);

            blog = await this.Add(blog);
            return blog;
        }
    }
}
