using FluentValidation;
using MextFullStackSaas.Application.Common.Interfaces;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        private readonly IIdentityService _identityService;

        public ForgotPasswordCommandValidator(IIdentityService identityService)
        {
            _identityService = identityService;

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} is not a valid email address.")
                .MustAsync(CheckIfUserExist).WithMessage("User with this email does not exist");
        }

        private Task<bool> CheckIfUserExist(string email, CancellationToken cancellationToken)
        {
            return _identityService.IsEmailExistAsync(email, cancellationToken);
        }
    }
}
