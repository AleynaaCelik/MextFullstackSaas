using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Helpers
{
    public static class JwtHelper
    {
        public static IEnumerable<Claim> ReadClaimsFromToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var jwtToken = tokenHandler.ReadJwtToken(accessToken);

                return jwtToken.Claims;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Claim>();
            }
        }
    }
}

