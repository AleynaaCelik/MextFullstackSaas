using MediatR;
using MextFullStackSaas.Application.Features.Orders.Queries.GetById;
using MextFullStackSaas.Application.Features.Users.Queries.GetProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStackSaas.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediatr;


        public UsersController(ISender mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileAsync(CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new UserGetProfileQuery(), cancellationToken));
        }
    }
}