using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.InterFaces;

namespace MultimediaSystem.Models
{
    class Rent:Operation,IRent
    {
        private MultimediaItem itemRented;
        private RentState rentState;
        private DateTime dateRented;

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
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateOfReturn
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public decimal CalculateFine()
        {
            throw new NotImplementedException();
        }
    }
}
