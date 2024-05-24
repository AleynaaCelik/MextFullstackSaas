using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommand:IRequest<ResponseDto<JwtDto>>
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
