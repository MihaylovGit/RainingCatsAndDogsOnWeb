namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Users;
  
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (this.User.Identity?.IsAuthenticated ?? false)
            {
                return this.RedirectToAction("AllAds", "Ads");
            }

            var model = new RegisterViewModel();

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            if (this.User.Identity?.IsAuthenticated ?? false)
            {
                return this.RedirectToAction("AllAds", "Ads");
            }

            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("AllAds", "Ads");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Invalid login");

            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            var principle = this.HttpContext.User;

            return await this.userManager.GetUserAsync(principle);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = this.Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });

            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/Ads/AllAds");

            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };

            if (remoteError != null)
            {
                this.ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                return this.View("Login", loginViewModel);
            }

            var info = await this.signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                this.ModelState.AddModelError(string.Empty, "Error loading external login information");

                return this.RedirectToAction("Login", new { ReturnUrl = returnUrl });
            }

            var signInResult = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return this.LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    var user = await this.userManager.FindByEmailAsync(email);
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        };
                    }

                    await this.userManager.AddLoginAsync(user, info);
                    await this.signInManager.SignInAsync(user, isPersistent: false);

                    return this.LocalRedirect(returnUrl);
                }

                this.ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                this.ViewBag.ErrorMessage = "Please contact your provider support";

                return this.View("Error");
            }
        }
    }
}
