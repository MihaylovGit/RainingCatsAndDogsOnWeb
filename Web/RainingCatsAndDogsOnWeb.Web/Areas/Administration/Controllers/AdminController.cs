namespace RainingCatsAndDogsOnWeb.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Web.Areas.Administration.Models;

    //[Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                ApplicationRole applicationRole = new ApplicationRole
                {
                    Name = model.RoleName,
                };

                var result = await this.roleManager.CreateAsync(applicationRole);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task CreateAdminRole()
        {
            var roleExists = await this.roleManager.RoleExistsAsync("Administrator");
            var user = await this.userManager.FindByEmailAsync("admin@gmail.com");

            if (!roleExists || user == null)
            {
                if (!roleExists)
                {
                    var role = new ApplicationRole();
                    role.Name = "Administrator";

                    await this.roleManager.CreateAsync(role);
                }

                if (user == null)
                {
                    user = new ApplicationUser();
                    user.UserName = "admin@gmail.com";
                    user.Email = "admin@gmail.com";

                    string userPassword = "1q2w3e4r";

                    IdentityResult checkUser = await this.userManager.CreateAsync(user, userPassword);

                    if (checkUser.Succeeded)
                    {
                        var result = await this.userManager.AddToRoleAsync(user, "Administrator");
                    }
                }
                else
                {
                    await this.userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }
    }
}
