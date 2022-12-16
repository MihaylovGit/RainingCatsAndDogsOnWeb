﻿namespace RainingCatsAndDogsOnWeb.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using Xunit;

    public class LikesServiceTests
    {
        [Fact]
        public async Task WhenUserLikesTwoTimesOneLikeOnlyOneLikeShouldBeCounted()
        {
            var list = new List<Like>();
            var mockRepo = new Mock<IRepository<Like>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Like>())).Callback((Like like) => list.Add(like));

            var service = new LikesService(mockRepo.Object);

            await Task.FromResult(service.SetLikeAsync(1, "1", 1));
            await Task.FromResult(service.SetLikeAsync(1, "1", 1));

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public async Task WhenTwoUsersLikeAdLikesCountShouldBeTwo()
        {
            var list = new List<Like>();
            var mockRepo = new Mock<IRepository<Like>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Like>())).Callback((Like like) => list.Add(like));

            var service = new LikesService(mockRepo.Object);

            await Task.FromResult(service.SetLikeAsync(1, "Ivan", 1));
            await Task.FromResult(service.SetLikeAsync(1, "Krisi", 1));

            Assert.Equal(2, list.Count);
        }
    }
}