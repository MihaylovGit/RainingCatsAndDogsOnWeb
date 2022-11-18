using Microsoft.AspNetCore.Mvc;

namespace RainingCatsAndDogsOnWeb.Web.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
