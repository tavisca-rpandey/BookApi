using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApi.Model;
using BookApi.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookApi.Controllers
{
    [Route("api/book")]
    public class BookContoller : Controller
    {
        BookService Service = new BookService();
        
        // GET: api/book
        [HttpGet]
        public string Get()
        {
            return Service.GetBooks();
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Service.GetBookName(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] Book book)
        {
            return Service.AddBook(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Book newBook)
        {
            return Service.ModifyBookList(id, newBook);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return Service.DeleteBook(id);
        }
    }
}
