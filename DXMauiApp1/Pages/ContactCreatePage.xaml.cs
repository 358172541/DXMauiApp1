namespace DXMauiApp1.Pages
{
    public partial class ContactCreatePage : ContentPage
    {
        public ContactCreatePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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