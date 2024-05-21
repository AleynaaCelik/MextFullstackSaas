using MediatR;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, Guid>
    {

        private readonly IApplicationDbContext _dbcontext;

        public OrderDeleteCommandHandler(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Guid> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            var order=await _dbcontext.Orders.FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);

            _dbcontext.Orders.Remove(order);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
