using BS.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.WebUI.Areas.Admin.Controllers
{
    [RouteArea("Admin", AreaPrefix = "Admin/Genres")]
    [Authorize(Roles = "Admin")]
    public class GenresController : Controller
    {
        private readonly BookGenreBL BookGenreBL = new BookGenreBL();
        public ActionResult Index()
        {
            return View();
        }

        [Route("Add")]
        public ActionResult AddGenre()
        {
            return View();
        }

        [Route("{GenreID}")]
        public ActionResult GenreDetails(int? GenreID)
        {
            if(GenreID != null)
            {
                if (BookGenreBL.GetById((int)GenreID) != null)
                {
                    ViewBag.GenreID = GenreID;
                    return View();
                }
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}