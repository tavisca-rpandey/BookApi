using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Model
{
    public class Book
    {
        public int id { get; set; }
        public String Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

    }
}
