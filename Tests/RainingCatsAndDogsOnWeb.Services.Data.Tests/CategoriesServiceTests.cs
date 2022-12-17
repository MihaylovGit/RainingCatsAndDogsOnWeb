namespace RainingCatsAndDogsOnWeb.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Data.Repositories;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using System;

    using Xunit;

    public class CategoriesServiceTests
    {
        public const string FirstUserId = "Stamat";
        public const string SecondUserId = "Stoyan";
        public const string FirstCategoryName = "Dogs";
        public const string SecondCategoryName = "Cats";

        public class MyTestCategory : IMapFrom<Category>
        {
            public string Name { get; set; }
        }

        [Fact]
        public async Task GetAllAsKeyValuePairsShouldReturn()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));

            var categoriesService = new CategoriesService(categoriesRepositoty);

            var firstCategory = new Category
            {
                Name = FirstCategoryName,
            };

            var secondCategory = new Category
            {
                Name = SecondCategoryName,
            };

            // Act
            await categoriesRepositoty.AddAsync(firstCategory);
            await categoriesRepositoty.AddAsync(secondCategory);
            await categoriesRepositoty.SaveChangesAsync();

            var categories = categoriesService.GetAllAsKeyValuePairs();

            // Assert
            Assert.Contains(FirstCategoryName, categories.First().Value);
        }

        [Fact]
        public async Task GetAllCategoriesShouldReturn()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));

            var categoriesService = new CategoriesService(categoriesRepositoty);

            var firstCategory = new Category
            {
                Name = FirstCategoryName,
            };

            var secondCategory = new Category
            {
                Name = SecondCategoryName,
            };

            // Act
            await categoriesRepositoty.AddAsync(firstCategory);
            await categoriesRepositoty.AddAsync(secondCategory);
            await categoriesRepositoty.SaveChangesAsync();
            AutoMapperConfig.RegisterMappings(typeof(MyTestCategory).Assembly);
            var categories = categoriesService.GetAllCategories<MyTestCategory>();

            // Assert
            Assert.Equal(2, categories.Count());
            Assert.StartsWith("C", categories.First().Name);
        }

        [Fact]
        public async Task GetByNameShouldReturnCategoryIfSuchExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));

            var categoriesService = new CategoriesService(categoriesRepositoty);

            var firstCategory = new Category
            {
                Name = FirstCategoryName,
            };

            var secondCategory = new Category
            {
                Name = SecondCategoryName,
            };

            // Act
            await categoriesRepositoty.AddAsync(firstCategory);
            await categoriesRepositoty.AddAsync(secondCategory);
            await categoriesRepositoty.SaveChangesAsync();
            AutoMapperConfig.RegisterMappings(typeof(MyTestCategory).Assembly);
            var category = categoriesService.GetByName<MyTestCategory>(FirstCategoryName);

            // Assert
           Assert.Contains(FirstCategoryName, category.Name);
        }

        [Fact]
        public async Task GetByNameShouldReturnNullWhenCategoryNameDoesNotExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));

            var categoriesService = new CategoriesService(categoriesRepositoty);

            var firstCategory = new Category
            {
                Name = FirstCategoryName,
            };

            // Act
            await categoriesRepositoty.AddAsync(firstCategory);
            await categoriesRepositoty.SaveChangesAsync();

            AutoMapperConfig.RegisterMappings(typeof(MyTestCategory).Assembly);
            var category = categoriesService.GetByName<MyTestCategory>(SecondCategoryName);

            // Assert
            Assert.Null(category);
        }
    }
}
        
           
