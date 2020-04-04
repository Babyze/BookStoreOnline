using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.WebUI.Controllers
{
    [RoutePrefix("cart")]
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("checkout")]
        [Authorize]
        [HttpPost]
        public ActionResult CheckOut()
        {
            return View();
        }
    }
}