using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderDeleteCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);


            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Order deleted successfully");
        }
    }
}
