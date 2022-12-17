namespace RainingCatsAndDogsOnWeb.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Data.Repositories;
    using RainingCatsAndDogsOnWeb.Services.Mapping;

    using Xunit;

    public class CommentsServiceTests
    {
        public const string FirstUserId = "Stamat";
        public const string SecondUserId = "Stoyan";
        public const int FirstCommentPostId = 1;
        public const string FirstCommentContent = "This is a first test comment content";

        public const int SecondCommentPostId = 2;
        public const int SecondCommentParentId = 1;
        public const string SecondCommentContent = "This is a second comment content";

        public class MyTestComment : IMapFrom<Comment>
        {
            public int PostId { get; set; }

            public int? ParentId { get; set; }

            public string Content { get; set; }
          
            public string UserId { get; set; }
        }

        [Fact]
        public async Task CreateShouldCreateComment()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var commentsRepositoty = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));

            var commentsService = new CommentsService(commentsRepositoty);

            // Act
            await commentsService.Create(FirstCommentPostId, FirstUserId, FirstCommentContent, null);

            var comments = await commentsRepositoty.All().ToListAsync();

            // Assert
            Assert.Single(comments);
            Assert.Contains(FirstCommentContent, comments[0].Content);
        }

        [Fact]
        public async Task IsInPostIdShouldReturnTrueWhenPostCommentIDMatchesPostID()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var commentsRepositoty = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));
            var commentsService = new CommentsService(commentsRepositoty);

            var firstComment = new Comment
            {
                PostId = FirstCommentPostId,
                UserId = FirstUserId,
                Content = FirstCommentContent,
                ParentId = null,
            };

            var secondComment = new Comment
            {
                PostId = SecondCommentPostId,
                UserId = SecondUserId,
                Content = SecondCommentContent,
                ParentId = SecondCommentParentId,
            };

            // Act
            await commentsRepositoty.AddAsync(firstComment);
            await commentsRepositoty.AddAsync(secondComment);
            await commentsRepositoty.SaveChangesAsync();

            var result = await commentsService.IsInPostId(1, FirstCommentPostId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsInPostIdShouldReturnFalseWhenPostCommentIDDoesNotMatchPostID()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var commentsRepositoty = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));
            var commentsService = new CommentsService(commentsRepositoty);

            var firstComment = new Comment
            {
                PostId = FirstCommentPostId,
                UserId = FirstUserId,
                Content = FirstCommentContent,
                ParentId = null,
            };

            var secondComment = new Comment
            {
                PostId = SecondCommentPostId,
                UserId = SecondUserId,
                Content = SecondCommentContent,
                ParentId = SecondCommentParentId,
            };

            // Act
            await commentsRepositoty.AddAsync(firstComment);
            await commentsRepositoty.AddAsync(secondComment);
            await commentsRepositoty.SaveChangesAsync();

            var result = await commentsService.IsInPostId(1, SecondCommentPostId);

            // Assert
            Assert.False(result);
        }
    }
}
        
           
