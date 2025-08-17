using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated()
        {
            bool returResult = false;

            if (this.User.Identity != null)
            {
                returResult = this.User.Identity.IsAuthenticated;
            }

            return returResult;

            //if (User == null)
            //{
            //    return false;
            //}

            //if (User.Identity == null)
            //{
            //    return false;
            //}

            //return User.Identity.IsAuthenticated;
        }

        protected string? GetUserId()
        {
            string? userId = null!;

            if (this.IsUserAuthenticated())
            {

				userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); 
			}

            return userId;
        }
    }
}
