using Microsoft.AspNetCore.Mvc;
using CreditCardValidatorApi.Application.Interfaces;

namespace CreditCardValidatorApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardValidatorService _creditCardValidatorService;

        public CreditCardController(ICreditCardValidatorService creditCardValidatorService)
        {
            _creditCardValidatorService = creditCardValidatorService;
        }

        [HttpGet("validate")]
        public IActionResult Validate([FromQuery] string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                return BadRequest("Credit card number is required.");
            }

            var isValid = _creditCardValidatorService.ValidateCreditCardNumber(cardNumber);
            return Ok(new { isValid });
        }
    }
}
