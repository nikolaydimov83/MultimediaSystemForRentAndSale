using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;
using System.Threading;

namespace MultimediaSystem.Models
{
    public class Rent:Operation,IRent
    {
        private MultimediaItem itemRented;
        private RentState rentState;
        private DateTime dateOfRent;
        private DateTime deadLine;
        private DateTime dateOfReturn;

        public Rent(MultimediaItem itemRented)
        {
            this.ItemRented = itemRented;
            this.RentState = RentState.Taken;
            this.DateOfRent = DateTime.Now;
            this.DeadLine = DateTime.Now.AddDays(30);
        }

        public Rent(MultimediaItem itemRented, DateTime dateOfRent, DateTime deadline)
        {
            this.ItemRented = itemRented;
            this.RentState = RentState.Taken;
            this.DateOfRent = dateOfRent;
            this.DeadLine = deadline;
        }

        public Rent(MultimediaItem itemRented, DateTime dateOfRent)
        {
            this.ItemRented = itemRented;
            this.RentState = RentState.Taken;
            this.DateOfRent = dateOfRent;
            this.DeadLine = dateOfRent.AddDays(30);
        }


        public decimal RentFine
        {
            get 
            {
                CheckForOverdue();
                return this.CalculateFine(); 
            }
            
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
                CheckForOverdue();
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
                return this.dateOfRent;
            }
            private set
            {
                this.dateOfRent = value;
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
                if (dateOfRent==null)
                {
                    throw new ArgumentException("This item has not be rented");
                }
                this.deadLine = value;
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
            CheckForOverdue();
            if ((DateTime.Now - deadLine).TotalDays > 0)
            {
                if (RentState == RentState.Overdue)
                {
                    decimal finePerDay = 0.01m * itemRented.Price;
                    return ((decimal)(this.deadLine - DateTime.Now).TotalDays * finePerDay)*(-1);
                }
                else 
                {
                    decimal finePerDay = 0.01m * itemRented.Price;
                    return ((decimal)(this.deadLine - this.dateOfReturn).TotalDays * finePerDay)*(-1);
                }
            }
            else 
            {
                return 0;
            }
            
        }
        
        public void CheckForOverdue()
        {
            if ((this.rentState == RentState.Taken)&&(this.deadLine<DateTime.Now)) 
            {
                this.rentState = RentState.Overdue;
            }
        }
    }
}
