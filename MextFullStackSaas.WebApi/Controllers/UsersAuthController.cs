using MediatR;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Login;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using MextFullStackSaas.Application.Features.UserAuth.Commands.VerifiyEmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStackSaas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {

        private readonly ISender _mediatr;

        public UsersAuthController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("register")]
        public async Task<IActionResult>RegisterAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken)
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
        public async Task<IActionResult> VerifyEmailAsync([FromQuery]UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            //FromQuery tokeni almak için kullanılan attribute
            // throw new ArgumentNullException(command.FirstName, "First name is required");
            return Ok(await _mediatr.Send(command, cancellationToken));
        }
    }
}
