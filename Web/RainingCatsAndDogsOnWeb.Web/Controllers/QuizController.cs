namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class QuizController : Controller
    {
        public IActionResult UnderConstruction()
        {
            return this.View();
        }
    }
}
