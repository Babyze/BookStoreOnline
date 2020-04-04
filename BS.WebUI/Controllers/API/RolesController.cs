using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BS.BusinessLogicLayer;

namespace BS.WebUI.Controllers.API
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/roles")]
    public class RolesController : ApiController
    {
        private readonly BookRoleBL BookRoleBL = null;

        public RolesController()
        {
            BookRoleBL = new BookRoleBL();
        }

        [HttpGet]
        public IEnumerable<BookRole> Get()
        {
            return BookRoleBL.GetRole();
        }

        [HttpGet]
        [Route("{RoleId}")]
        public BookRole Get(int RoleId)
        {
            return BookRoleBL.GetRole(RoleId);
        }
    }
}
