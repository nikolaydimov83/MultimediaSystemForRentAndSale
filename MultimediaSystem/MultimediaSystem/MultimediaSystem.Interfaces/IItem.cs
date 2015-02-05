using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.Models;

namespace MultimediaSystem.InterFaces
{
    interface IItem
    {
        string Id { get; set; }
        string Title { get; set; }
        decimal Price { get; set; }
        List<Genre> SetOfGenres { get; set; }
    }
}
