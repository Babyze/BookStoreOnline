using BS.BusinessLogicLayer;
using BS.BusinessObjectLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
namespace BS.WebUI.Controllers.API
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        // GET: Book
        private readonly BookBL BookBL = null;

        public BooksController()
        {
            BookBL = new BookBL();
        }

        [HttpGet]
        [Route("{BookId}")]
        public Book Get(int BookId)
        {
            return BookBL.GetBook(BookId);
        }

        [HttpGet]
        public IEnumerable<Book> Get([FromUri]PagingParameter pagingParameter)
        {
            BookPagedListBL BookPagedList = BookBL.GetAll(pagingParameter);
            var pagingMetaData = BookPagedList.PagingMetaData();
            HttpContext.Current.Response.Headers.Add("X-Paging", JsonConvert.SerializeObject(pagingMetaData));
            return BookPagedList.GetBookPagedList();
        }

        [HttpGet]
        [Route("sale")]
        public IHttpActionResult GetSale([FromUri]PagingParameter pagingParameter)
        {
            if(pagingParameter != null)
            {
                BookPagedListBL BookPagedList = BookBL.GetSaleBooks(pagingParameter);
                var pagingMetaData = BookPagedList.PagingMetaData();
                HttpContext.Current.Response.Headers.Add("X-Paging", JsonConvert.SerializeObject(pagingMetaData));
                return Ok(BookPagedList.GetSaleBooks());
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("genres/{GenreId}")]
        public IEnumerable<Book> Get(int GenreId, [FromUri]PagingParameter pagingParameter)
        {
            BookPagedListBL BookPagedList = BookBL.GetBookByGenre(GenreId, pagingParameter);
            var pagingMetaData = BookPagedList.PagingMetaData();
            HttpContext.Current.Response.Headers.Add("X-Paging", JsonConvert.SerializeObject(pagingMetaData));
            return BookPagedList.GetBookByGenrePagedList();
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<Book> Get(string BookName, [FromUri]PagingParameter pagingParameter)
        {
            BookPagedListBL BookPagedList = BookBL.GetBooksByName(BookName, pagingParameter);
            var pagingMetaData = BookPagedList.PagingMetaData();
            HttpContext.Current.Response.Headers.Add("X-Paging", JsonConvert.SerializeObject(pagingMetaData));
            return BookPagedList.GetBookPagedList(BookName);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string folder = "/Images/Uploads/";
            var root = HttpContext.Current.Server.MapPath("~" + folder);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                Book book = new Book()
                {
                    BookName = provider.FormData["BookName"],
                    BookDescription = provider.FormData["BookDescription"],
                    BookPrice = decimal.Parse(provider.FormData["BookPrice"]),
                    BookDiscount = int.Parse(provider.FormData["BookDiscount"]),
                    GenreId = int.Parse(provider.FormData["GenreId"])
                };
                Book BookInData = BookBL.InsertBook(book);
                if(provider.FileData.Count > 0)
                {
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        var name = file.Headers.ContentDisposition.FileName;
                        name = name.Trim('"');
                        if (name.Length > 0)
                        {
                            var localFileName = file.LocalFileName;
                            name = BookInData.BookId.ToString() + name.Substring(name.IndexOf("."));
                            var filePath = Path.Combine(root, name);
                            File.Delete(filePath);
                            File.Move(localFileName, filePath);
                            BookInData.BookImage = folder + name;
                        }
                    }
                } else
                {
                    BookInData.BookImage = folder + "default.jpg";
                }
                BookBL.UpdateBook(BookInData);
            } catch(Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Put()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string folder = "/Images/Uploads/";
            var root = HttpContext.Current.Server.MapPath("~" + folder);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                Book book = new Book()
                {
                    BookId = int.Parse(provider.FormData["BookId"]),
                    BookName = provider.FormData["BookName"],
                    BookDescription = provider.FormData["BookDescription"],
                    BookPrice = decimal.Parse(provider.FormData["BookPrice"]),
                    BookDiscount = int.Parse(provider.FormData["BookDiscount"]),
                    GenreId = int.Parse(provider.FormData["GenreId"])
                };
                if (provider.FileData.Count > 0)
                {
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        var name = file.Headers.ContentDisposition.FileName;
                        name = name.Trim('"');
                        if (name.Length > 0)
                        {
                            var localFileName = file.LocalFileName;
                            name = book.BookId.ToString() + name.Substring(name.IndexOf("."));
                            var filePath = Path.Combine(root, name);
                            File.Delete(filePath);
                            File.Move(localFileName, filePath);
                            book.BookImage = folder + name;
                        }
                    }
                }
                BookBL.UpdateBook(book);
            }
            catch (Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }
            return Ok();
        }


        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete([FromBody]Book book)
        {
            Book currentBook = BookBL.GetBook(book.BookId);
            if(currentBook == null)
            {
                return BadRequest("Not valid book id");
            }
            var imageName = currentBook.BookImage.Substring(currentBook.BookImage.LastIndexOf('/') + 1);
            if(!imageName.Equals("default.jpg"))
            {
                var root = HttpContext.Current.Server.MapPath("~/Images/Uploads/");
                File.Delete(Path.Combine(root, imageName));
            }
            BookBL.DeleteBook(currentBook);
            return Ok();
        }
    }
}