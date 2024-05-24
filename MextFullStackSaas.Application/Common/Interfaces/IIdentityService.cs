using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<JwtDto>RegisterAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken);
        Task<JwtDto>SignInAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken);
    }
}
