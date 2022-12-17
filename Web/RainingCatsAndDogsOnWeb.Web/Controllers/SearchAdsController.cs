namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    [Authorize]
    public class SearchAdsController : Controller
    {
        private readonly ISearchAdsService searchAdsService;

        public SearchAdsController(ISearchAdsService searchAdsService)
        {
            this.searchAdsService = searchAdsService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
            {
                return this.View(nameof(this.NoResultsFound));
            }

            var ads = await this.searchAdsService.GetAllMatchedAds<AdsInListViewModel>(searchString);

            if (!ads.Any())
            {
                return this.View(nameof(this.NoResultsFound));
            }

            return this.View(ads);
        }

        public IActionResult NoResultsFound()
        {
            return this.View();
        }
    }
}
