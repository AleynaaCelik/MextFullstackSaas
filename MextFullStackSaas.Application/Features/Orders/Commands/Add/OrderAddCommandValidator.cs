using FluentValidation;
using MextFullstackSaas.Domain.Enums;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandValidator:AbstractValidator<OrderAddCommand>
    {
        private readonly ICurrentUserService _currentUserService;
        public OrderAddCommandValidator()
       {
            RuleFor(x=>x.IconDescription).NotEmpty().MaximumLength(200).WithMessage("The Icon dscription must be less then 200 characters");

            RuleFor(x => x.ColourCode).NotEmpty().MaximumLength(15).WithMessage("The Colour Code must be less then 200 characters");

            RuleFor(x => x.Model).IsInEnum().WithMessage("PLease selecet a valid model");

            RuleFor(x => x.DesignType).IsInEnum().WithMessage("PLease selecet a valid design type");

            RuleFor(x => x.Size).IsInEnum().WithMessage("PLease selecet a valid size");

            RuleFor(x => x.Shape).IsInEnum().WithMessage("PLease selecet a valid shape");

            RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(0).WithMessage("PLease selecet a valid quantity");


            RuleFor(x => x.Size).Must(IsUserIdValid).WithMessage("You need to be logged-in to place an order");
        }

        private bool IsUserIdValid(IconSize Size) => _currentUserService.UserId != Guid.Empty;
        
            
        
    }
}
