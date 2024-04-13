using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioBalanceShop.Controllers
{
    public class CookieController : BaseController
    {
        [AllowAnonymous]
        public IActionResult SetCookieConsent(string consent)
        {
            if (consent == "accept")
            {
                Response.Cookies.Append("CookieConsent", "accepted", new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(365),
                    HttpOnly = true,
                    Secure = true
                });
            }
            else if (consent == "reject")
            {
                Response.Cookies.Append("CookieConsent", "rejected", new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(365),
                    HttpOnly = true,
                    Secure = true
                });

                foreach (var cookie in Request.Cookies.Keys)
                {
                    if (cookie != "CookieConsent")
                    {
                        Response.Cookies.Delete(cookie);
                    }
                }
            }

            return RedirectToAction("Index", "Home"); // Redirect to home page or any other page
        }


        public bool CheckCookieConsent()
        {
            var cookieConsent = HttpContext.Request.Cookies["CookieConsent"];

            if (cookieConsent != null && cookieConsent.ToLower() == "accepted")
            {
                return true;
            }

            return false;

        }
    }
}
