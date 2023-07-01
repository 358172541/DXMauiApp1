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

        public static async Task<Tuple<PagedModel<ContactModel>, ErrorModel>> SearchAsync()
        {
            var httpClient = CreateHttpClient();

            var httpResponseMessage = await httpClient.GetAsync("api/mac/contact");

            return await Common.HttpResponseMessageHandleAsync<PagedModel<ContactModel>, ErrorModel>(httpResponseMessage);
        }

        public static async Task<Tuple<EmptyModel, ErrorModel>> CreateAsync(ContactCreateModel createModel)
        {
            var httpClient = CreateHttpClient();

            var jsonString = JsonSerializer.Serialize(createModel,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync("api/mac/contact", httpContent);

            return await Common.HttpResponseMessageHandleAsync<EmptyModel, ErrorModel>(httpResponseMessage);
        }

        public static async Task<Tuple<ContactUpdateModel, ErrorModel>> UpdateSearchAsync(long id)
        {
            var httpClient = CreateHttpClient();

            var httpResponseMessage = await httpClient.GetAsync("api/mac/contact/" + id);

            return await Common.HttpResponseMessageHandleAsync<ContactUpdateModel, ErrorModel>(httpResponseMessage);
        }

        public static async Task<Tuple<EmptyModel, ErrorModel>> UpdateAsync(ContactUpdateModel updateModel)
        {
            var httpClient = CreateHttpClient();

            var jsonString = JsonSerializer.Serialize(updateModel,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PutAsync("api/mac/contact/" + updateModel.Id, httpContent);

            return await Common.HttpResponseMessageHandleAsync<EmptyModel, ErrorModel>(httpResponseMessage);
        }
    }
}