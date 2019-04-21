using Management.Data.Model;
using Management.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Management.API.Controllers.API
{
    public class BookController : ApiController
    {
        private readonly IBookLogic _bookLogic;
        public BookController(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }

        [Route("api/book")]
        [HttpPost]
        public void Create(Book book)
        {
            _bookLogic.Create(book);
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}