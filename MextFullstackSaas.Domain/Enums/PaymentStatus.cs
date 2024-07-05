using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Enums
{
    public enum PaymentStatus
    {
        Initiated=1,
        Pending=2,
        Success=3,
        Canceled=4,
        Refunded=6
    }
}
