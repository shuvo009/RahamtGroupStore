using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RahamtGroupStore.Model.Interfaces
{
    interface IDatePair
    {
        DateTime FirstDate { get; set; }
        DateTime SecondDate { get; set; }
    }
}
