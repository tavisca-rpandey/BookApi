using System;
using Xunit;
using BookApi.Service;
using BookApi.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using BookApi.Data;
using System.Linq;

namespace BookApiXTests
{
    public class UnitTest1
    {
        [Fact]
        public void ValidBookIsValidTest()
        {
            Book book = new Book { id = 1, Name = "AngelsandDemons", Author = "XingHo", Price = 4500.65 };
            Assert.True(new Validation().isValidBook(book));
        }

        [Fact]
        public void InValidBookIsInValidTest()
        {
            Book book = new Book { id = 1, Name = "Angels23and*&Demons", Author = "Xing)&&*8Ho", Price = 4500.65 };
            Assert.False(new Validation().isValidBook(book));
        }

        [Fact]
        public void AreAllBooksReturned()
        {
            BookData book = new BookData();
            BookService serv = new BookService();

            Assert.Equal(3,serv.GetBooks().Count());
        }
        [Fact]
        public void IsTheCorrectBookReturned()
        {
            BookData book = new BookData();
            BookService serv = new BookService();

            Assert.Equal(book._bookList[0].Name, serv.GetBookName(1));
        }

        [Fact]
        public void IsNewBookAdded()
        {
            Book book = new Book { id = 1, Name = "AngelsandDemons", Author = "XingHo", Price = 4500.65 };
            BookService serv = new BookService();
            serv.AddBook(book);

            Assert.Equal(4, serv.GetBooks().Count());

        }

        [Fact]
        public void IsBookDeleted()
        {
            BookService serv = new BookService();
            serv.DeleteBook(1);

            Assert.Equal(2, serv.GetBooks().Count());
        }
    }
}
