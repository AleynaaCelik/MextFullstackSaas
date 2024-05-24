using MextFullstackSaas.Domain.Settings;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class JwtManager:IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtManager(IOptions<JwtSettings>jwtSettingsOptions)
        {
            _jwtSettings=jwtSettingsOptions.Value;

        }
    }
}
