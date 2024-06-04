using FluentValidation;
using MextFullstackSaas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Features.Orders.Commands.Delete;

namespace MextFullstackSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator : AbstractValidator<OrderDeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService; //token üzerinden hangi user işlem yapacak

        public OrderDeleteCommandValidator(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .WithMessage("Please select a valid order");

            RuleFor(x => x.Id)
                .MustAsync( (id, cancellationToken) => IsOrderExistsAsync(id, cancellationToken))
                .WithMessage("The selected order does not exist.");

            RuleFor(x => x.Id)
                .MustAsync( (id, cancellationToken) => IsTheSameUserAsync(id, cancellationToken))
                .WithMessage("The selected order does not belong to the current user.");
        }

        private  Task<bool> IsOrderExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            return  _dbContext.Orders.AnyAsync(o => o.Id == id, cancellationToken);
        }

        private  Task<bool> IsTheSameUserAsync(Guid id, CancellationToken cancellationToken)
        {
            return  _dbContext.Orders
                .AnyAsync(o => o.Id == id && o.UserId == _currentUserService.UserId, cancellationToken);

           
        }
    }
}
