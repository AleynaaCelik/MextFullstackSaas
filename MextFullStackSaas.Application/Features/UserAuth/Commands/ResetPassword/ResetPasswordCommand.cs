using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }

        public ResetPasswordCommand(string email, string token, string newPassword)
        {
            Email = email;
            Token = token;
            NewPassword = newPassword;
        }

        public ResetPasswordCommand() { }
    }
}
