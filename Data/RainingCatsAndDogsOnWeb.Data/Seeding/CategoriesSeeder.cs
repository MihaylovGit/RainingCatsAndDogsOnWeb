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
                await dbContext.Categories.AddAsync(new Category { Name = "Cat" });
                await dbContext.Categories.AddAsync(new Category { Name = "Dog" });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
