namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteViewModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesService.VoteAsync(model.PostId, userId, model.IsUpVote);
            var votes = this.votesService.GetVotes(model.PostId);

            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
