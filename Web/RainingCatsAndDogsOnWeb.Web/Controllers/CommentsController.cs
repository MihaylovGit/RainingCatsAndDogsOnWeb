namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Comments;

    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;

        public CommentsController(ICommentsService commentsService, IPostsService postsService, UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.postsService = postsService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("ById", model);
            }

            var postsId = await this.postsService.GetAllPostsIds();

            if (!postsId.Contains(model.PostId))
            {
                return this.View("ById", model);
            }

            int? parentId = model.ParentId == 0 ? null : model.ParentId;
            if (parentId.HasValue)
            {
                if (!await this.commentsService.IsInPostId(parentId.Value, model.PostId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.Create(model.PostId, userId, model.Content, parentId);

            return this.RedirectToAction("ById", "Posts", new { id = model.PostId });
        }
    }
}
