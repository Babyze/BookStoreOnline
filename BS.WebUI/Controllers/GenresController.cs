using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.WebUI.Controllers
{
    [RoutePrefix("genres")]
    public class GenresController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            @ViewBag.GenreId = 0;
            @ViewBag.Page = 1;
            return View();
        }

        [Route("{GenreId}")]
        [Route("{GenreId}/{Page}")]
        public ActionResult BookByGenre(int? GenreId, int? Page)
        {
            @ViewBag.GenreId = GenreId == null ? 0 : GenreId;
            @ViewBag.Page = Page == null ? 1 : Page;
            return View("Index");
        }
        
    }
}