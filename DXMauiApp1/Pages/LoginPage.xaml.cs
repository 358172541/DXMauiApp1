using DevExpress.Maui.Editors;

namespace DXMauiApp1.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TextEditBaseRequired(TextEditAccount);
            TextEditBaseRequired(PasswordEditPassword);
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            if (TextEditBaseRequired(TextEditAccount) &&
                TextEditBaseRequired(PasswordEditPassword))
            {
                await DisplayAlert("ьньньньн", "ьньньньньньньньн", "ьньн");

                Preferences.Set("AccessToken", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0MTU1NjI5MzQzNTgwMjEiLCJpc3MiOiJpc3NtYWMiLCJhdWQiOiJhdWQifQ.ESzy8sTofOTo9_lF97AGiYFI5pMF3dJrRUD4Vx7Pzyc");

                await Shell.Current.GoToAsync("///" + nameof(ContactPage));
            }
        }

        private void TextEditAccount_TextChanged(object sender, EventArgs e)
        {
            TextEditBaseRequired(TextEditAccount);
        }

        private void PasswordEditPassword_TextChanged(object sender, EventArgs e)
        {
            TextEditBaseRequired(PasswordEditPassword);
        }

        public static bool TextEditBaseRequired(
            TextEditBase textEditBase)
        {
            if (string.IsNullOrEmpty(textEditBase.Text))
            {
                textEditBase.ErrorText = "ьньньньньньньньн";
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