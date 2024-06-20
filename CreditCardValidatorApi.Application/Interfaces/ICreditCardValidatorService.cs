namespace CreditCardValidatorApi.Application.Interfaces
{
    public interface ICreditCardValidatorService
    {
        bool ValidateCreditCardNumber(string cardNumber);
    }
}
