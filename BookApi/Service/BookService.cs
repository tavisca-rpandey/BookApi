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
            return author.All(Char.IsLetter);
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
            return name.All(Char.IsLetter);
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

        private dynamic GetResultObject()
        {
            WebClient client = new WebClient();
            string baseUri = "C:\\Users\\rpandey\\source\\repos\\BookApi\\BookApi\\response.json";
            string jsonType = File.ReadAllText(baseUri);
            var resultString = client.DownloadString(baseUri);
            return JsonConvert.DeserializeObject(jsonType);
        }


        public string GetBooks()
        {
            dynamic resultObject = GetResultObject();

            List <Book> bookList = bookData.GetBookList();
            resultObject.response.model = JsonConvert.SerializeObject(bookList);
            resultObject.response.error = "null";
            return JsonConvert.SerializeObject(resultObject);
            
        }

        public string GetBookName(int id)
        {
            var name = "";
            foreach (var book in bookData.GetBookList())
            {
                if (book.id == id)
                {
                    name = book.Name;
                    break;
                }
            }
            dynamic resultObject = GetResultObject();
            if (name == "")
            {
                resultObject.response.error.status = 404;
                resultObject.response.error.msg = "The given ID doesnt exist";
            }
            else
            {
                resultObject.response.model = name;
                resultObject.response.error = null;
            }
               
          
            return JsonConvert.SerializeObject(resultObject);

        }

        public string AddBook(Book book)
        {
            if (Validity.isValidBook(book))
            {
                bookData.Add(book);
                return GetBooks();
            }
            else
            {
                dynamic resultObject = GetResultObject();
                resultObject.response.model = "null";
                resultObject.response.error.status = 400;
                resultObject.response.error.msg = "Some information was wrongly enterd";

                return JsonConvert.SerializeObject(resultObject);
            }
            
        }

        public string ModifyBookList(int id, Book newBook)
        {
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
                    }
                }
                return GetBooks();
            }
            else
            {
                dynamic resultObject = GetResultObject();
                resultObject.response.model = "null";
                resultObject.response.error.status =400;
                resultObject.response.error.msg = "Some information was wrongly enterd";

                return JsonConvert.SerializeObject(resultObject);
            }

        }

        public string DeleteBook(int id)
        {
            var lis = bookData.GetBookList();
            for (int i = 0; i < lis.Count() ; i++)
                if (lis[i].id == id)
                    bookData.RemoveAt(i);

            return GetBooks();
        }


    }
}
