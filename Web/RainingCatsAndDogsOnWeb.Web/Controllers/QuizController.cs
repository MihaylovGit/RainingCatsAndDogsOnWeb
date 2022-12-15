namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class QuizController : Controller
    {
        public IActionResult UnderConstruction()
        {
            return this.View();
        }
    }
}
