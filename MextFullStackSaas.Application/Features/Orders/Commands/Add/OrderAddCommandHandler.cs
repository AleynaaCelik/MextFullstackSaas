using MediatR;
using MextFullstackSaas.Domain.Common;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderAddCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
           var order=OrderAddCommand.MapToOrder
                (request);

            //TODO:Make Request to the Gemine or Dal-e-3

            _dbContext.Orders.Add (order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(order.Id, "Your order completed successfully");
        }
    }
}
