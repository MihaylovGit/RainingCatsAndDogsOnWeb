namespace RainingCatsAndDogsOnWeb.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Data.Repositories;
    using Xunit;

    public class LikesServiceTests
    {
        public const string FirstUserId = "Stamat";
        public const string SecondUserId = "Stoyan";

        [Fact]
        public async Task WhenUserLikesTwoTimesOneAdOnlyOneLikeShouldBeCounted()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoty = new EfRepository<Like>(new ApplicationDbContext(options.Options));
            var likesService = new LikesService(repositoty);

            // Act
            await likesService.SetLikeAsync(1, FirstUserId, 1);
            await likesService.SetLikeAsync(1, FirstUserId, 1);

            // Assert
            Assert.Equal(1, likesService.GetAdLikesCount(1));
        }

        [Fact]
        public async Task WhenTwoUsersLikeSameAdTwoLikeShouldBeCounted()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoty = new EfRepository<Like>(new ApplicationDbContext(options.Options));
            var likesService = new LikesService(repositoty);

            // Act
            await likesService.SetLikeAsync(1, FirstUserId, 1);
            await likesService.SetLikeAsync(1, SecondUserId, 1);
            var likesCount = likesService.GetAdLikesCount(1);

            // Assert
            Assert.Equal(2, likesCount);
        }

        [Fact]
        public async Task WhenTwoUsersLikeAdOneHundredsTimeSameAdOnlyTwoLikesShouldBeCounted()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoty = new EfRepository<Like>(new ApplicationDbContext(options.Options));
            var likesService = new LikesService(repositoty);

            // Act
            for (int i = 0; i < 100; i++)
            {
                await likesService.SetLikeAsync(1, FirstUserId, 1);
                await likesService.SetLikeAsync(1, SecondUserId, 1);
            }

            var likesCount = likesService.GetAdLikesCount(1);

            // Assert
            Assert.Equal(2, likesCount);
        }

        [Fact]
        public async Task UserLikesTwoDifferentAdsEachAdShouldHaveOneLike()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoty = new EfRepository<Like>(new ApplicationDbContext(options.Options));
            var likesService = new LikesService(repositoty);

            // Act
            await likesService.SetLikeAsync(1, FirstUserId, 1);
            await likesService.SetLikeAsync(2, SecondUserId, 1);

            var firstAdLikesCount = likesService.GetAdLikesCount(1);
            var secondAdLikesCount = likesService.GetAdLikesCount(2);

            // Assert
            Assert.Equal(1, firstAdLikesCount);
            Assert.Equal(1, secondAdLikesCount);
        }
    }
}
