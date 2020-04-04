using BS.BusinessLogicLayer;
using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BS.WebUI.Controllers.API
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly BookOrderBL BookOrderBL = null;

        public OrdersController()
        {
            BookOrderBL = new BookOrderBL();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<BookOrder> Get()
        {
            return BookOrderBL.GetOrders();
        }

        [HttpGet]
        [Route("{OrderID}")]
        public BookOrder Get(int OrderID)
        {
            return BookOrderBL.GetOrder(OrderID);
        }

        [HttpGet]
        [Route("users/{UserId}")]
        public IEnumerable<BookOrder> GetOrdersByUser(int UserId)
        {
            return BookOrderBL.GetOrdersByUser(UserId);
        }
    }
}
