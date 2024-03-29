﻿namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ads;

    [Authorize]
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

        public IActionResult All(int id = 1)
        {
            const int AdsPerPage = 12;

            var viewModel = new AdsListViewModel()
            {
                AdsPerPage = AdsPerPage,
                PageNumber = id,
                AdsCount = this.adsService.GetAdsCount(),
                AllAds = this.adsService.GetAllAds<AdsInListViewModel>(id, AdsPerPage),
            };

            if (id > this.adsService.GetPagesCount(viewModel.AdsPerPage))
            {
                return this.View("PageNotFound");
            }

            return this.View(viewModel);
        }

        public IActionResult Mine(int id = 1)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (userId == null)
            {
                return this.View("PageNotFound");
            }

            const int AdsPerPage = 6;

            var viewModel = new AdsListViewModel()
            {
                PageNumber = id,
                AdsPerPage = AdsPerPage,
                AdsCount = this.adsService.GetUserAdsCount(userId),
                AllAds = this.adsService.GetUserAds<AdsInListViewModel>(userId),
            };

            if (id > (int)Math.Ceiling((double)viewModel.AdsCount / viewModel.AdsPerPage))
            {
                return this.View("PageNotFound");
            }

            if (viewModel.AdsCount == 0)
            {
                return this.RedirectToAction("EmptyCollection", "Ads");
            }

            return this.View(viewModel);
        }
        
        public IActionResult Create()
        {
            var viewModel = new CreateAdViewModel
            {
                CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
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
                await this.adsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images/ads");
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
            return this.View();
        }

        public IActionResult DetailsById(int id)
        {
            var ad = this.adsService.DetailsById<SingleAdViewModel>(id);
            if (ad == null)
            {
                return this.View("PageNotFound");
            }

            return this.View(ad);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = this.adsService.DetailsById<EditAdViewModel>(id);
            viewModel.Id = id;
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditAdViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Id = id;
                model.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            await this.adsService.UpdateAsync(id, model);

            return this.RedirectToAction(nameof(this.DetailsById), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.adsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.Mine));
        }

        public IActionResult EmptyCollection()
        {
            return this.View();
        }
    }
}
