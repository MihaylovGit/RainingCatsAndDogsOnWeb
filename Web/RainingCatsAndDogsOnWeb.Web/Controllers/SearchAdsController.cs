namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class SearchAdsController : Controller
    {
        private readonly ISearchAdsService searchAdsService;

        public SearchAdsController(ISearchAdsService searchAdsService)
        {
            this.searchAdsService = searchAdsService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var ads = await this.searchAdsService.GetAllAds<AdsInListViewModel>();
            ads = ads.Where(x => x.Title.ToLower().Contains(searchString.ToLower()) ||
               x.Location.ToLower().Contains(searchString.ToLower()) || x.Description.ToLower().Contains(searchString.ToLower()));

            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString) || ads.Count() == 0)
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
