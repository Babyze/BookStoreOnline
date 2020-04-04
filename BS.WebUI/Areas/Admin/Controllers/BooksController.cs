using BS.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.WebUI.Areas.Admin.Controllers
{
    [RouteArea("Admin", AreaPrefix = "Admin/Books")]
    [Authorize(Roles = "Admin")]
    public class BooksController : Controller
    {
        private readonly BookBL BookBL = new BookBL();
        public ActionResult Index()
        {
            return View();
        }
        [Route("Add")]
        public ActionResult AddBook() {
            return View();
        }
        [Route("{BookId}")]
        public ActionResult BookDetails(int? BookId)
        {
            if (BookId != null)
            {
                if (BookBL.GetBook((int)BookId) != null)
                {
                    ViewBag.BookId = BookId;
                    return View();
                }
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}