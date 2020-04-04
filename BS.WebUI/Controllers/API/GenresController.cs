using BS.BusinessLogicLayer;
using BS.BusinessObjectLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BS.WebUI.Controllers.API
{
    [RoutePrefix("api/genres")]
    public class GenresController : ApiController
    {
        private readonly BookGenreBL GenreBL = null;
        public GenresController()
        {
            GenreBL = new BookGenreBL();
        }
        [HttpGet]
        public IEnumerable<BookGenre> Get()
        {
            return GenreBL.GetAll();
        }

        [HttpGet]
        [Route("{GenreId}")]
        public BookGenre Get(int GenreId)
        {
            return GenreBL.GetById(GenreId);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Post([FromBody]BookGenre genre)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not valid genre name");
            }
            GenreBL.InsertGenre(genre);
            return Created("/api/genres", HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Put([FromBody]BookGenre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid genre");
            }
            BookGenre validGenre = GenreBL.GetById(genre.GenreId);
            if(validGenre == null)
            {
                return BadRequest("Not valid genre ID");
            }
            GenreBL.UpdateGenre(genre);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete([FromBody]BookGenre genre)
        {
            BookGenre validGenre = GenreBL.GetById(genre.GenreId);
            if(validGenre == null)
            {
                return BadRequest("Not valid genre ID");
            }
            GenreBL.DeleteGenre(genre);
            return Ok();
        }
    }
}
