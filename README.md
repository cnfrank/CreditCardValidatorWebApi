# CreditCardValidatorApi

CreditCardValidatorApi is a simple Web API for validating credit card numbers using the Luhn algorithm. This project follows the SOLID principles and includes unit tests for core functionalities.

## Project Structure(CLEAN Architecture)

- `CreditCardValidatorApi.Api`: The Web API project.
- `CreditCardValidatorApi.Application`: Contains application services and interfaces.
- `CreditCardValidatorApi.Domain`: Contains domain entities.
- `CreditCardValidatorApi.Tests`: Contains unit tests.

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Docker (optional, for containerization)
- Visual Studio Code or any other code editor

### Build and Run

#### Using .NET CLI

1. Clone the repository:
   ```sh
   git clone https://github.com/cnfrank/CreditCardValidatorWebApi
   cd CreditCardValidatorApi
2. Restore dependencies:
   ```sh
   dotnet restore
3. Build the project:
   ```sh
   dotnet build
5. Run the application:
   ```sh
    dotnet run --project CreditCardValidatorApi.Api
The API will be available at http://localhost:5000.
#### Using Docker

1. Clone the repository:
   ```sh
   docker-compose up --build
The API will be available at http://localhost:8080.

#### Running Tests
To run the tests, use the following command:
    
    
    dotnet test
    
    
# API Endpoints
GET /api/creditcard/validate?cardNumber={cardNumber}: Validates the provided credit card number.