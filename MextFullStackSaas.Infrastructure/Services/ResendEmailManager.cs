using System;
using System.Threading;
using System.Threading.Tasks;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models.Emails;
using Resend;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class ResendEmailManager : IEmailService
    {
        private readonly IResend _resend;

        public ResendEmailManager(IResend resend)
        {
            _resend = resend;
        }

        private const string ApiBaseUrl = "https://localhost:7030/api/";

        public Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = Uri.EscapeDataString(emailDto.Email);
            var encodedToken = Uri.EscapeDataString(emailDto.Token);
            var link = $"{ApiBaseUrl}UsersAuth/verify-email?email={encodedEmail}&token={encodedToken}";

            var message = new EmailMessage
            {
                From = "onboarding@resend.dev",
                To = { emailDto.Email },
                Subject = "Email Verification || IconBuilderAI",
                HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Greetings<strong> 👋🏻 from .NET</a></div>"
            };

            return _resend.EmailSendAsync(message, cancellationToken);
        }

        public Task SendPasswordResetEmailAsync(EmailSendPasswordResetDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = Uri.EscapeDataString(emailDto.Email);
            var encodedToken = Uri.EscapeDataString(emailDto.Token);
            var link = $"{ApiBaseUrl}UsersAuth/reset-password?email={encodedEmail}&token={encodedToken}";

            Console.WriteLine($"Token:{emailDto.Token}");

            var message = new EmailMessage
            {
                From = "onboarding@resend.dev",
                To = { emailDto.Email },
                Subject = "Password Reset",
                HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\">Click here</a> to reset your password.</div>"
            };

            return _resend.EmailSendAsync(message, cancellationToken);
        }
    }
}
