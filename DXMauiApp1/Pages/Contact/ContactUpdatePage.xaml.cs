using DXMauiApp1.Models;
using DXMauiApp1.Services;
using System;

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

            var tuple = await ContactService.UpdateSearchAsync(ItemId);

            if (tuple.Item2 != null)
            {
                await DisplayAlert("匚匚匚匚", tuple.Item2.Text + "「" + tuple.Item2.Code + "」", "匚匚");
                return; // todo
            }

            TextEditName.Text = tuple.Item1.Name;
            TextEditNumber.Text = tuple.Item1.Number;

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
                var tuple = await ContactService.UpdateAsync(
                    new ContactUpdateModel
                    {
                        Id = ItemId,
                        Name = TextEditName.Text,
                        Number = TextEditNumber.Text
                    });

                if (tuple.Item2 != null)
                {
                    await DisplayAlert("匚匚匚匚", tuple.Item2.Text + "「" + tuple.Item2.Code + "」", "匚匚");
                    return;
                }

                await Shell.Current.GoToAsync("..", true);
            }
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}