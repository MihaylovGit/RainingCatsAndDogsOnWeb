namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Likes;

    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : Controller
    {
        private readonly ILikesService likesService;
        private readonly UserManager<ApplicationUser> userManager;

        public LikesController(ILikesService likesService, UserManager<ApplicationUser> userManager)
        {
            this.likesService = likesService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LikeResponseViewModel>> Like(LikeViewModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.likesService.SetLikeAsync(model.AdId, userId, model.LikesCount);

            var currentAdLikesCount = this.likesService.GetAdLikesCount(model.AdId);

            return new LikeResponseViewModel { LikesCount = currentAdLikesCount };
        }
    }
}
