namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services;
   
    public class AdsCollectorController : BaseController
    {
        private readonly IAdsScraperService adsScraperService;

        public AdsCollectorController(IAdsScraperService adsScraperService)
        {
            this.adsScraperService = adsScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> LoadAds()
        {
            await this.adsScraperService.PopulateDbWithAds(24);

            return this.RedirectToAction("AllAds", "Ads");
        }
    }
}
