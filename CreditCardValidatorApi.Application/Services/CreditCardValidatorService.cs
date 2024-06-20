using System.Linq;
using CreditCardValidatorApi.Application.Interfaces;

namespace CreditCardValidatorApi.Application.Services
{
    /// <summary>
    /// Implementation of ICreditCardValidatorService to validate credit card numbers.
    /// </summary>
    public class CreditCardValidatorService : ICreditCardValidatorService
    {
        public bool ValidateCreditCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return false;

            // Check if the card number contains only digits or whitespace
            if (!cardNumber.All(c => char.IsDigit(c) || char.IsWhiteSpace(c)))
                return false;

            // Remove leading and trailing whitespace and check the length
            if (cardNumber.Trim().Length < 2)
                return false;

            // Apply the Luhn algorithm to validate the credit card number
            return cardNumber
                .Reverse()                           // Reverse the sequence of characters
                .Where(char.IsDigit)                 // Keep only digit characters
                .Select(c => (int)char.GetNumericValue(c)) // Convert characters to numeric values
                .Select((n, i) => ((i % 2) == 0) ? n : n * 2) // Double every second digit from the right
                .Select(n => n > 9 ? n - 9 : n)      // If the doubled value is greater than 9, subtract 9
                .Sum() % 10 == 0;                    // Sum all values and check if the total modulo 10 is 0
        }
    }
}
