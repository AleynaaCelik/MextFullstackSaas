using MextFullStackSaas.Application.Common.Models.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto,CancellationToken cancellationToken);
        Task SendPasswordResetEmailAsync(EmailSendPasswordResetDto emailDto, CancellationToken cancellationToken);
    }
}
