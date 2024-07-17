using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TripSite.Models;
using TripSite.ViewModel;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private string _jwtToken;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> Login(string username, string password)
    {
        var loginModel = new LoginViewModel { Username = username, Password = password };

        var response = await _httpClient
            .PostAsJsonAsync("http://localhost:5297/api/authentication/login", loginModel);

        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _jwtToken = tokenResponse.Token;
            return _jwtToken;
        }

        return null;
    }
    public async Task<string> Register(RegisterViewModel model)
    {
        CreateUserModel data = new CreateUserModel
        {
            UserName = model.UserName,
            Role = model.Role,
            Email = model.Email,
            Password = model.Password,
            ConfirmPassword = model.ConfirmPassword,
            FullName = model.FullName,
            PhoneNumber = model.PhoneNumber,
            Gender = model.Gender
        };
        var response = await _httpClient.
            PostAsJsonAsync("http://localhost:5297/api/authentication/CreateUser", data);
        if (!response.IsSuccessStatusCode) {
            return response.ToString();
        }
        return response.ToString();
    }
    public void SetJwtToken(string token)
    {
        _jwtToken = token;
    }

    public string GetJwtToken()
    {
        return _jwtToken;
    }
}

public class TokenResponse
{
    public string Token { get; set; }
}

