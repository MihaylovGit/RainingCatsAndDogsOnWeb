namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(int postId, string userId, bool isUpVote);

        int GetVotes(int postId);
    }
}
