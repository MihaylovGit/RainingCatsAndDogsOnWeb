namespace RainingCatsAndDogsOnWeb.Services
{
    using System.Collections.Generic;

    using AngleSharp;

    using RainingCatsAndDogsOnWeb.Data.Models;


    public interface IAdsScraperService
    {
       List<Ad> GetData(IBrowsingContext context, int id);
    }
}
