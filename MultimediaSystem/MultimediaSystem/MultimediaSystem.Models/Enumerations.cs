using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaSystem.Models
{
    public enum RentState
    {
        Overdue,
        Returned,
        Taken
    }

    public enum AgeRestriction
    {
        Minor, 
        Teen, 
        Adult
    }
}
