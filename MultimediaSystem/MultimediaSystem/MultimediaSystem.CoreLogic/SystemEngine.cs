using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;
using MultimediaSystem.Models;
using System.Threading;

namespace MultimediaSystem.CoreLogic
{
    class SystemEngine
    {
        static void Main(string[] args)
        {
            MultimediaItem sallingerBook = new Book("4adwlj4", "Catcher in the Rye", 20.00m, "J. D. Salinger", new Genre("fiction"));
            MultimediaItem threeManBook = new Book("84djesd", "Three Men in a Boat", 39.99m, "Jerome K. Jerome", new List<Genre> { new Genre("comedy") });
            MultimediaItem acGame = new Game("9gkjdsa", "AC Revelations", 78.00m, new Genre("historical"), AgeRestriction.Teen);
            MultimediaItem bubbleSplashGame = new Game("r8743jf", "Bubble Splash", 7.80m, new List<Genre> { new Genre("children"), new Genre("fun") });
            MultimediaItem godfatherMovie = new Movie("483252j", "The Godfather", 99.00m, 178, new Genre("crime"));
            MultimediaItem dieHardMovie = new Movie("9853kfds", "Die Hard 4", 9.90m, 144, new List<Genre> { new Genre("action"), new Genre("crime"), new Genre("thriller") });

            DateTime today = DateTime.Now;
            DateTime fiveYearsAgo = today.AddYears(-5);
            Sale dieHardSale = new Sale(dieHardMovie, fiveYearsAgo);
            Console.WriteLine(dieHardSale.DateOfPurchase); // 1/30/2015 2:31:55 PM (today)
            Sale acSale = new Sale(acGame);
            Console.WriteLine(acSale.DateOfPurchase); // 1/30/2010 2:31:55 PM


            DateTime afterOneWeek = today.AddDays(30);
            Rent bookRent = new Rent(sallingerBook, today, afterOneWeek);
            Console.WriteLine(bookRent.RentState); // Pending

            DateTime lastMonth = today.AddDays(-34);
            DateTime lastWeek = today.AddDays(-8);
            Rent movieRent = new Rent(godfatherMovie, lastMonth, lastWeek);
            Console.WriteLine(movieRent.RentState); // Overdue

            movieRent.ReturnRentedItem();
            Console.WriteLine(movieRent.RentState); // Returned
            Console.WriteLine(movieRent.DateOfReturn); // 1/30/2015 2:41:53 PM
            Console.WriteLine(movieRent.CalculateFine()); // 7.9200

            ShopEngine eng = new ShopEngine(new Dictionary<IItem, int>());
            eng.ParseInput("supply book 5 id=4fd332&title=Boat&price=20&author=Sellinger&genre=comedy");
   
        }
    }
}
