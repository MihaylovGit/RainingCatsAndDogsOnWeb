namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Comments;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("ById", model);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.Create(model.PostId, userId, model.Content);

            return this.RedirectToAction("ById", "Posts", new { id = model.PostId });
        }
    }
}
