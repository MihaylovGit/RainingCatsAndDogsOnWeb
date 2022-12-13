namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;

    [Authorize]
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                PostId = postId,
                Content = content,
                ParentId = parentId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task<bool> IsInPostId(int commentId, int postId)
        {
            var commentPostId = await this.commentsRepository.All()
                                                             .Where(x => x.Id == commentId)
                                                             .Select(x => x.PostId)
                                                             .FirstOrDefaultAsync();

            return commentPostId == postId;
        }
    }
}
