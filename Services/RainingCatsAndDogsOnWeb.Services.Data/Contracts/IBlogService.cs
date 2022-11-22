﻿namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Models;

    public interface IBlogService
    {
        Task<Blog> Add(Blog blog);

        IEnumerable<T> GetAllBlogs<T>(int pageNumber, int adsPerPage);

        IEnumerable<T> GetMyBlogs<T>(ApplicationUser applicationUser, int pageNumber, int blogsPerPage);

        int GetBlogsCount();
    }
}
