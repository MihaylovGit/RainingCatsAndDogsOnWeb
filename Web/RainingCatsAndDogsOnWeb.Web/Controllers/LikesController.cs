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
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;
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
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            string userId = user.Id;

            await this.likesService.SetLikeAsync(model.AdId, userId, model.LikesCount);

            return new LikeResponseViewModel { LikesCount = model.LikesCount };
        }
    }
}
