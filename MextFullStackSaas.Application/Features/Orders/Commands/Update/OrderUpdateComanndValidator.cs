using FluentValidation;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Features.Orders.Commands.Delete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateComanndValidator : AbstractValidator<OrderUpdateCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderUpdateComanndValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Order ID is required");

            RuleFor(x => x.IconDescription).NotEmpty().MaximumLength(200).WithMessage("The Icon description must be less than 200 characters");

            RuleFor(x => x.ColourCode).NotEmpty().MaximumLength(15).WithMessage("The Colour Code must be less than 15 characters");

            RuleFor(x => x.Model).IsInEnum().WithMessage("Please select a valid model");

            RuleFor(x => x.DesignType).IsInEnum().WithMessage("Please select a valid design type");

            RuleFor(x => x.Size).IsInEnum().WithMessage("Please select a valid size");

            RuleFor(x => x.Shape).IsInEnum().WithMessage("Please select a valid shape");

            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Please select a valid quantity");
            RuleFor(x => x.Id)
               .MustAsync((id, cancellationToken) => IsOrderExists(id, cancellationToken))
               .WithMessage("The selected order does not exist.");

            RuleFor(x => x.Id)
                .MustAsync((id, cancellationToken) => IsOrderBelongsToCurrentUser(id, cancellationToken))
                .WithMessage("The selected order does not belong to the current user.");
        }
        private Task<bool> IsOrderExists(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Orders.AnyAsync(o => o.Id == id, cancellationToken);
        }

        private Task<bool> IsOrderBelongsToCurrentUser(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Orders
                .AnyAsync(o => o.Id == id && o.UserId == _currentUserService.UserId, cancellationToken);


        }
    }
}
