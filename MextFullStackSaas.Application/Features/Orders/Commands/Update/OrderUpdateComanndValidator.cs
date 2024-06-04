using FluentValidation;
using MextFullStackSaas.Application.Features.Orders.Commands.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateComanndValidator : AbstractValidator<OrderUpdateCommand>
    {
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
        }
    }
}
