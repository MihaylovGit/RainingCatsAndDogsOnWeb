namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Web.ViewModels;
    
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Home;
    using RainingCatsAndDogsOnWeb.Data;
    using System.Linq;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                CategoriesCount = this.db.Categories.Count(),
                AdsCount = this.db.Ads.Count(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
