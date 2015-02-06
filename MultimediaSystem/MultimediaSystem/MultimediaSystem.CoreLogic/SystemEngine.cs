using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;
using MultimediaSystem.Models;

namespace MultimediaSystem.CoreLogic
{
    class SystemEngine
    {
        static void Main(string[] args)
        {
            MultimediaItem book = new Book("1234", "Hi Jack", 101m, "Joe", new List<Genre>());
            Rent rent = new Rent(book);
            rent.ReturnRentedItem();
            
        }
    }
}
