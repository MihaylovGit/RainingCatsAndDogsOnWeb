namespace RainingCatsAndDogsOnWeb.Services.Data
{
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data;
    using RainingCatsAndDogsOnWeb.Data.Models;
    using RainingCatsAndDogsOnWeb.Web.ViewModels.Ad;

    public class AdsService : IAdsService
    {
        private readonly ApplicationDbContext db;

        public AdsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(CreateAdViewModel input, string userId)
        {
            var newAd = new Ad
            {
                Title = input.Title,
                Location = input.Location,
                Price = input.Price,
                Description = input.Description,
                CategoryId = input.CategoryId,
                AddedByUserId = userId,
            };

            await this.db.AddAsync(newAd);

            this.db.SaveChanges();
        }
    }
}
