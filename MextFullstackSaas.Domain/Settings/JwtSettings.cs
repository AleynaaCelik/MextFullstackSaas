using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Settings
{
    public class JwtSettings
    {

       
            public string SecretKey { get; set; }
            public int AccessTokenExpirationInMinutes { get; set; }
            public int RefreshTokenExpirationDays { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
       

    }

}
