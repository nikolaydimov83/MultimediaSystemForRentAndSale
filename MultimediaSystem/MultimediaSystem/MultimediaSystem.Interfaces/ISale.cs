using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultimediaSystem.Models;

namespace MultimediaSystem.InterFaces
{
    interface ISale
    {
        MultimediaItem ItemSold { get; set; }
        DateTime DateOfPurchase { get;  }
    }
}
