using DXMauiApp1.Models;
using DXMauiApp1.Services;
using System.Text.Json;

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

            {
                var item = await ContactService.UpdateSearchAsync(ItemId);

                await DisplayAlert("匚匚匚匚", JsonSerializer.Serialize(item), "匚匚匚匚");

                //EntryName.Text = item?.Name;
                //EntryNumber.Text = item?.Number;
            }
        }

        private async void ButtonSubmit_Clicked(object sender, EventArgs e)
        {
            /*
            {
                var item = new ContactModel
                {
                    Id = ItemId,
                    Name = EntryName.Text,
                    Number = EntryNumber.Text
                };
                await ContactService.UpdateAsync(item);
            }
            */
            await Shell.Current.GoToAsync("..");
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}