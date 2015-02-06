using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;

namespace MultimediaSystem.Models
{
    public class Sale:Operation,ISale
    {
        private MultimediaItem itemSold;
        private DateTime dateOfPurchase;
        public Sale(MultimediaItem itemSold)
        {
            this.ItemSold = itemSold;
            this.DateOfPurchase = DateTime.Now;
        }
        public Sale(MultimediaItem itemSold,DateTime dateOfPurchase)
        {
            this.ItemSold = itemSold;
            this.DateOfPurchase = dateOfPurchase;
        }
        public MultimediaItem ItemSold
        {
            get
            {
                return this.itemSold;
            }
            set
            {
                if (value == null) 
                {
                    throw new ArgumentNullException("The value sold cannot be null");
                }
                this.itemSold=value;
            }
        }

        public DateTime DateOfPurchase
        {
            get
            {
                return this.dateOfPurchase;
            }
            private set
            {
                this.dateOfPurchase=value;
            }
        }
    }
}
