using DevExpress.Maui.Editors;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace DXMauiApp1
{
    public static class Common
    {
        public static JsonSerializerOptions JsonSerializerOptions
        {
            get
            {
                return new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
            }
        }

        public static bool TextEditBaseRequired( // MultilineEdit、PasswordEdit、TextEdit
            TextEditBase textEditBase,
            string errorText = "必填项不能为空")
        {
            if (string.IsNullOrWhiteSpace(textEditBase.Text))
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

        public static bool NumericEditRequired( // NumericEdit
            NumericEdit numericEdit,
            string errorText = "必填项不能为空")
        {
            if (numericEdit.Value == null)
            {
                numericEdit.ErrorText = errorText;
                numericEdit.HasError = true;
                return false;
            }
            else
            {
                numericEdit.ErrorText = " ";
                numericEdit.HasError = false;
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
                        JsonSerializerOptions);
            }
            else
            {
                item2 = JsonSerializer.Deserialize<TItem2>(
                    await httpResponseMessage.Content.ReadAsStringAsync(), 
                    JsonSerializerOptions);
            }

            return Tuple.Create(item1, item2);
        }

        public static decimal Volume(decimal cmL, decimal cmW, decimal cmH, int piece = 1)
        {
            return Math.Ceiling(cmL * cmW * cmH * piece / 1000000m * 10000m) / 10000m;
        }
    }
}