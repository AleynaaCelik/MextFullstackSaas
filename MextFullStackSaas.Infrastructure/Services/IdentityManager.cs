using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;


        public async Task<JwtDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                UserName = command.FirstName,
                LastName = command.LastName,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = id.ToString(),
                EmailConfirmed = true,
                Balance = new UserBalance()
                {
                    Id = Guid.NewGuid(),
                    Credits = 10,
                    UserId = id,
                    CreatedOn = DateTimeOffset.Now,
                    CreatedByUserId = id.ToString(),
                }
            };
            var result = await _userManager.CreateAsync(user, command.Password);
            if (result.Succeeded)
            {
                throw new Exception("User registration failded");
            }
            return await _jwtService.GenerateTokenAsync(user.Id, user.Email, cancellationToken);
        }

        public Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
