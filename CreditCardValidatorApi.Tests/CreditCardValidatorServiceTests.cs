using Xunit;
using CreditCardValidatorApi.Application.Services;

namespace CreditCardValidatorApi.Tests
{
    public class CreditCardValidatorServiceTests
    {
        private readonly CreditCardValidatorService _service;

        public CreditCardValidatorServiceTests()
        {
            _service = new CreditCardValidatorService();
        }

        [Theory]
        [InlineData("4532 0151 1283 0366", true)]  // Valid
        [InlineData("8273123273520569", false)] // Invalid
        [InlineData("1234567812345670", true)]  // Valid
        [InlineData("1234567812345678", false)] // Invalid
        [InlineData("49927398716", true)] // Valid
        [InlineData("", false)] // Invalid
        [InlineData(null, false)] // Invalid
        [InlineData("1234abcd5678efgh", false)] // Invalid
        public void ValidateCreditCardNumber_ValidatesCorrectly(string cardNumber, bool expected)
        {
            // Act
            var result = _service.ValidateCreditCardNumber(cardNumber);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
