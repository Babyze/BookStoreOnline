using BS.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BS.WebUI.Controllers
{
    [Authorize]
    [RoutePrefix("Profile")]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserId = new BookUserBL().GetUser(User.Identity.Name).UserId;
            return View();
        }
        [Route("orders/{OrderId}")]
        public ActionResult Orders(int OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
        [Route("password")]
        public ActionResult ChangePassword()
        {
            ViewBag.UserId = new BookUserBL().GetUser(User.Identity.Name).UserId;
            ViewBag.Username = User.Identity.Name;
            return View();
        }
        [Route("logout")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}