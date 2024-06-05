using FluentValidation;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.FluentValidation.BaseValidators
{
    public class UserAuthValidatorBase<T>:AbstractValidator<T> where T:class
    {
        protected readonly IIdentityService _identityService;
        public UserAuthValidatorBase(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        protected bool IsEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email,emailPattern,RegexOptions.IgnoreCase);
        }
    }
}
