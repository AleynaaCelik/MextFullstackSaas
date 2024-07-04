using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public  interface IPaymentService
    {
        Task<object> CreateCheckOutFromAsync(CancellationToken cancellationToken);
    }
}
