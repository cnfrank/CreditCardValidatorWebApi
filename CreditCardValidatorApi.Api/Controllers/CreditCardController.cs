using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using CreditCardValidatorApi.Application.Interfaces;
using System;

namespace CreditCardValidatorApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardValidatorService _creditCardValidatorService;
        private readonly ILogger<CreditCardController> _logger;

        public CreditCardController(ICreditCardValidatorService creditCardValidatorService, ILogger<CreditCardController> logger)
        {
            _creditCardValidatorService = creditCardValidatorService;
            _logger = logger;
        }

        [HttpGet("validate")]
        public IActionResult Validate([FromQuery] string cardNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cardNumber))
                {
                    return BadRequest("Credit card number is required.");
                }

                var isValid = _creditCardValidatorService.ValidateCreditCardNumber(cardNumber);
                return Ok(new { isValid });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while validating credit card.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
