using DXMauiApp1.Models;
using DXMauiApp1.Services;

namespace DXMauiApp1.Pages
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            {
                var items = (await ContactService.SearchAsync()).Items;
                DXCollectionViewContact.ItemsSource = items; // new ObservableCollection<ContactModel>(items); // load
            }
        }

        private async void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ContactCreatePage));
        }

        private async void DXCollectionViewContact_Tap(object sender, DevExpress.Maui.CollectionView.CollectionViewGestureEventArgs e)
        {
            var item = DXCollectionViewContact.SelectedItem as ContactModel;

            await Shell.Current.GoToAsync(nameof(ContactUpdatePage) + "?id=" + item.Id);
        }
    }
}