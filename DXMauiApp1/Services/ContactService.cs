using DXMauiApp1.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DXMauiApp1.Services
{
    public static class ContactService
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

        public static async Task<PagedModel<ContactModel>> SearchAsync()
        {
            var httpClient = CreateHttpClient();

            var httpResponseMessage = await httpClient.GetAsync("api/mac/contact");

            httpResponseMessage.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<PagedModel<ContactModel>>(
                await httpResponseMessage.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public static async Task CreateAsync(ContactModel model)
        {
            var httpClient = CreateHttpClient();

            var httpContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync("api/mac/contact", httpContent);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public static async Task<ContactModel> UpdateSearchAsync(long id)
        {
            var httpClient = CreateHttpClient();

            var httpResponseMessage = await httpClient.GetAsync("api/mac/contact/" + id);

            httpResponseMessage.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ContactModel>(
                await httpResponseMessage.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public static async Task UpdateAsync(ContactModel model)
        {
            var httpClient = CreateHttpClient();

            var httpContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PutAsync("api/mac/contact/" + model.Id, httpContent);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}