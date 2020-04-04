using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BS.WebUI.Controllers
{
    public class SecurityController : Controller
    {
        [Route("login")]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(string username, string password)
        {
            if(Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index","Home");
            }
            ViewBag.Error = "Username or password is incorrect!";
            return View();
        }

        [Route("register")]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}