using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;
using MultimediaSystem.Models;

namespace MultimediaSystem.CoreLogic
{
    class ShopEngine
    {
        private Dictionary<IItem, int> itemsInStore = new Dictionary<IItem, int>();
        private List<ISale> listofSales = new List<ISale>();
        private List<IRent> listofRents = new List<IRent>();
        
        public ShopEngine(Dictionary<IItem, int> itemsInStore)
        {
            this.ItemsInStore = itemsInStore;
        }

        public Dictionary<IItem, int> ItemsInStore
        {
            get { return itemsInStore; }
            private set { itemsInStore = value; }
        }

        public List<ISale> ListOfSales
        {
            get { return listofSales; }
            private set { listofSales = value; }
        }

        public List<IRent> ListOfRents
        {
            get { return listofRents; }
            private set { listofRents = value; }
        }
        

        public void ExecuteInputCommand(string input) 
        {
            var inputToArray=input.Split(' ');                      
            Dictionary<string, string> attributeByKeyAndValue = new Dictionary<string, string>();
            
            switch (inputToArray[0])
            {
                case "supply":
                    {
                        attributeByKeyAndValue=ParseSupplyCommandToDictionary(inputToArray);
                        IItem itemToAdd;
                        try
                        {
                        itemToAdd=CreateIITemByParsedCommand(inputToArray[1], attributeByKeyAndValue);
                        }
                        catch (Exception)
                        {
                            throw new KeyNotFoundException("You have enetered Item with invalid parameters. Please use the following mask: supply [type] [quantity] [params] – adds [quantity] items of [type] to the supplies. [params] is a string in the format key1=value1&key2=value2&key3=value3, where key-value pairs are separated by &");
                        }
                        
                        itemsInStore.Add(itemToAdd,int.Parse(inputToArray[2]));
                    }
                    break;
                case "sell":
                   ISale saleToAdd = new Sale((MultimediaItem)FindItemInSupplies(inputToArray),
                                               DateTime.Parse(inputToArray[2]));
                   AddSale(inputToArray, saleToAdd);
                    break;
                case "rent":
                    IRent rentToAdd = new Rent((MultimediaItem)FindItemInSupplies(inputToArray),
                                                DateTime.Parse(inputToArray[2]), DateTime.Parse(inputToArray[3]));
                    AddRent(inputToArray, rentToAdd);
                    break;
                case "report":
                    if (inputToArray[1]=="sales")
                    {
                        PrintAllSalesToSpecificDate(inputToArray);
                    }
                    else if (inputToArray[1] == "rents")
                    {
                        PrintAllOverdueRents();
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid report type entered");
                    }
                    break;
                default:
                    throw new InvalidOperationException("You have entered Wrong Operation");
            }
        }

        private void AddSale(string[] inputToArray, ISale saleToAdd)
        {
            listofSales.Add(saleToAdd);
            itemsInStore[FindItemInSupplies(inputToArray)] -= 1;
        }

        private void AddRent(string[] inputToArray, IRent rentToAdd)
        {
            listofRents.Add(rentToAdd);
            itemsInStore[FindItemInSupplies(inputToArray)] -= 1;
        }

        private void PrintAllOverdueRents()
        {
            var listOfRentsToPrint = listofRents
                .Where(x => x.RentState == RentState.Overdue)
                .OrderBy(x => x.CalculateFine())
                .ThenBy(x=>x.ItemRented.Title);
            foreach (var rent in listOfRentsToPrint)
            {
                Console.WriteLine(rent.ItemRented.Title+" "+rent.DateOfRent+" "+rent.DeadLine + " " + rent.RentState + " " + rent.CalculateFine());
            }
        }

        private void PrintAllSalesToSpecificDate(string[] inputToArray)
        {
            var salesToPrint=listofSales
                .Where(x => x.DateOfPurchase >= DateTime.Parse(inputToArray[2]))
                .OrderBy(x => x.DateOfPurchase);
            
            foreach (var sale in salesToPrint)
            {
                Console.WriteLine(sale.ItemSold + " " + sale.DateOfPurchase);
            }
        }


        private IItem FindItemInSupplies(string[] inputToArray)
        {
            bool isInList = false;
            IItem foundItem;
            foreach (var item in itemsInStore)
            {
                if ((item.Key.Id == inputToArray[1]) && (item.Value > 0))
                {
                    isInList = true;
                    foundItem = item.Key;
                    return foundItem;
                }
            }
            if (isInList == false)
            {
                throw new ArgumentException("Item for sale is not in store");
            }
            else 
            {
                throw new ArgumentException("Item for sale is not in store");
            }
            
        }

        private static Dictionary<string, string> ParseSupplyCommandToDictionary(string[] inputToArray)
        {
            Dictionary<string, string> attributeByKeyAndValue = new Dictionary<string, string>();
            var MultimediaItemAttributes = inputToArray[3].Split('&');

            foreach (var item in MultimediaItemAttributes)
            {
                var keyValue = item.Split('=');
                attributeByKeyAndValue.Add(keyValue[0], keyValue[1]);
            }
            return attributeByKeyAndValue;
        }

        private IItem CreateIITemByParsedCommand(string type, Dictionary<string, string> attributeByKeyAndValue)
        {
            switch (type)
            {
                case "book":
                        {
                            IItem bookToAddinSupply = new Book(attributeByKeyAndValue["id"],
                                                attributeByKeyAndValue["title"],
                                                Decimal.Parse(attributeByKeyAndValue["price"]),
                                                attributeByKeyAndValue["author"],
                                                new Genre(attributeByKeyAndValue["genre"]));
                            return bookToAddinSupply;
                        }
                case "movie":
                        {
                            IItem bookToAddinSupply = new Movie(attributeByKeyAndValue["id"],
                                                attributeByKeyAndValue["title"],
                                                Decimal.Parse(attributeByKeyAndValue["price"]),
                                                int.Parse(attributeByKeyAndValue["legth"]),
                                                new Genre(attributeByKeyAndValue["genre"]));
                            return bookToAddinSupply;
                        }
                case "game":
                        {
                            IItem bookToAddinSupply = new Game(attributeByKeyAndValue["id"],
                                                attributeByKeyAndValue["title"],
                                                Decimal.Parse(attributeByKeyAndValue["price"]),
                                                new Genre(attributeByKeyAndValue["genre"]));
                            return bookToAddinSupply;
                        }
                default:
                        throw new ArgumentException("Wrong supply type entered");
            }
        }
        
    }
}
