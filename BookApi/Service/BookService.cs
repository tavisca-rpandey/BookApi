using BookApi.Data;
using BookApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookApi.Service
{
    public class Validation
    {
        public bool isValidBook(Book book)
        {
            if (IdIsValid(book.id) && NameIsValid(book.Name) && PriceIsValid(book.Price) && AuthorIsValid(book.Author))
                return true;
            else
                return false;
        }

        private bool AuthorIsValid(string author)
        {
            var ans = author.All(Char.IsLetter);
            return ans;
        }

        private bool PriceIsValid(double price)
        {
            if (price < 0)
                return false;
            else
                return true;

        }

        private bool NameIsValid(string name)
        {
            var ans = name.All(Char.IsLetter);
            return ans;
        }

        private bool IdIsValid(int id)
        {
            if (id > 0)
                return true;
            else
                return false;
             
        }
    }



    public class BookService
    {
        BookData bookData = new BookData();
        Validation Validity = new Validation();

        //private dynamic GetResultObject()
        //{
        //    WebClient client = new WebClient();
        //    string baseUri = "C:\\Users\\rpandey\\source\\repos\\BookApi\\BookApi\\response.json";
        //    string jsonType = File.ReadAllText(baseUri);
        //    var resultString = client.DownloadString(baseUri);
        //    return JsonConvert.DeserializeObject(jsonType);
        //}


        public List<Book> GetBooks()
        {
            //dynamic resultObject = GetResultObject();

            List <Book> bookList = bookData.GetBookList();
            //resultObject.response.model = JsonConvert.SerializeObject(bookList);
            //resultObject.response.error = "null";
            //return JsonConvert.SerializeObject(resultObject);
            return bookList;


        }

        public string GetBookName(int id)
        {
            string name="null";
            foreach (var book in bookData.GetBookList())
            {
                if (book.id == id)
                {
                    name = book.Name;
                    break;
                }
            }
            return name;
            //dynamic resultObject = GetResultObject();
            //if (name == "")
            //{
            //    resultObject.response.error.status = 404;
            //    resultObject.response.error.msg = "The given ID doesnt exist";
            //}
            //else
            //{
            //    resultObject.response.model = name;
            //    resultObject.response.error = null;
            //}
            //return JsonConvert.SerializeObject(resultObject);

        }

        public bool AddBook(Book book)
        {
            if (Validity.isValidBook(book))
            {
                bookData.Add(book);
                return true;// GetBooks();
            }
            else
            {
                return false;
            }
            
        }

        public bool ModifyBookList(int id, Book newBook)
        {
            var updated = false;
            if (Validity.isValidBook(newBook))
            {
                foreach (var book in bookData.GetBookList())
                {
                    if (book.id == id)
                    {
                        book.Name = newBook.Name;
                        book.id = newBook.id;
                        book.Author = newBook.Author;
                        book.Price = newBook.Price;
                        updated = true;
                    }
                }
                
            }

            return updated;
            //else
            //{
            //    dynamic resultObject = GetResultObject();
            //    resultObject.response.model = "null";
            //    resultObject.response.error.status = 400;
            //    resultObject.response.error.msg = "Some information was wrongly enterd";

            //    return JsonConvert.SerializeObject(resultObject);

            //}

        }

        public bool DeleteBook(int id)
        {
            var del = false;
            var lis = bookData.GetBookList();
            for (int i = 0; i < lis.Count(); i++)
                if (lis[i].id == id)
                {
                    bookData.RemoveAt(i);
                    del = true;
                }

            return del;// GetBooks();
        }


    }
}
