using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using CodeCampLibraryDemo_Soln.Data;
using CodeCampLibraryDemo_Soln.Models;

namespace CodeCampLibraryDemo_Soln.Controllers
{
    [RoutePrefix("api/v1/books")]
    public class BooksController : ApiController
    {
        private readonly BookRepository _repository;

        public BooksController()
        {
            _repository = new BookRepository();
        }

        [Route("")]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Book> Get()
        {
            return _repository.GetBooks().ToList();
        }

        [Route("{isbn}")]
        public HttpResponseMessage Get(string isbn)
        {
            var book =  _repository.GetBook(isbn);
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, book);
        }

        [Route("{isbn}/cover")]
        [HttpGet]
        public HttpResponseMessage GetBookCover(string isbn)
        {
            var hash = "\"61934806\"";
            //var hash = "\"5577127\""; //New Hash
            var tagObject = Request.Headers.IfNoneMatch.FirstOrDefault();
            var tag = tagObject != null ? tagObject.Tag : string.Empty;
            if (!string.IsNullOrWhiteSpace(tag) && tag == hash)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }

            var result = Request.CreateResponse(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath("~/Content/images/cat.jpg");
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                Image image = Image.FromStream(fileStream);
                using (var memoryStream = new MemoryStream())
                {   
                    image.Save(memoryStream, ImageFormat.Jpeg);
                    result.Content = new ByteArrayContent(memoryStream.ToArray());
                }
            }
            
            result.Headers.ETag = new EntityTagHeaderValue(hash, true);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return result;
        }

        [Route("{isbn}")]
        public HttpResponseMessage Put(string isbn, [FromBody]Book book)
        {
            if (book == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var savedBook = _repository.GetBook(isbn);
            if (savedBook == null) return Request.CreateResponse(HttpStatusCode.NotFound);

            savedBook.Author = book.Author;
            savedBook.Price = book.Price;
            savedBook.PublishDate = book.PublishDate;
            savedBook.Title = book.Title;
            _repository.Save();

            return Request.CreateResponse(HttpStatusCode.OK, savedBook);
        }
    }
}
