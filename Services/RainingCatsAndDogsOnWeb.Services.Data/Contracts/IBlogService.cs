namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Blog;

    public interface IBlogService
    {
        Task<Blog> CreateBlog(CreateBlogViewModel model, ClaimsPrincipal claimsPrincipal);

        Task<Blog> Add(Blog blog);
    }
}
