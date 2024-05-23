using MediatR;
using MextFullstackSaas.Domain.Common;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
           var order=OrderAddCommand.MapToOrder
                (request);
            order.UserId = _currentUserService.UserId;
            order.CreatedByUserId = _currentUserService.UserId.ToString();

            //TODO:Make Request to the Gemine or Dal-e-3

            _dbContext.Orders.Add (order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Your order completed successfully");
        }
    }
}
