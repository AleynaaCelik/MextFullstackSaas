using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
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
        private readonly IRoothPathService _roothPathService;

        public ResendEmailManager(IResend resend, IRoothPathService roothPathService)
        {
            _resend = resend;
            _roothPathService = roothPathService;
        }

        private const string ApiBaseUrl = "https://localhost:7030/api/";

        public async Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = Uri.EscapeDataString(emailDto.Email);
            var encodedToken = Uri.EscapeDataString(emailDto.Token);
            var link = $"{ApiBaseUrl}UsersAuth/verify-email?email={encodedEmail}&token={encodedToken}";

            var htmlContent = await File.ReadAllTextAsync($"{_roothPathService.GetRoothPath()}/email-templates/userauth-template.html", cancellationToken);
            htmlContent = htmlContent.Replace("{{{Link}}}", link);
            htmlContent = htmlContent.Replace("{{{subject}}}", "Email verification");
            htmlContent = htmlContent.Replace("{{{content}}}", "Kindly click the button below the confirm your email address ");
            htmlContent = htmlContent.Replace("{{{buttonText}}}", "Verify Email ");

            // Yanlış: EmailSendAsync
            // Doğru: SendEmailAsync
            await SendEmailAsync(new EmailSendDto(emailDto.Email, "Email Verification", htmlContent), cancellationToken);
        }

        private Task SendEmailAsync(EmailSendDto emailSendDto, CancellationToken cancellationToken)
        {
            var message = new EmailMessage
            {
                From = "noreply@yazilim.academy",
                Subject = emailSendDto.Subject,
                HtmlBody = emailSendDto.HtmlContent
            };

            foreach (var emailAddress in emailSendDto.Addreses)
            {
                message.To.Add(emailAddress);
            }

            return _resend.EmailSendAsync(message, cancellationToken);
        }

        public Task SendPasswordResetEmailAsync(EmailSendPasswordResetDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = Uri.EscapeDataString(emailDto.Email);
            var encodedToken = Uri.EscapeDataString(emailDto.Token);
            var link = $"{ApiBaseUrl}UsersAuth/reset-password?email={encodedEmail}&token={encodedToken}";

            Console.WriteLine($"Token: {emailDto.Token}");

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
