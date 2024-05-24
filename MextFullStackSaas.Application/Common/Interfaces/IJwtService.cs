using MextFullstackSaas.Domain.Identity;
using MextFullStackSaas.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IJwtService
    {
        JwtDto GenareteToken(User user,List<string>roles);
        Task<JwtDto> GenerateTokenAsync(Guid userId, string email,CancellationToken cancellationToken);
        //Task<JwtDto> GenareteToken(User user);

    }
}
