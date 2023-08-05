using DXMauiApp1.Models;
using DXMauiApp1.Services;

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

            TextEditAccount.Text = "admin";
            PasswordEditPassword.Text = "1q2w3E*";

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
                try
                {
                    var tuple = await AdminService.LoginAsync(
                    new AdminLoginModel
                    {
                        Account = TextEditAccount.Text,
                        Password = PasswordEditPassword.Text
                    });

                    if (tuple.Item2 != null)
                    {
                        await DisplayAlert("¡¸" + tuple.Item2.Code + "¡¹", tuple.Item2.Text, "ØÎØÎ");
                        return;
                    }

                    Preferences.Set("AccessToken", tuple.Item1.AccessToken);

                    await Shell.Current.GoToAsync("///" + nameof(ReceiptMakeupPage), true);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("¡¸¡¹", ex.Message, "ØÎØÎ");
                }
            }
        }
    }
}