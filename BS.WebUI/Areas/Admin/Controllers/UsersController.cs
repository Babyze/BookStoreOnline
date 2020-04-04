using BS.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.WebUI.Areas.Admin.Controllers
{
    [RouteArea("Admin", AreaPrefix = "Admin/Users")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly BookUserBL BookUserBL = new BookUserBL();
        public ActionResult Index()
        {
            return View();
        }
        [Route("add")]
        public ActionResult AddUser()
        {
            return View();
        }
        [Route("{UserId}")]
        public ActionResult UserDetails(int? UserId)
        {
            if (UserId != null)
            {
                if (BookUserBL.GetUser((int)UserId) != null)
                {
                    ViewBag.UserId = UserId;
                    return View();
                }
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}