using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }

        public ForgotPasswordCommand(string email)
        {
            Email = email;
        }

        public ForgotPasswordCommand() { }
    }
}
