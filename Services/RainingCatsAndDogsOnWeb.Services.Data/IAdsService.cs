using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;
namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Threading.Tasks;

    public interface IAdsService
    {
        Task CreateAsync(CreateAdViewModel input, string userId);
    }
}
