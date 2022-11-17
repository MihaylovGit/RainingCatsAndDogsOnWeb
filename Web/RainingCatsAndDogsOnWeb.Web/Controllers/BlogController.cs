using Microsoft.AspNetCore.Mvc;

namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Default()
        {
            return this.View();
        }
    }
}
