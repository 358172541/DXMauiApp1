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

            Common.TextEditBaseRequired(TextEditAccount);
            Common.TextEditBaseRequired(PasswordEditPassword);
        }

        private void TextEditAccount_TextChanged(object sender, EventArgs e)
        {
            Common.TextEditBaseRequired(TextEditAccount);
        }

        private void PasswordEditPassword_TextChanged(object sender, EventArgs e)
        {
            Common.TextEditBaseRequired(PasswordEditPassword);
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            if (Common.TextEditBaseRequired(TextEditAccount) &&
                Common.TextEditBaseRequired(PasswordEditPassword))
            {
                await DisplayAlert("ьньньньн", "ьньньньньньньньн", "ьньн");

                Preferences.Set("AccessToken", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0MTU1NjI5MzQzNTgwMjEiLCJpc3MiOiJpc3NtYWMiLCJhdWQiOiJhdWQifQ.ESzy8sTofOTo9_lF97AGiYFI5pMF3dJrRUD4Vx7Pzyc");

                await Shell.Current.GoToAsync("///" + nameof(ContactPage));
            }
        }
    }
}