using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommand:IRequest<ResponseDto<Guid>>
    {
        public Guid Id { get; set; }

        public OrderDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
