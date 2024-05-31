using FluentValidation;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Login
{
    public class UserAuthLoginCommandValidator : AbstractValidator<UserAuthLoginCommand>
    {
        private readonly IIdentityService _identityService;
        public UserAuthLoginCommandValidator(IIdentityService identityService)
        {
            _identityService = identityService;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

        }
        private  Task<bool> CheckIfUserExist(string email, CancellationToken cancellationToken)
        {
            return  _identityService.IsEmailExistAsync(email, cancellationToken);
        }
    }
}
