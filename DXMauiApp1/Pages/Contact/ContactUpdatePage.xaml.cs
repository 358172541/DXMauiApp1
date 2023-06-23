using DXMauiApp1.Models;
using DXMauiApp1.Services;

namespace DXMauiApp1.Pages
{
    [QueryProperty(nameof(ItemId), "id")]
    public partial class ContactUpdatePage : ContentPage
    {
        public ContactUpdatePage()
        {
            InitializeComponent();
        }

        public long ItemId { get; set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var item = await ContactService.UpdateSearchAsync(ItemId);
            TextEditName.Text = item?.Name;
            TextEditNumber.Text = item?.Number;

            Common.TextEditBaseRequired(TextEditName);
            Common.TextEditBaseRequired(TextEditNumber);
        }

        private void TextEditName_TextChanged(object sender, EventArgs e)
        {
            Common.TextEditBaseRequired(TextEditName);
        }

        private void TextEditNumber_TextChanged(object sender, EventArgs e)
        {
            Common.TextEditBaseRequired(TextEditNumber);
        }

        private async void ButtonSubmit_Clicked(object sender, EventArgs e)
        {
            if (Common.TextEditBaseRequired(TextEditName) &&
                Common.TextEditBaseRequired(TextEditNumber))
            {
                var item = new ContactModel
                {
                    Id = ItemId,
                    Name = TextEditName.Text,
                    Number = TextEditNumber.Text
                };

                await ContactService.UpdateAsync(item);

                await Shell.Current.GoToAsync("..");
            }
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}