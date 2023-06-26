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
                var tuple = await ContactService.SearchAsync();

                if (tuple.Item2 != null)
                {
                    await DisplayAlert("匚匚匚匚", tuple.Item2.Text + "「" + tuple.Item2.Code + "」", "匚匚");
                    return; // todo
                }

                DXCollectionViewContact.ItemsSource = tuple.Item1?.Items; // new ObservableCollection<ContactModel>(items); // load
            }
        }

        private async void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ContactCreatePage), true);
        }

        private async void DXCollectionViewContact_Tap(object sender, DevExpress.Maui.CollectionView.CollectionViewGestureEventArgs e)
        {
            var item = DXCollectionViewContact.SelectedItem as ContactModel;

            await Shell.Current.GoToAsync(nameof(ContactUpdatePage) + "?id=" + item.Id, true);
        }
    }
}