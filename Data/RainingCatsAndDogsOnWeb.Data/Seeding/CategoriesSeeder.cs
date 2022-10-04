namespace RainingCatsAndDogsOnWeb.Data.Seeding
{
    using RainingCatsAndDogsOnWeb.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Categories.Any())
            {
                await dbContext.Categories.AddAsync(new Category { Name = "Dog" });
                await dbContext.Categories.AddAsync(new Category { Name = "Cat" });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
