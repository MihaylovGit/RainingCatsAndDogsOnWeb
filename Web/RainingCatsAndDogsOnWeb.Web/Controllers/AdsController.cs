namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;

    public class AdsController : Controller
    {
        private readonly IAdsService adsService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdsController(IAdsService adsService, UserManager<ApplicationUser> userManager)
        {
            this.adsService = adsService;
            this.userManager = userManager;
        }

        public IActionResult ShowAllDogAds()
        {
            return this.View();
        }

        public IActionResult ShowAllCatAds()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAdViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.adsService.CreateAsync(input, user.Id);

            return this.Redirect("PostSuccessful");
        }

        public IActionResult PostSuccessful()
        {
            return View();
        }
    }
}
