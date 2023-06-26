using DevExpress.Maui.Editors;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace DXMauiApp1
{
    public static class Common
    {
        public static bool TextEditBaseRequired(
            TextEditBase textEditBase,
            string errorText = "匚匚匚匚匚匚匚")
        {
            if (string.IsNullOrEmpty(textEditBase.Text))
            {
                textEditBase.ErrorText = errorText;
                textEditBase.HasError = true;
                return false;
            }
            else
            {
                textEditBase.ErrorText = " ";
                textEditBase.HasError = false;
                return true;
            }
        }

        public static string QueryStringify<T>(T t) // experimental
        {
            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetValue(t) != null)
                .ToDictionary(k => k.Name, v => v.GetValue(t));

            var items = new List<string>();

            foreach (var property in properties)
            {
                var key = char.ToLower(property.Key[0]) + property.Key[1..];

                var value = property.Value;

                if (value.GetType().IsGenericType &&
                    value.GetType().GetGenericTypeDefinition() == typeof(List<>)) // limits List<>
                {
                    var index = 0;

                    foreach (var item in (IEnumerable)value)
                    {
                        items.Add($"{key}[{index}]={item}");
                        index++;
                    }
                }
                else
                {
                    items.Add($"{key}={value}");
                }
            }

            return string.Join("&", items);
        }

        public static async Task<Tuple<TItem1, TItem2>> HttpResponseMessageHandleAsync<TItem1, TItem2>(
            HttpResponseMessage httpResponseMessage)
            where TItem1 : class
            where TItem2 : class // experimental
        {
            var item1 = default(TItem1);
            var item2 = default(TItem2);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                    item1 = JsonSerializer.Deserialize<TItem1>(
                        await httpResponseMessage.Content.ReadAsStringAsync(),
                        new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                item2 = JsonSerializer.Deserialize<TItem2>(
                    await httpResponseMessage.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            return Tuple.Create(item1, item2);
        }
    }
}