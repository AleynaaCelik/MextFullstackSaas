using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models.Auth;
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


        public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserAuthRegisterCommand.ToUser(command);
            var result = await _userManager.CreateAsync(user, command.Password);
            if (result.Succeeded)
            {
                throw new Exception("User registration failded");
            }
            return new UserAuthRegisterResponseDto(user.Id, user.Email);
            //Register işleminin bi işi olmalı kullanıc kayıt edecek tek mettotta jwt token ile kullanıcı kaydını yapma ayrı ayrı tut
        }

        public Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
