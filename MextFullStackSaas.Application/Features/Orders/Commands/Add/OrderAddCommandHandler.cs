using MediatR;
using MextFullstackSaas.Domain.Common;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models.OpenAI;
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
        private readonly IOpenAIService _openAiService;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService,IOpenAIService openAiServices)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _openAiService = openAiServices;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
           var order=OrderAddCommand.MapToOrder
                (request);
            order.UserId = _currentUserService.UserId;
            order.CreatedByUserId = _currentUserService.UserId.ToString();
            order.Urls = await _openAiService.DallECreateIconAsync(DallECreateIconRequestDto.MapFromOrderAddCommand(request),cancellationToken);

            //TODO:Make Request to the Gemine or Dal-e-3

            _dbContext.Orders.Add (order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Your order completed successfully");
        }
    }
}
