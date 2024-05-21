using FluentValidation;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator:AbstractValidator<OrderDeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public OrderDeleteCommandValidator(IApplicationDbContext dbContext)
        { 
            _dbContext= dbContext;
            RuleFor(x=>x.Id).NotEmpty().NotNull().WithMessage("Please selecet a valid order");

            RuleFor(x => x.Id).MustAsync(IsOrderExists).WithMessage("The selected order does not exist in the database");
            
        }
        public Task<bool>IsOrderExists(Guid id,CancellationToken cancellationToken)
        {

            //if the order exists well return true ,otherwise wel return false
            //ıf we return true this will be valid order
            return _dbContext.Orders.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
