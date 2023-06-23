using DevExpress.Maui.Editors;

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
    }
}
