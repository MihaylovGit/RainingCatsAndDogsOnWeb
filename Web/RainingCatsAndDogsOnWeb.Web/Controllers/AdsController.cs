namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;

    public class AdsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateAdViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // TODO: Create ad using service method
            // TODO: Redirect to required ad info page!!!
            return this.Redirect("/");
        }
    }
}
