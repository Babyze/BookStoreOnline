using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.WebUI.Controllers
{
    public class BooksController : Controller
    {
        [Route("Books/{BookId}")]
        public ActionResult Index(int? BookId)
        {
            if(BookId != null)
            {
                ViewBag.Bookid = BookId;
                return View();
            }
            return RedirectToAction("Error404","Errors");
        }
        [Route("Search")]
        public ActionResult Search(string BookName, int? Page)
        {
            ViewBag.BookName = BookName == null ? "" : BookName;
            ViewBag.Page = Page == null ? 1 : Page;
            return View();
        }
        [Route("Sale")]
        public ActionResult Sale(int? Page)
        {
            ViewBag.Page = Page == null ? 1 : Page;
            return View();
        }
    }
}