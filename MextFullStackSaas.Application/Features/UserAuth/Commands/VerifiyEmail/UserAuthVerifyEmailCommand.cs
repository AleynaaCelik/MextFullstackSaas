using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.VerifiyEmail
{
    public class UserAuthVerifyEmailCommand:IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public UserAuthVerifyEmailCommand(string email,string token )
        {
                Email = email;
            Token = token;
        }
        public UserAuthVerifyEmailCommand()
        {
                
        }
    }
}
