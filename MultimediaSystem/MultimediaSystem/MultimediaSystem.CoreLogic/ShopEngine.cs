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
        public Dictionary<IItem, int> itemsInStore = new Dictionary<IItem, int>();
        public ShopEngine(Dictionary<IItem, int> itemsInStore)
        {
            this.ItemsInStore = itemsInStore;
        }

        public Dictionary<IItem, int> ItemsInStore
        {
            get { return itemsInStore; }
            private set { itemsInStore = value; }
        }
        

        public void ParseInput(string input) 
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
                            throw new KeyNotFoundException("One or more of the keys you have entered is invalid");
                        }
                        
                        itemsInStore.Add(itemToAdd,int.Parse(inputToArray[2]));
                    }
                    break;
                default:
                    Console.WriteLine("Wrong Operation enetered");
                    break;
            }
                        
            IItem bookToAddinSupply = new Book(attributeByKeyAndValue["id"],
                                            attributeByKeyAndValue["title"],
                                            Decimal.Parse(attributeByKeyAndValue["price"]),
                                            attributeByKeyAndValue["author"],
                                            new Genre(attributeByKeyAndValue["genre"]));
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
                        break;
                case "movie":
                        {
                            IItem bookToAddinSupply = new Movie(attributeByKeyAndValue["id"],
                                                attributeByKeyAndValue["title"],
                                                Decimal.Parse(attributeByKeyAndValue["price"]),int.Parse(attributeByKeyAndValue["lenght"]),
                                                new Genre(attributeByKeyAndValue["genre"]));
                            return bookToAddinSupply;
                        }
                        break;
                case "game":
                        {
                            IItem bookToAddinSupply = new Game(attributeByKeyAndValue["id"],
                                                attributeByKeyAndValue["title"],
                                                Decimal.Parse(attributeByKeyAndValue["price"]),
                                                new Genre(attributeByKeyAndValue["genre"]));
                            return bookToAddinSupply;
                        }
                        break;
                default:
                        throw new ArgumentException("Wrong supply type entered");
            }
        }
        
    }
}
