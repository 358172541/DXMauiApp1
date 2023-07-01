using DXMauiApp1.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DXMauiApp1.Services
{
    public static class ReceiptService
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

        public static async Task<Tuple<ReceiptMakeupModel, ErrorModel>> MakeupSearchAsync(ReceiptMakeupSearchModel searchModel)
        {
            var httpClient = CreateHttpClient();

            var httpResponseMessage = await httpClient.GetAsync("api/mac/receipt/makeup?" + Common.QueryStringify(searchModel));

            return await Common.HttpResponseMessageHandleAsync<ReceiptMakeupModel, ErrorModel>(httpResponseMessage);
        }

        public static async Task<Tuple<EmptyModel, ErrorModel>> MakeupAsync(ReceiptMakeupModel updateModel)
        {
            var httpClient = CreateHttpClient();

            var jsonString = JsonSerializer.Serialize(updateModel,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync("api/mac/receipt/makeup", httpContent);

            return await Common.HttpResponseMessageHandleAsync<EmptyModel, ErrorModel>(httpResponseMessage);
        }
    }
}