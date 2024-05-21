using MediatR;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdQueryHandler : IRequestHandler<OrderGetByIdQuery, OrderGetByIdDto>
    {
        private readonly IApplicationDbContext _dbcontext;
        public OrderGetByIdQueryHandler(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<OrderGetByIdDto> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbcontext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return OrderGetByIdDto.MapFromOrder(order);
            
        }
    }
}
