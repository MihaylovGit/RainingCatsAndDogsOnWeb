namespace RainingCatsAndDogsOnWeb.Web.Areas.Administration.Controllers
{
    using RainingCatsAndDogsOnWeb.Common;

    using RainingCatsAndDogsOnWeb.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
