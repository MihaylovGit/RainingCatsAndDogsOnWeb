namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;

    public class LikesService : ILikesService
    {
        private readonly IRepository<Like> likesRepository;

        public LikesService(IRepository<Like> likesRepository)
        {
            this.likesRepository = likesRepository;
        }

        public async Task SetLikeAsync(int adid, string userId, int likesCount)
        {
            var like = await this.likesRepository.All()
                                           .FirstOrDefaultAsync(x => x.AdId == adid && x.ApplicationUserId == userId);

            if (like != null && like.ApplicationUserId == userId)
            {
                return;
            }

            if (like == null)
            {
                like = new Like
                {
                    AdId = adid,
                    ApplicationUserId = userId,
                    LikesCount = likesCount,
                };

                await this.likesRepository.AddAsync(like);
            }

            like.LikesCount++;

            await this.likesRepository.SaveChangesAsync();
        }
    }
}
