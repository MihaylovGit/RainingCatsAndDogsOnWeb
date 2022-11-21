namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Models;

    public interface IBlogService
    {
        Task<Blog> Add(Blog blog);

        IEnumerable<Blog> GetBlogs(ApplicationUser applicationUser);
    }
}
