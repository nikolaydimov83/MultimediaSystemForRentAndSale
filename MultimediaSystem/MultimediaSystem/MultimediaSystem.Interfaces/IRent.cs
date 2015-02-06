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
        RentState RentState { get; }
        DateTime DateOfRent { get; }
        DateTime DeadLine { get; }
        DateTime DateOfReturn { get; }
        decimal CalculateFine();
    }
}
