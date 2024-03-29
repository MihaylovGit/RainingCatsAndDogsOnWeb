﻿namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Home;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGetCountsService countsService;
        private readonly IAdsService adsService;

        public HomeController(IGetCountsService countsService, IAdsService adsService)
        {
            this.countsService = countsService;
            this.adsService = adsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var countsDto = this.countsService.GetCounts();

            var viewModel = new IndexViewModel
            {
                AdsCount = countsDto.AdsCount,
                RandomAds = await this.adsService.GetRandom<IndexPageAdViewModel>(6),
            };

            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult PageNotFound()
        {
            return this.View();
        }
    }
}
