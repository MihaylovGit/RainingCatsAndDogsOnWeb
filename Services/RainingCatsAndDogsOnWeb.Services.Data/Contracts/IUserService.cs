namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using RainingCatsAndDogsOnWeb.Data.Models;

    public interface IUserService
    {
        public ApplicationUser GetCurrentUser();
    }
}
