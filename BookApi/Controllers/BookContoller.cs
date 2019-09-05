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
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(Service.GetBooks());
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> Get(int id)
        {
            string name = Service.GetBookName(id);
            if (name == "null")
                return NotFound("Book Not Found..!!!");
            return Ok(name);

        }

        // POST api/values
        [HttpPost]
        public ActionResult<IEnumerable<Book>> Post([FromBody] Book book)
        {
            if (Service.AddBook(book))
                return Ok();
            return UnprocessableEntity("One or more bad inputs");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Book>> Put(int id, [FromBody]Book newBook)
        {
            if (Service.ModifyBookList(id, newBook))
                return Ok(Service.GetBooks());

            return BadRequest("The Book you were looking for doesnt exist..!!!!");

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Book>> Delete(int id)
        {
            if (Service.DeleteBook(id))
                return Ok("The Requested Book was deleted");

             return NotFound("404: Book Not found");
        }
    }
}
