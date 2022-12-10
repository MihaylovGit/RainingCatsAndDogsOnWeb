namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Common;
    using RainingCatsAndDogsOnWeb.Services;
    using RainingCatsAndDogsOnWeb.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdsCollectorController : Controller
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
        public async Task<IActionResult> LoadAds()
        {
            await this.adsScraperService.PopulateDbWithAds(Count);

            return this.RedirectToAction("AllAds", "Ads");
        }
    }
}
