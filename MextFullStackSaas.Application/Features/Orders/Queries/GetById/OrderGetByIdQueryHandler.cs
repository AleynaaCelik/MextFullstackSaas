using MediatR;
using MextFullstackSaas.Domain.Entities;
using MextFullStackSaas.Application.Common.Helpers;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        public OrderGetByIdQueryHandler(IApplicationDbContext dbcontext,IMemoryCache memoryCache)
        {
            _dbcontext = dbcontext;
            _memoryCache= memoryCache;
        }
        public async Task<OrderGetByIdDto> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
        {
            OrderGetByIdDto order;
            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrderGetByIdKey(request.Id), out order))
                return order;


            var normalOrder = await _dbcontext
                 .Orders
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            order = OrderGetByIdDto.MapFromOrder(normalOrder);

            _memoryCache.Set(
        MemoryCacheHelper.GetOrderGetByIdKey(request.Id),
        order,
        MemoryCacheHelper.GetMemoryCacheEntryOptions()
    );
            return order;
            
        }
    }
}
