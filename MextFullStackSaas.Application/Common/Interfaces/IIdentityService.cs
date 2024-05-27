using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models.Auth;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto>RegisterAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken);
        Task<JwtDto>SignInAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken);
    }
}
