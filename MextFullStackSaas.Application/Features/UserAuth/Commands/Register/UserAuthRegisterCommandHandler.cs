using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler : IRequestHandler<UserAuthRegisterCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        public UserAuthRegisterCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
