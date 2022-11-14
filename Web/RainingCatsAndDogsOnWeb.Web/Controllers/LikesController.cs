namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Likes;

    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : BaseController
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
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<PostLikeResponseViewModel>> Like(PostLikeViewModel model)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = user.Id;
            var adsLikedByUser = user.Likes.Select(x => x.LikesCount).ToList();

            if (adsLikedByUser.Contains(model.AdId))
            {
                return this.View(model);
            }

            await this.likesService.SetLikeAsync(model.AdId, userId, model.LikesCount);

            return new PostLikeResponseViewModel { LikesCount = model.LikesCount };
        }
    }
}
