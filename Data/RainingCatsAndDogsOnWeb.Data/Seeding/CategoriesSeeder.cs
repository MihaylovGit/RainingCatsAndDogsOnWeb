namespace RainingCatsAndDogsOnWeb.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Categories.Any())
            {
                await dbContext.Categories.AddAsync(new Category { Name = "Cat", ImageUrl = "https://img.freepik.com/free-photo/beautiful-shot-white-british-shorthair-kitten_181624-57681.jpg?w=2000" });
                await dbContext.Categories.AddAsync(new Category { Name = "Dog", ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F47%2F2020%2F08%2F04%2Fcream-golden-retriever-closeup-91607998-2000.jpg" });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
