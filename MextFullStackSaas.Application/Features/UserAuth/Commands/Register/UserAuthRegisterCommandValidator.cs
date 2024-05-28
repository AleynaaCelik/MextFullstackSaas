using FluentValidation;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandValidator : AbstractValidator<UserAuthRegisterCommand>
    {
        private readonly IIdentityService _identityService;
        public UserAuthRegisterCommandValidator(IIdentityService identityService)
        {
            _identityService = identityService;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.Confirmpassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required");


        }
        private async Task<bool>CheckIfUserExist(string email,CancellationToken cancellationToken)
        {
            return !await _identityService.IsEmailExistAsync(email, cancellationToken);
        }
    }
}
