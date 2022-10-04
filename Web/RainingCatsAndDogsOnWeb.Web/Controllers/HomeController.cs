namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Diagnostics;

    using RainingCatsAndDogsOnWeb.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            return this.View();
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
