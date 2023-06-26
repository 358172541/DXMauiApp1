using DevExpress.Maui.Editors;
using System.Collections;
using System.Reflection;

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

        public static string QueryStringify<T>(T t) // experimental method
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
    }
}