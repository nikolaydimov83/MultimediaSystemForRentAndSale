using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;

namespace MultimediaSystem.Models
{
    class Game:MultimediaItem,IItem
    {
        private AgeRestriction ageRestriction;
       
        public AgeRestriction AgeRestriction
        {
            get { return this.ageRestriction; }
            set { this.ageRestriction = value; }
        }
        
        public Game(string id, string title, decimal price, List<Genre> setOfGenres, AgeRestriction ageRestriction=AgeRestriction.Minor)
            :base(id,title,price,setOfGenres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, Genre genre, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price)
        {
            this.AgeRestriction = ageRestriction;
            this.SetOfGenres = new List<Genre> { genre };
        }
    }
}
