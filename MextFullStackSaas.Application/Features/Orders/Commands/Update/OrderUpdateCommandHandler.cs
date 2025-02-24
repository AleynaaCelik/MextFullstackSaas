﻿using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MextFullstackSaas.Domain.Entities;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderUpdateCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

           

            MapToOrder(order, request);

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Order updated successfully");
        }

        private void MapToOrder(Order order, OrderUpdateCommand request)
        {
            order.IconDescription = request.IconDescription;
            order.ColourCode = request.ColourCode;
            order.Model = request.Model;
            order.DesignType = request.DesignType;
            order.Size = request.Size;
            order.Shape = request.Shape;
            order.Quantity = request.Quantity;
            order.ModifiedOn = DateTimeOffset.UtcNow;

           
        }
    }
}
