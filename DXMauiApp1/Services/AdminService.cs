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

        public static async Task<Tuple<TokenModel, ErrorModel>> LoginAsync(AdminLoginModel loginModel)
        {
            var httpClient = CreateHttpClient();

            var httpContent = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync("api/mac/admin/login", httpContent); // handle exception

            return await Common.HttpResponseMessageHandleAsync<TokenModel, ErrorModel>(httpResponseMessage);
        }
    }
}
