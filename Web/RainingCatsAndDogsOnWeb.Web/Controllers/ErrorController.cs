namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    this.ViewBag.ErrorMessage = "Sorry, the page you’re looking for doesn’t exist.";
                    break;
            }

            return this.View("PageNotFound");
        }
    }
}
