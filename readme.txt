BookingApp
This is a  booking application that allows you to search for flights and hotels using different service providers like Amadeus and Sabre. The application integrates with the respective APIs to retrieve data, and provides a clean, reusable architecture using factories, interfaces, and model parsing.

Table of Contents
Prerequisites
Installation
Configuration
Usage
Project Structure
Additional Notes
Prerequisites
Before getting started, make sure you have the following tools installed:

.NET Core 3.1 or higher
Visual Studio 2019 or Visual Studio Code (or any IDE of your choice)
NuGet packages:
Newtonsoft.Json (for parsing JSON responses)
Microsoft.Extensions.Configuration.Json (for reading configuration files)
Installation
To install and set up the project:

Clone the repository:
bash
Copy
git clone https://github.com/yourusername/bookingapp.git
Navigate into the project directory:
bash
Copy
cd bookingapp
Restore the project dependencies:
bash
Copy
dotnet restore
Build the project:
bash
Copy
dotnet build
Configuration
To configure the API credentials for the Amadeus and Sabre providers, update the appsettings.json file located in the root of the project directory.

Example appsettings.json:
json
Copy
{
  "Sabre": {
    "ClientId": "your_sabre_client_id",
    "ClientSecret": "your_sabre_client_secret",
    "AuthUrl": "https://api.sabre.com/v2/auth/token",
    "ApiBaseUrl": "https://api.sabre.com/v1/shop"
  },
  "Amadeus": {
    "ClientId": "your_amadeus_client_id",
    "ClientSecret": "your_amadeus_client_secret",
    "AuthUrl": "https://api.amadeus.com/v1/security/oauth2/token",
    "ApiBaseUrl": "https://api.amadeus.com/v1/shop"
  }
}
Make sure to replace the values of "ClientId" and "ClientSecret" with your actual API credentials from the Amadeus and Sabre platforms.

Usage
Running the Application
To start the application, use the following command in your terminal:

bash
Copy
dotnet run
This will execute the program, and you will be prompted to:

Select the service provider: Choose between Sabre or Amadeus.
Select the type of search: Choose whether you want to search for flights or hotels.
Provide search parameters: For flights, you’ll be asked for the departure city, arrival city, and departure date. For hotels, you’ll be asked for the city name.
Project Structure
Here is an overview of the project structure:

bash
Copy
/BookingApp
│
├── /BookingApp
│   ├── /Models
│   │   ├── Flight.cs
│   │   └── Hotel.cs
│   ├── /Infrastructure
│   │   ├── /Providers
│   │   │   ├── AmadeusServiceProvider.cs
│   │   │   └── SabreServiceProvider.cs
│   │   ├── ApiClient.cs
│   │   ├── ModelParser.cs
│   │   └── IServiceProvider.cs
│   	├── /Factories
	│   │   ├── IServiceProviderFactory.cs
	│   │   ├── ServiceProviderFactory.cs
	│   │   ├── ISearchServiceFactory.cs
	│   │   └── SearchServiceFactory.cs
│   ├── /Services
│   │   ├── FlightSearchService.cs
│   │   └── HotelSearchService.cs
│   │   └── ISearchService.cs
│   ├── /Program.cs
│   └── /appsettings.json
└── /README.md
Key Files:
Program.cs: Entry point for the application. Handles user input, service provider selection, and search initiation.
ApiClient.cs: Handles communication with the Amadeus and Sabre APIs, including token management and API requests.
ModelParser.cs: Contains the common logic to parse Flight and Hotel data from JSON responses into the respective model objects.
IServiceProvider.cs: Defines the interface that each service provider (Amadeus, Sabre) must implement.
AmadeusServiceProvider.cs and SabreServiceProvider.cs: Implement the service provider logic for searching flights and hotels.
ServiceProviderFactory.cs: A factory that resolves the correct service provider (Sabre/Amadeus) based on user input.
SearchServiceFactory.cs: A factory that resolves either flight search or hotel search based on user input.
appsettings.json: Holds configuration data for API credentials and base URLs.
Additional Notes
Handling Token Expiration:

The ApiClient class automatically manages access tokens. The token is requested once, stored, and refreshed as needed (i.e., when it expires).
Error Handling:

Proper error handling is in place for invalid API responses. However, additional checks and exceptions may be added as required.
Extending the Application:

To add another service provider, simply implement a new provider class that conforms to the IServiceProvider interface. Then, update the ServiceProviderFactory to resolve the new provider.
Improving Search Functionality:

Currently, the application supports flight and hotel searches. If you need to add more search types (e.g., car rentals), add a new method in the IServiceProvider interface and implement the logic in the respective provider classes.
API Quotas and Rate Limiting:

I've added a fallback case that returns dummy data if the token is invalid or if there's an error. This is solely for testing purposes.

Be mindful of the rate limits imposed by Amadeus and Sabre. If needed, implement back-off logic or check for the status code of each API call to handle rate limits gracefully.