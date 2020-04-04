using BS.BusinessLogicLayer;
using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace BS.WebUI.Controllers.API
{
    [RoutePrefix("api/carts")]
    public class CartsController : ApiController
    {
        private HttpSessionState session = null;
        private BookCartBL BookCartBL = null;
        public CartsController()
        {
            session = HttpContext.Current.Session;
            BookCartBL = new BookCartBL();
        }

        [HttpGet]
        public IEnumerable<BookOrderMeta> Get()
        {
            List<BookOrderMeta> carts = session["cart"] as List<BookOrderMeta>;
            return carts;
        }

        [Authorize]
        [HttpPost]
        [Route("checkout")]
        public IHttpActionResult Post()
        {
            if (session["cart"] == null)
            {
                return BadRequest();
            }
            List<BookOrderMeta> carts = session["cart"] as List<BookOrderMeta>;
            string username = User.Identity.Name;
            bool result = BookCartBL.CheckOut(username, carts);
            if (result)
            {
                session["cart"] = null;
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]BookOrderMeta book)
        {
            if(session["cart"] == null)
            {
                session["cart"] = new List<BookOrderMeta>();
            }
            bool result;
            List<BookOrderMeta> carts = session["cart"] as List<BookOrderMeta>;
            if(BookCartBL.ItemExist(carts, book.BookId))
            {
                result = BookCartBL.UpdateItem(carts, book.BookId);
            } else
            {
                result = BookCartBL.InsertItem(carts, book.BookId);
            }
            if(result)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody]BookOrderMeta book)
        {
            if (session["cart"] == null)
            {
                return BadRequest();
            }
            List<BookOrderMeta> carts = session["cart"] as List<BookOrderMeta>;
            bool result = BookCartBL.DeleteItem(carts, book.BookId);
            if(result)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }
    }
}
