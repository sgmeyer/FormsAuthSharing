using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using SharingCookies.Models;

namespace SharingCookies.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var cookie = FormsAuthentication.GetAuthCookie(model.Email, false);
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var authTicket = new FormsAuthenticationTicket(
                ticket.Version,
                model.Email,
                DateTime.Now,
                DateTime.Now.AddMinutes(60),
                true,
                "");

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            cookie.Value = encryptedTicket;
            HttpContext.Response.Cookies.Add(cookie);
            return Redirect("http://localhost:44504/");
        }
    }
}