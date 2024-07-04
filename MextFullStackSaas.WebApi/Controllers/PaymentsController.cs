using MediatR;
using MextFullStackSaas.Application.Features.Payments.Commands.CreatePaymentForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStackSaas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ISender _mediatr;

        public PaymentsController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentFormAsync(CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new PaymentCreatePaymentFormCommand(), cancellationToken));
        }

        [HttpPost("payment-result")]
        public async Task<IActionResult> PaymentResultAsync([FromForm] string token, CancellationToken cancellationToken)
        {
            return Redirect($"http://localhost:5262/payment-success?token={token}");
        }

    }
}
