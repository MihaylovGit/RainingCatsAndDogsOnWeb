namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    public class UsersService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
           return await this.userManager.GetUserAsync(this.HttpContext.User);
        }
    }
}
