namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    using RainingCatsAndDogsOnWeb.Services.Data.Models;

    public interface IGetCountsService
    {
        CountsDto GetCounts();
    }
}
