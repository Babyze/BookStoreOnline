using BS.BusinessLogicLayer;
using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.WebUI.Areas.Admin.Controllers
{
    [RouteArea("Admin", AreaPrefix = "Admin/Dashboard")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly BookOrderBL BookOrderBL = new BookOrderBL();
        public DashboardController()
        {
            BookOrderBL = new BookOrderBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        [Route("Orders/{OrderId}")]
        public ActionResult Orders(int? OrderId)
        {
            if(OrderId != null)
            {
                if(BookOrderBL.GetOrder((int)OrderId) != null)
                {
                    ViewBag.OrderId = OrderId;
                    return View();
                }
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}