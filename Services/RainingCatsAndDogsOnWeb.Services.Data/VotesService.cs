namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Common.Repositories;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public int GetVotes(int postId)
        {
            var votes = this.votesRepository.All().Where(x => x.PostId == postId).Sum(x => (int)x.Type);

            return votes;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.votesRepository.All().FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    Type = isUpVote ? VoteType.UpVote: VoteType.DownVote,
                    PostId = postId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
