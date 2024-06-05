using FluentValidation;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} is not a valid email address.");

            RuleFor(p => p.Token)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.NewPassword)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(6).WithMessage("{PropertyName} must be at least 6 characters long.");
        }
    }
}
