using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;

namespace MultimediaSystem.Models
{
    public class Rent:Operation,IRent
    {
        private MultimediaItem itemRented;
        private RentState rentState;
        private DateTime dateRented;
        private DateTime deadLine;
        private DateTime dateOfReturn;
        private const decimal FinePerDay = 10m;

        public Rent(MultimediaItem itemRented)
        {
            this.ItemRented = itemRented;
            this.RentState = RentState.Taken;
            this.DateOfRent = DateTime.Now;
            this.DeadLine = dateRented.AddDays(3);
        }

        public MultimediaItem ItemRented
        {
            get
            {
                return this.itemRented;
            }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("The item rented cannot be null");
                }
                this.itemRented = value;
            }
        }

        public RentState RentState
        {
            get
            {
                return this.rentState;
            }
            private set
            {
                this.rentState = value;
            }
        }

        public DateTime DateOfRent
        {
            get
            {
                return this.dateRented;
            }
            private set
            {
                this.dateRented = value;
            }
        }

        public DateTime DeadLine
        {
            get
            {
                return this.deadLine;
            }
            private set
            {
                if (dateRented==null)
                {
                    throw new ArgumentException("This item has not be rented");
                }
                this.deadLine = dateRented.AddDays(3);
            }
        }

        public DateTime DateOfReturn
        {
            get
            {
                return this.dateOfReturn;
            }
        }

        public void ReturnRentedItem() 
        {
             this.dateOfReturn= DateTime.Now;
             this.rentState = RentState.Returned;
        }

        public decimal CalculateFine()
        {
            return (decimal)(dateOfReturn - deadLine).TotalDays * FinePerDay;
        }
    }
}
