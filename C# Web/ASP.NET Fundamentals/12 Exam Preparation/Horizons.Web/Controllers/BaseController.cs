using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Horizons.Web.Controllers
{

    [Authorize]
    public abstract class BaseController : Controller
    {

        protected bool IsAuthenticate()
        {
            bool? isAuthenticate = this.User.Identity?.IsAuthenticated;
            if (isAuthenticate == null)
            {
                return false;
            }

            return isAuthenticate.Value;
        }

        protected string? GetUserId()
        {
            if (this.IsAuthenticate() == false)
            {
                return null;
            }

            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
