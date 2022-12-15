namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Categories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchBlogPostsService
    {
        public Task<IEnumerable<PostInCategoryViewModel>> GetAllMatchedPosts<T>(string searchString);
    }
}
