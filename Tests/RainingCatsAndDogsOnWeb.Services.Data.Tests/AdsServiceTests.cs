namespace RainingCatsAndDogsOnWeb.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Data.Repositories;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
    using Xunit;

    public class AdsServiceTests
    {
        public const string FirstUserId = "Stamat";
        public const string SecondUserId = "Stoyan";
        public const string ImagePath = "/images/ads";
        public const string Title = "This is a test title";
        public const string Location = "London, Great Britain";
        public const string Price = "500lv";
        public const string Description = "This is a test description";
        public const int CategoryId = 2;

        public class MyTestAd : IMapFrom<Ad>
        {
            public string Title { get; set; }

            public string Location { get; set; }

            public string Price { get; set; }

            public string Description { get; set; }

            public string AddedByUserId { get; set; }

            public int CategoryId { get; set; }
        }

        [Fact]
        public async Task WhenUserCreateAdShouldAdsCountBecomeEqualToOne()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            List<IFormFile> images = new List<IFormFile>();

            var inputModel = new CreateAdViewModel
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                Images = images,
            };

            // Act
            await adsService.CreateAsync(inputModel, FirstUserId, ImagePath);

            // Assert
            Assert.Equal(1, adsRepositoty.All().Count());
        }

        [Fact]
        public async Task WhenUserDeleteAdNoAdsShouldExist()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int id = 1;

            List<IFormFile> images = new List<IFormFile>();

            var inputModel = new CreateAdViewModel
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                Images = images,
            };

            // Act
            await adsService.CreateAsync(inputModel, FirstUserId, ImagePath);
            await adsService.DeleteAsync(id);

            // Assert
            Assert.Equal(0, adsRepositoty.All().Count());
        }

        [Fact]
        public async Task WhenUserDeleteAdWhichIdDoesNotExistArgumentExceptionShouldBeThrown()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int id = 222;

            List<IFormFile> images = new List<IFormFile>();

            var inputModel = new CreateAdViewModel
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                Images = images,
            };

            // Act
            await adsService.CreateAsync(inputModel, FirstUserId, ImagePath);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await adsService.DeleteAsync(id));
        }

        [Fact]
        public void DetailsByIdShouldReturnRequiredAdByItsId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int id = 1;

            var ad = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            adsRepositoty.AddAsync(ad).GetAwaiter();
            AutoMapperConfig.RegisterMappings(typeof(MyTestAd).Assembly);
            adsRepositoty.SaveChangesAsync().GetAwaiter().GetResult();

            // Act
            var adinDb = adsService.DetailsById<MyTestAd>(id);

            // Assert
            Assert.Equal(ad.Title, adinDb.Title);
            Assert.Equal(ad.Location, adinDb.Location);
            Assert.Equal(ad.Description, adinDb.Description);
            Assert.Equal(ad.Price, adinDb.Price);
            Assert.Equal(ad.AddedByUserId, adinDb.AddedByUserId);
            Assert.Equal(ad.CategoryId, adinDb.CategoryId);
        }

        [Fact]
        public async Task WhenThreeAdsAreAddedGetAdsCountShouldReturnAdsCountAndCategoriesCountEqualToThree()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);

            List<IFormFile> images = new List<IFormFile>();

            var inputModelOne = new CreateAdViewModel
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                Images = images,
            };

            var inputModelTwo = new CreateAdViewModel
            {
                Title = "This is a test title two",
                Location = "Madrid, Great Britain",
                Price = "600lv",
                Description = "This is a test description",
                CategoryId = 2,
                Images = images,
            };

            var inputModelThree = new CreateAdViewModel
            {
                Title = "This is a test title two",
                Location = "Athens, Great Britain",
                Price = "400lv",
                Description = "This is a test description",
                CategoryId = 2,
                Images = images,
            };

            // Act
            await adsService.CreateAsync(inputModelOne, FirstUserId, ImagePath);
            await adsService.CreateAsync(inputModelTwo, FirstUserId, ImagePath);
            await adsService.CreateAsync(inputModelThree, FirstUserId, ImagePath);

            var adsCount = countsService.GetCounts();

            // Assert
            Assert.Equal(3, adsCount.AdsCount);
            Assert.Equal(3, adsCount.AdsCount);
        }

        [Fact]
        public async void GetAdsCountShouldReturnAdsCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);

            var ad = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            await adsRepositoty.AddAsync(ad);

            await adsRepositoty.SaveChangesAsync();

            // Act
            var adsCount = adsService.GetAdsCount();

            // Assert
            Assert.Equal(1, adsCount);
        }

        [Fact]
        public async void DetailsByIdShouldReturnNullWhenAdIsNotFound()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int id = 222;

            var ad = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            await adsRepositoty.AddAsync(ad);
            AutoMapperConfig.RegisterMappings(typeof(MyTestAd).Assembly);
            await adsRepositoty.SaveChangesAsync();

            // Act
            var result = adsService.DetailsById<MyTestAd>(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetPagesCountShouldReturn()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int adsPerPage = 6;

            var ad = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };
            await adsRepositoty.AddAsync(ad);
            await adsRepositoty.SaveChangesAsync();

            // Act
            var pagesCount = adsService.GetPagesCount(adsPerPage);

            // Assert
            Assert.Equal(0, pagesCount);
        }

        [Fact]
        public async void GetPagesCountShouldReturnOnePageWhenAdsPerPageEqualToOne()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int adsPerPage = 1;

            var ad = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };
            await adsRepositoty.AddAsync(ad);
            await adsRepositoty.SaveChangesAsync();

            // Act
            var pagesCount = adsService.GetPagesCount(adsPerPage);

            // Assert
            Assert.Equal(1, pagesCount);
        }

        [Fact]
        public async void GetAllAdsShouldReturnWhenParametersAreCorrect()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int adsPerPage = 1;
            int pageNumber = 2;

            var firstAd = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            var secondAd = new Ad
            {
                Title = "Test Title",
                Location = "Madrid, Spain",
                Price = "1000lv",
                Description = "This is a test",
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            await adsRepositoty.AddAsync(firstAd);
            await adsRepositoty.AddAsync(secondAd);
            await adsRepositoty.SaveChangesAsync();
            AutoMapperConfig.RegisterMappings(typeof(MyTestAd).Assembly);

            // Act
            var ads = adsService.GetAllAds<MyTestAd>(pageNumber, adsPerPage);

            // Assert
            Assert.Single(ads);
        }

        [Fact]
        public async void GetAllAdsShouldReturnZeroWhenParametersAreBothEqualToZero()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int adsPerPage = 0;
            int pageNumber = 0;

            var firstAd = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            var secondAd = new Ad
            {
                Title = "Test Title",
                Location = "Madrid, Spain",
                Price = "1000lv",
                Description = "This is a test",
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            await adsRepositoty.AddAsync(firstAd);
            await adsRepositoty.AddAsync(secondAd);
            await adsRepositoty.SaveChangesAsync();
            AutoMapperConfig.RegisterMappings(typeof(MyTestAd).Assembly);

            // Act
            var ads = adsService.GetAllAds<MyTestAd>(pageNumber, adsPerPage);

            // Assert
            Assert.Empty(ads);
        }

        [Fact]
        public async void GetRandomShouldReturnCountAdsWhenCountIsValid()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int count = 2;

            var firstAd = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            var secondAd = new Ad
            {
                Title = "Test Title",
                Location = "Madrid, Spain",
                Price = "1000lv",
                Description = "This is a test",
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            var thirdAd = new Ad
            {
                Title = "Test Title 2",
                Location = "Livorno, Italy",
                Price = "1200lv",
                Description = "This is a test 2",
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };

            await adsRepositoty.AddAsync(firstAd);
            await adsRepositoty.AddAsync(secondAd);
            await adsRepositoty.AddAsync(thirdAd);

            await adsRepositoty.SaveChangesAsync();
            var adsAmount = adsRepositoty.All().Count();
            AutoMapperConfig.RegisterMappings(typeof(MyTestAd).Assembly);

            // Act
            var ads = adsService.GetRandom<MyTestAd>(count);
            var adsCount = ads.Result.Count();

            // Assert
            Assert.Equal(2, adsCount);
        }

        [Fact]
        public async void GetRandomShouldReturnCountAdsWhenThereIsNoAds()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int count = 10;

            AutoMapperConfig.RegisterMappings(typeof(MyTestAd).Assembly);

            // Act
            var randomAds = await adsService.GetRandom<MyTestAd>(count);
            var adsCount = randomAds.Count();

            // Assert
            Assert.Equal(0, adsCount);
        }

        [Fact]
        public async void GetUserAdsCountShouldReturnOneWhenUserCreateAd()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);

            List<IFormFile> images = new List<IFormFile>();

            var inputModel = new CreateAdViewModel
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                Images = images,
            };

            // Act
            await adsService.CreateAsync(inputModel, FirstUserId, ImagePath);

            var userAdsCount = adsService.GetUserAdsCount(FirstUserId);

            // Assert
            Assert.Equal(1, userAdsCount);
        }

        [Fact]
        public void GetUserAdsShouldReturnEmptyCollectionWhenUserDoesNotHaveAny()
        {
            // Assert
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);

            // Act
            AutoMapperConfig.RegisterMappings(typeof(MyTestAd).Assembly);
            var userAds = adsService.GetUserAds<MyTestAd>(SecondUserId);

            // Assert
            Assert.Empty(userAds);
        }

        [Fact]
        public void GetUserAdsCountShouldReturnZeroWhenUserDoesNotHaveAny()
        {
            // Assert
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);

            // Act
            var userAdsCount = adsService.GetUserAdsCount(SecondUserId);

            // Assert
            Assert.Equal(0, userAdsCount);
        }

        [Fact]
        public async Task UpdateAsyncShouldChangeExistingAdWhenAdIdExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int id = 1;

            var ad = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };
            await adsRepositoty.AddAsync(ad);
            await adsRepositoty.SaveChangesAsync();

            var inputModel = new EditAdViewModel
            {
                Title = "This is edit title",
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
            };

            // Act
            await adsService.UpdateAsync(id, inputModel);
            var editedAd = await adsRepositoty.All().FirstOrDefaultAsync();

            // Assert
            Assert.Equal(inputModel.Title, editedAd.Title);
        }

        [Fact]
        public async void UpdateAsyncShouldThrowNullReferenceExceptionWhenAdIDDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var adsRepositoty = new EfDeletableEntityRepository<Ad>(new ApplicationDbContext(options.Options));
            var categoriesRepositoty = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var countsService = new GetCountsService(categoriesRepositoty, adsRepositoty);
            var adsService = new AdsService(adsRepositoty, countsService);
            int id = 5;

            var ad = new Ad
            {
                Title = Title,
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                AddedByUserId = FirstUserId,
            };
            await adsRepositoty.AddAsync(ad);
            await adsRepositoty.SaveChangesAsync();

            var inputModel = new EditAdViewModel
            {
                Title = "This is edit title",
                Location = Location,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
            };

            // Act
            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await adsService.UpdateAsync(id, inputModel));
        }
    }
}
