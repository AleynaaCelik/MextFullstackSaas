using FluentValidation;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.VerifiyEmail
{
    public class UserAuthVerifyEmailCommandValidator:AbstractValidator<UserAuthVerifyEmailCommand>
    {
        private readonly IIdentityService _identityService;
        
            public UserAuthVerifyEmailCommandValidator()
            {
                RuleFor(p => p.Email)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .EmailAddress().WithMessage("{PropertyName} is not a valid email address.");

                RuleFor(p => p.Token)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .MinimumLength(10)
                    .WithMessage("{PropertyName} must be at least 10 characters long.");

              RuleFor(p => p.Email)
              .MustAsync(CheckIfUserExist).WithMessage("User with email this not exists");
        }
        private  Task<bool> CheckIfUserExist(string email, CancellationToken cancellationToken)
        {
            return  _identityService.IsEmailExistAsync(email, cancellationToken);
        }
    }
    }

