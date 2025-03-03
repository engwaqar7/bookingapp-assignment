using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace BookingApp.Infrastructure
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        private string _accessToken;
        private DateTime _tokenExpiration;

        private readonly string _authUrl;
        private readonly string _apiBaseUrl;

        private readonly string _clientId;
        private readonly string _clientSecret;

        public ApiClient(IConfiguration config, string provider)
        {
            _client = new HttpClient();

            // Set up API base URL and authentication URL based on the selected provider
            if (provider == "Sabre")
            {
                _authUrl = config["Sabre:AuthUrl"];
                _apiBaseUrl = config["Sabre:ApiBaseUrl"];
                _clientId = config["Sabre:ClientId"];
                _clientSecret = config["Sabre:ClientSecret"];
            }
            else if (provider == "Amadeus")
            {
                _authUrl = config["Amadeus:AuthUrl"];
                _apiBaseUrl = config["Amadeus:ApiBaseUrl"];
                _clientId = config["Amadeus:ClientId"];
                _clientSecret = config["Amadeus:ClientSecret"];
            }
            else
            {
                throw new Exception("Unknown provider.");
            }
        }

        // Method to get the access token from the API
        private async Task<string> GetAccessTokenAsync()
        {
            // If the token is still valid, return it
            if (!string.IsNullOrEmpty(_accessToken) && DateTime.Now < _tokenExpiration)
            {
                return _accessToken;
            }

            // Prepare credentials and request content
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            // Send the POST request to the auth URL to retrieve the access token
            HttpResponseMessage response = await _client.PostAsync(_authUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed to get token: {response.StatusCode}");
                return string.Empty;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            JObject tokenData = JObject.Parse(jsonResponse);
            _accessToken = tokenData["access_token"].ToString();
            int expiresIn = int.Parse(tokenData["expires_in"].ToString());
            _tokenExpiration = DateTime.Now.AddSeconds(expiresIn - 60); // Refresh token 60 seconds before expiry

            return _accessToken;
        }

        // Method to get data from the API (for both Sabre and Amadeus)
        public async Task<string> GetDataFromApiAsync(string endpoint)
        {
            string accessToken = await GetAccessTokenAsync();

            // If access token is empty, use a dummy token
            if (string.IsNullOrEmpty(accessToken))
            {
                accessToken = "dummy_access_token"; // Set a dummy token
                Console.WriteLine("No valid access token found. Using dummy token.");
            }

            // Set the authorization header with the access token (dummy token if the original is empty)
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            // If the token is a dummy token, skip the actual API call
            if (accessToken == "dummy_access_token")
            {
                Console.WriteLine("Bypassing API call and returning dummy response.");
                return "dummy_data"; // Or any dummy response you'd like to return
            }

            // Send the GET request to the API endpoint
            HttpResponseMessage response = await _client.GetAsync(_apiBaseUrl + endpoint);

            // Ensure the response was successful
            response.EnsureSuccessStatusCode();

            // Return the actual API response
            return await response.Content.ReadAsStringAsync();
        }

    }
}
