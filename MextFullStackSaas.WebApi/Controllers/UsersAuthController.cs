using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using MediatR;
using MextFullstackSaas.Domain.Settings;
using MextFullStackSaas.Application.Common.Translations;
using MextFullStackSaas.Application.Features.UserAuth.Commands.ForgotPassword;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Login;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using MextFullStackSaas.Application.Features.UserAuth.Commands.ResetPassword;
using MextFullStackSaas.Application.Features.UserAuth.Commands.VerifiyEmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace MextFullStackSaas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly ISender _mediatr;
        private readonly GoogleSettings _googleSettings;
        private const string RedirectUri = "https://localhost:7030/api/UsersAuth/signin-google";
        private readonly string _googleAutherizationUrl;

        public UsersAuthController(ISender mediatr, IOptions<GoogleSettings> googleSettings)
        {
            _mediatr = mediatr;
            _googleSettings = googleSettings.Value;
            _googleAutherizationUrl = $"https://accounts.google.com/o/oauth2/v2/auth?" +
                                         $"client_id={_googleSettings.ClientId}&" +
                                         $"response_type=code&" +
                                         $"scope=openid%20email%20profile&" +
                                         $"access_type=offline&" +
                                         $"redirect_uri={RedirectUri}";
        }

        [HttpGet("signin-google-start")]
        public IActionResult GoogleSignInStart()
        => Redirect(_googleAutherizationUrl);


        [HttpGet("GoogleSignIn")]
        public async Task<IActionResult> SignInGoogleAsync(string code, CancellationToken cancellationToken)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = _googleSettings.ClientId,
                    ClientSecret = _googleSettings.ClientSecret,
                }
            });

            var tokenResponse = await flow.ExchangeCodeForTokenAsync(
                userId: "user",
                code: code,
                redirectUri: RedirectUri,
                cancellationToken
            );

            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken);

            var email = payload.Email;
            var firstName = payload.GivenName;
            var lastName = payload.FamilyName;

            //var jwtDto =
            //    await _authenticationService.SocialLoginAsync(userEmail, firstName, lastName, cancellationToken);

            //var queryParams = new Dictionary<string, string>()
            //{
            //    {"access_token",jwtDto.AccessToken },
            //    {"expiry_date",jwtDto.ExpiryDate.ToBinary().ToString() },
            //};

            //var formContent = new FormUrlEncodedContent(queryParams);

            //var query = await formContent.ReadAsStringAsync(cancellationToken);

            //var redirectUrl = $"http://127.0.0.1:5173/social-login?{query}";

            
            return Redirect($"http://localhost:5130/social-login?email={email}&firstname={firstName}&lastname={lastName}");
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            // throw new ArgumentNullException(command.FirstName, "First name is required");
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            // throw new ArgumentNullException(command.FirstName, "First name is required");
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmailAsync([FromQuery] UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            //FromQuery tokeni almak için kullanılan attribute
            // throw new ArgumentNullException(command.FirstName, "First name is required");
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email, CancellationToken cancellationToken)
        {
            var command = new ForgotPasswordCommand { Email = email };
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(string email, string token, string newPassword, CancellationToken cancellationToken)
        {
            var command = new ResetPasswordCommand { Email = email, Token = token, NewPassword = newPassword };
            return Ok(await _mediatr.Send(command, cancellationToken));
        }
    }
}
