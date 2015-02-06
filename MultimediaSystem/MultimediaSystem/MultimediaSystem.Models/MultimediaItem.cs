using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;

namespace MultimediaSystem.Models
{
    public abstract class MultimediaItem:IItem
    {
        private string id;
        private string title;
        private decimal price;
        private List<Genre> setOfGenres;

        protected MultimediaItem(string id, string title, decimal price, List<Genre> setOfGenres)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.SetOfGenres = setOfGenres;
        }

        protected MultimediaItem(string id, string title, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (string.IsNullOrEmpty(value)||value.Length<4)
                {
                    throw new ArgumentException("Id cannot be empty or less than 4 symbols long");
                }
                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be empty");
                }
                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
               return this.price;
            }
            set
            {
                if (value <0)
                {
                    throw new ArgumentException("Price cannot be below 0");
                }
                this.price = value;
            }
        }

        public List<Genre> SetOfGenres
        {
            get
            {
                return this.setOfGenres;
            }
            set
            {
                this.setOfGenres = value; 
            }
        }
    }
}
