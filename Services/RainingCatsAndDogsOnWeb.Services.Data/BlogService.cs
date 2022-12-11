namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    public class BlogService : IBlogService
    {
        private readonly IDeletableEntityRepository<Blog> blogRepository;

        public BlogService(IDeletableEntityRepository<Blog> blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<Blog> CreateBlog(Blog blog)
        {
            await this.blogRepository.AddAsync(blog);

            await this.blogRepository.SaveChangesAsync();

            return blog;
        }

        public IEnumerable<T> GetAllBlogs<T>(int pageNumber, int blogsPerPage)
        {
            return this.blogRepository.AllAsNoTracking()
                                      .Include(b => b.Creator)
                                      .Include(b => b.Approver)
                                      .Include(b => b.Posts)
                                      .OrderByDescending(x => x.Id)
                                      .Skip((pageNumber - 1) * blogsPerPage)
                                      .To<T>()
                                      .ToList();
        }

        public IEnumerable<T> GetMyBlogs<T>(ApplicationUser applicationUser, int pageNumber, int blogsPerPage)
        {
            return this.blogRepository.AllAsNoTracking()
                                      .Include(b => b.Creator)
                                      .Include(b => b.Approver)
                                      .Include(b => b.Posts)
                                      .Where(b => b.Creator == applicationUser)
                                      .OrderByDescending(x => x.Id)
                                      .Skip((pageNumber - 1) * blogsPerPage)
                                      .To<T>()
                                      .ToList();
        }

        public int GetBlogsCount()
        {
            return this.blogRepository.All().Count();
        }
    }
}
