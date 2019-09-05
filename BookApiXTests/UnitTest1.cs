using System;
using Xunit;
using BookApi.Service;
using BookApi.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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



    }
}
