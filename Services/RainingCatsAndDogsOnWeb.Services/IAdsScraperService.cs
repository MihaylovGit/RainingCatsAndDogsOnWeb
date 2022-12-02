namespace RainingCatsAndDogsOnWeb.Services
{
    using System.Threading.Tasks;

    public interface IAdsScraperService
    {
       Task PopulateDbWithAds(int count);
    }
}
