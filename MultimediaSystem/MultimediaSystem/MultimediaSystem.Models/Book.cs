using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;

namespace MultimediaSystem.Models
{
    class Book:MultimediaItem,IItem
    {
        private string author;

        public string Author
        {
            get { return this.author; }
            set 
            {
                if (value.Length<3||string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Author should be non-empty string - minimum 3 characters long");
                }
                this.author = value; 
            }
        }
        
        public Book(string id, string title, decimal price, string author, List<Genre> setOfGenres)
            :base(id,title,price,setOfGenres)
        {
            this.Author = author;

        }

        public Book(string id, string title, decimal price, string author, Genre genre)
            : base(id, title, price)
        {
            this.Author = author;
            this.SetOfGenres = new List<Genre> { genre };
        }
    }
}
