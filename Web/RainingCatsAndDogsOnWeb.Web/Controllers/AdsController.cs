

namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class AdsController : Controller
    {
        private readonly IAdsService adsService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdsController(IAdsService adsService, UserManager<ApplicationUser> userManager)
        {
            this.adsService = adsService;
            this.userManager = userManager;
        }

        // Ads/DogAds/5
        public IActionResult ShowAllAds(int id = 1)
        {
            const int AdsPerPage = 6;

            var viewModel = new AdsListViewModel()
            {
                AdsPerPage = AdsPerPage,
                PageNumber = id,
                AdsCount = this.adsService.GetAdsCount(),
                AllAds = this.adsService.GetAllAds<AdsInListViewModel>(id, AdsPerPage),
            };

            return this.View(viewModel);
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
