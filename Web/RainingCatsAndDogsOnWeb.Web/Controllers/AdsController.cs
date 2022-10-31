namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Common;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    public class AdsController : Controller
    {
        private readonly IAdsService adsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;
        private readonly ICategoriesService categoriesService;

        public AdsController(ICategoriesService categoriesService, IAdsService adsService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.adsService = adsService;
            this.userManager = userManager;
            this.environment = environment;
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

        public IActionResult ShowMyAds(string userId)
        {
            const int AdsPerPage = 6;

            var viewModel = new AdsListViewModel()
            {
                AdsPerPage = AdsPerPage,
                AdsCount = this.adsService.GetUserAdsCount(userId),
                AllAds = this.adsService.GetUserAds<AdsInListViewModel>(userId),
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
            var viewModel = new CreateAdViewModel
            {
                CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAdViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.adsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("PostSuccessful");
        }

        public IActionResult PostSuccessful()
        {
            return View();
        }

        [Authorize]
        public IActionResult DetailsById(int id)
        {
            var ad = this.adsService.DetailsById<SingleAdViewModel>(id);

            return this.View(ad);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var viewModel = this.adsService.DetailsById<EditAdViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditAdViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            await this.adsService.UpdateAsync(id, model);

            return this.RedirectToAction(nameof(this.DetailsById), new { id });
        }
    }
}
