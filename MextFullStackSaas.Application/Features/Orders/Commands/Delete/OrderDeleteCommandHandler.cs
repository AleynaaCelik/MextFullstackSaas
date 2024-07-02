using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MextFullStackSaas.Application.Common.Helpers;
using MextFullStackSaas.Application.Features.Orders.Queries.GetById;
using MextFullStackSaas.Application.Features.Orders.Queries.GetAll;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMemoryCache _memoryCache;
        private readonly IObjectStorageService _objectStorageService;
        public OrderDeleteCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService,IMemoryCache memoryCache, IObjectStorageService objectStorageService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _memoryCache = memoryCache;
            _objectStorageService = objectStorageService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);


            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _objectStorageService.RemoveAsync(order.Urls, cancellationToken);
            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrderGetByIdKey(request.Id), out OrderGetByIdDto orderGetByIdDto))
                _memoryCache.Remove(MemoryCacheHelper.GetOrderGetByIdKey(request.Id));
            if(_memoryCache.TryGetValue(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),out List<OrderGetAllDto> orders))
            {
                orders=orders.Where(x=>x.Id!=request.Id).ToList();
                _memoryCache.Set(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),orders,MemoryCacheHelper.GetMemoryCacheEntryOptions());
            }
            return new ResponseDto<Guid>(order.Id, "Order deleted successfully");
        }
    }
}
