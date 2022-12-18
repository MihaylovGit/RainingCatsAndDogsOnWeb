namespace RainingCatsAndDogsOnWeb.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data;
    using RainingCatsAndDogsOnWeb.Data.Repositories;
    using RainingCatsAndDogsOnWeb.Services.Mapping;
    using Xunit;
    using Post = RainingCatsAndDogsOnWeb.Data.Models.Post;

    public class PostsServiceTests
    {
        public const string FirstUserId = "Stamat";
        public const string SecondUserId = "Stoyan";
        public const string Title = "This is a test title";
        public const string Content = "This is a test content";
        public const int CategoryId = 2;

        public class MyTestPost : IMapFrom<Post>
        {
            public string Title { get; set; }

            public string Content { get; set; }

            public string UserId { get; set; }

            public int CategoryId { get; set; }
        }

        [Fact]
        public async Task WhenUserCreatePostAsyncShouldPostsCountBecomeEqualToOne()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var postsRepositoty = new EfDeletableEntityRepository<Post>(new ApplicationDbContext(options.Options));
           
            var postsService = new PostsService(postsRepositoty);

            var inputModel = new Post
            {
                Title = Title,
                Content = Content,
                CategoryId = CategoryId,
                UserId = FirstUserId,
            };

            // Act
            int postId = await postsService.CreatePostAsync(inputModel.Title, inputModel.Content, inputModel.CategoryId, inputModel.UserId);

            // Assert
            Assert.Equal(1, postId);
        }

        [Fact]
        public async Task GetByIdShouldReturnRequiredPostIfSuchExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var postsRepositoty = new EfDeletableEntityRepository<Post>(new ApplicationDbContext(options.Options));
            int id = 1;
            var postsService = new PostsService(postsRepositoty);

            var post = new Post
            {
                Title = Title,
                Content = Content,
                CategoryId = CategoryId,
                UserId = FirstUserId,
            };

            await postsRepositoty.AddAsync(post);
            await postsRepositoty.SaveChangesAsync();
            AutoMapperConfig.RegisterMappings(typeof(MyTestPost).Assembly);

            // Act
            var postById = await postsService.GetById<MyTestPost>(id);

            // Assert
            Assert.Same(post.Content, postById.Content);
        }

        [Fact]
        public async Task GetByIdShouldReturnNullWhenPostNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var postsRepositoty = new EfDeletableEntityRepository<Post>(new ApplicationDbContext(options.Options));
            int id = 3;
            var postsService = new PostsService(postsRepositoty);

            var post = new Post
            {
                Title = Title,
                Content = Content,
                CategoryId = CategoryId,
                UserId = FirstUserId,
            };

            await postsRepositoty.AddAsync(post);
            await postsRepositoty.SaveChangesAsync();
            AutoMapperConfig.RegisterMappings(typeof(MyTestPost).Assembly);

            // Act
            var postById = await postsService.GetById<MyTestPost>(id);

            // Assert
            Assert.Null(postById);
        }

        [Fact]
        public async Task GetAllPostsIdsShouldReturnIfPostsExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var postsRepositoty = new EfDeletableEntityRepository<Post>(new ApplicationDbContext(options.Options));

            var postsService = new PostsService(postsRepositoty);

            var firstPost = new Post
            {
                Title = Title,
                Content = Content,
                CategoryId = CategoryId,
                UserId = FirstUserId,
            };

            var secondPost = new Post
            {
                Title = "This is a test post 2",
                Content = "This is a test content",
                CategoryId = CategoryId,
                UserId = FirstUserId,
            };

            // Act
            await postsRepositoty.AddAsync(firstPost);
            await postsRepositoty.AddAsync(secondPost);
            await postsRepositoty.SaveChangesAsync();
            var posts = await postsService.GetAllPostsIds();

            // Assert
            Assert.Equal(2, posts.Count());
        }

        [Fact]
        public async Task GetAllPostsIdsShouldReturnEmptyCollectionWhenNoPosts()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var postsRepositoty = new EfDeletableEntityRepository<Post>(new ApplicationDbContext(options.Options));

            var postsService = new PostsService(postsRepositoty);

            // Act
            var posts = await postsService.GetAllPostsIds();

            // Assert
            Assert.Empty(posts);
        }
    }
}
