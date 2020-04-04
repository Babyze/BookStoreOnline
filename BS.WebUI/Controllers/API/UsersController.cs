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
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly BookUserBL BookUserBL = null;
        public UsersController()
        {
            BookUserBL = new BookUserBL();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<BookUser> Get()
        {
            return BookUserBL.GetUsers();
        }

        [HttpGet]
        [Route("{UserID}")]
        public BookUser Get(int UserID)
        {
            return BookUserBL.GetUser(UserID);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]BookUser user)
        {
            BookUser exist = BookUserBL.GetUser(user.Username);
            if(exist != null)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }
            if(!User.IsInRole("Admin"))
            {
                user.RoleId = 1;
            }
            BookUserBL.Insert(user);
            return StatusCode(HttpStatusCode.Created);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Put([FromBody]BookUser user)
        {
            BookUser currentUser = BookUserBL.GetUser(user.UserId);
            if(currentUser == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            if (User.IsInRole("Admin") || User.Identity.Name.Equals(user.Username, StringComparison.OrdinalIgnoreCase))
            {
                if(user.Password == null)
                {
                    user.Password = currentUser.Password;
                }
                if(User.Identity.Name.Equals(user.Username, StringComparison.OrdinalIgnoreCase))
                {
                    user.RoleId = 1;
                }
                BookUserBL.Update(user);
            }
            else
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
            return Ok();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult Delete([FromBody]BookUser user)
        {
            BookUser exist = BookUserBL.GetUser(user.UserId);
            if(exist == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            BookUserBL.Delete(user);
            return Ok();
        }
    }
}
