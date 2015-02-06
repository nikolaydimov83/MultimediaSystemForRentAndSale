using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;

namespace MultimediaSystem.Models
{
    class Movie:MultimediaItem,IItem
    {
        private int lenght;

        public int Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }
        
        public Movie(string id, string title, decimal price, int lenght,List<Genre> setOfGenres)
            :base(id,title,price,setOfGenres)
        {
            this.Lenght = lenght;
        }

        public Movie(string id, string title, decimal price, int lenght, Genre genre)
            : base(id, title, price)
        {
            this.Lenght = lenght;
            this.SetOfGenres = new List<Genre> { genre };
        }
    }
}
