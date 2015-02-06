using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaSystem.Models
{
    public class Genre
    {
        private string genreName;

        public Genre(string genreName)
        {
            this.GenreName = genreName;
        }

        public string GenreName
        {
            get { return genreName; }
            set { genreName = value; }
        }
        
    }
}
