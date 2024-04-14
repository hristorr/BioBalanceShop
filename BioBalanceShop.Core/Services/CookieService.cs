using BioBalanceShop.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBalanceShop.Core.Models.Cart;
using static BioBalanceShop.Core.Constants.CookieConstants;
using BioBalanceShop.Core.Models.Payment;

namespace BioBalanceShop.Core.Services
{
    public class CookieService : ICookieService
    {
        public void SetCartCookie(IResponseCookies httpResponse, CartCookieModel cart)
        {
            string cartJson = JsonConvert.SerializeObject(cart);
            httpResponse.Append(ShoppingCartCookie, cartJson, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true
            });

        }

        public CartCookieModel GetOrCreateCartCookie(string? cartCookie)
        {
            CartCookieModel cart;

            if (string.IsNullOrEmpty(cartCookie))
            {
                cart = new CartCookieModel();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<CartCookieModel>(cartCookie);
            }

            return cart;
        }


        public void RemoveCookie(IResponseCookies httpResponse, string cookie)
        {
            httpResponse.Append(cookie, "", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            });
        }

        public void SaveOrderInfoInCookie(IResponseCookies httpResponse, PaymentCheckoutPostModel model)
        {
            string orderInfo = JsonConvert.SerializeObject(model);
            httpResponse.Append(OrderInfoCookie, orderInfo, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true
            });
        }

        public PaymentCheckoutPostModel GetOrderInfoFromCookie(string? orderCookie)
        {
            PaymentCheckoutPostModel orderInfo;

            if (string.IsNullOrEmpty(orderCookie))
            {
                orderInfo = null;
            }
            else
            {
                orderInfo = JsonConvert.DeserializeObject<PaymentCheckoutPostModel>(orderCookie);
            }

            return orderInfo;
        }

        public void SetConsentCookie(IResponseCookies httpResponse, string consentStatus)
        {
            httpResponse.Append(ConsentCookie, consentStatus, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(365),
                HttpOnly = true,
                Secure = true
            });
        }

        public bool CookieConsentGiven(string? cookieConsent)
        {
            if (cookieConsent != null && cookieConsent.ToLower() == "accepted")
            {
                return true;
            }

            return false;
        }
    }
}
