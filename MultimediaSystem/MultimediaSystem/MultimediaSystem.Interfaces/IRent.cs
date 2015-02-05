using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.Models;

namespace MultimediaSystem.InterFaces
{
    interface IRent
    {
        MultimediaItem ItemRented { get; set; }
        RentState RentState { get; set; }
        DateTime DateOfRent { get; set; }
        DateTime DeadLine { get; set; }
        DateTime DateOfReturn { get; set; }
        decimal CalculateFine();
    }
}
