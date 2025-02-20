﻿using FluentValidation;
using MextFullStackSaas.Application.Common.FluentValidation.BaseValidators;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Login
{
    public class UserAuthLoginCommandValidator : UserAuthValidatorBase<UserAuthLoginCommand>
    {
        //private readonly IIdentityService _identityService;
        public UserAuthLoginCommandValidator(IIdentityService identityService):base(identityService) 
        {
            //_identityService = identityService;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required").Must(IsEmail).WithMessage("Email is not valid");
               // .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.Email).MustAsync((x, y, cancellationToken) => CheckPasswordSignInAsync(x.Email, x.Password, cancellationToken)).WithMessage("Your email or password is incorrect.Please try again");

            RuleFor(x => x.Email).MustAsync(CheckIfEmailVerifiedAsync).WithMessage("Email not verified.Please verify your email");

        }
        private  Task<bool> CheckPasswordSignInAsync(string email,string password, CancellationToken cancellationToken)
        {
            return  _identityService.CheckPasswordSignInAsync(email, password,cancellationToken);
        }

        private Task<bool>CheckIfEmailVerifiedAsync(string email,CancellationToken cancellationToken) 
        { 
        return _identityService.IsEmailExistAsync(email,cancellationToken);
        }
    }
}
