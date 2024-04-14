using BioBalanceShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using static BioBalanceShop.Core.Constants.CookieConstants;
using BioBalanceShop.Controllers;

namespace BioBalanceShop.Attributes
{
    public class RequiresCookieConsent : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ICookieService? cookieService = context.HttpContext.RequestServices.GetService<ICookieService>();

            if (cookieService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (cookieService != null
                && cookieService.CookieConsentGiven(context.HttpContext.Request.Cookies[ConsentCookie]) == false)
            {
                context.Result = new RedirectToActionResult(nameof(CookieBannerController.UpdateCookieConsent), "CookieBanner", null);
            }
        }
    }
}
