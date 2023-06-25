using DXMauiApp1.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DXMauiApp1.Services
{
    public static class AdminService
    {
        private static HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://api.ydwl168.com");

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var accessToken = Preferences.Get("AccessToken", string.Empty);

            if (!string.IsNullOrEmpty(accessToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return httpClient;
        }

        public static async Task<TokenModel> LoginAsync(AdminLoginModel loginModel)
        {
            var httpClient = CreateHttpClient();

            var httpContent = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync("api/mac/contact", httpContent);

            httpResponseMessage.EnsureSuccessStatusCode();

            // if(httpResponseMessage.IsSuccessStatusCode) // todo

            return JsonSerializer.Deserialize<TokenModel>(
                await httpResponseMessage.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
