namespace RainingCatsAndDogsOnWeb.Services.Data.Tests
{
    using Moq;
    using RainingCatsAndDogsOnWeb.Services.Data.Contracts;
    using RainingCatsAndDogsOnWeb.Services.Data.Models;
    using RainingCatsAndDogsOnWeb.Web.Controllers;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void TestIndexViewModelFromIndexForm()
        {
            var mockServiceOne = new Mock<IGetCountsService>();
            var mockServiceTwo = new Mock<IAdsService>();
            var countDto = new CountsDto
            {
                AdsCount = 1,
                CategoriesCount = 2,
            };

            var viewModel = 

            mockServiceOne.Setup(x => x.GetCounts()).Returns(countDto);

            var controller = new HomeController(mockServiceOne.Object, mockServiceTwo.Object);
        }
    }
}
