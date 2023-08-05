using DXMauiApp1.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DXMauiApp1.Services
{
    public static class Packag1120Service
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

        public static async Task<Tuple<Packag1120UpdateModel, ErrorModel>> SingleSearchAsync(Packag1120UpdateSearchModel searchModel)
        {
            var httpClient = CreateHttpClient();

            var httpResponseMessage = await httpClient.GetAsync("api/mac/packag1120/single?" + Common.QueryStringify(searchModel));

            return await Common.HttpResponseMessageHandleAsync<Packag1120UpdateModel, ErrorModel>(httpResponseMessage);
        }

        public static async Task<Tuple<EmptyModel, ErrorModel>> UpdateAsync(Packag1120UpdateModel updateModel)
        {
            var httpClient = CreateHttpClient();

            var jsonString = JsonSerializer.Serialize(updateModel, Common.JsonSerializerOptions);

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PutAsync("api/mac/packag1120/"+ updateModel.Id, httpContent);

            return await Common.HttpResponseMessageHandleAsync<EmptyModel, ErrorModel>(httpResponseMessage);
        }
    }
}