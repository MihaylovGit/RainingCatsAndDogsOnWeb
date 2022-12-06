namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Common;
    using RainingCatsAndDogsOnWeb.Services;
    using RainingCatsAndDogsOnWeb.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdsCollectorController : BaseController
    {
        public const int Count = 24;

        private readonly IAdsScraperService adsScraperService;

        public AdsCollectorController(IAdsScraperService adsScraperService)
        {
            this.adsScraperService = adsScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> LoadAds()
        {
            if (this.User.IsInRole("Administrator"))
            {
                await this.adsScraperService.PopulateDbWithAds(Count);

                return this.RedirectToAction("AllAds", "Ads");
            }
            return this.View("Unauthorized");
        }
    }
}
