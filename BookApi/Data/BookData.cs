using BookApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data
{
    public class BookData
    {

        private List<Book> _bookList = new List<Book>();
        public BookData()
        {
            _bookList.Add(new Book { id = 1, Name = "Angels and Demons", Author="Xing Ho", Price=4500.65 });
            _bookList.Add(new Book { id = 2, Name = "The matrix", Author = "Xing Ho", Price = 4500.65 });
            _bookList.Add(new Book { id = 3, Name = "FairyTail", Author = "Xing Ho", Price = 4500.65 });
           
        }
        public List<Book> GetBookList()
        {
            return _bookList;
        }

        public void Add(Book book)
        {
            _bookList.Add(book);
            
        }

        public void RemoveAt(int i)
        {
            _bookList.RemoveAt(i);
        }
    }
}
