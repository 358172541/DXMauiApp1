using DevExpress.Maui.DataGrid;
using System.Collections.ObjectModel;

namespace DXMauiApp1.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public List<SizeModel> SizeLs { get; set; } = new List<SizeModel>();

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SizeLs = new List<SizeModel>
            {
                new SizeModel {
                    H = 101,
                    L = 101,
                    P = 1,
                    V = 75.0001m,
                    W = 101
                },
                new SizeModel {
                    H = 200,
                    L = 200,
                    P = 1,
                    V = 75.0001m,
                    W = 200
                }
            };

            DataGridView.ItemsSource = new ObservableCollection<SizeModel>(SizeLs);
        }

        private void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            SizeLs.Add(new SizeModel
            {
                H = 200,
                L = 200,
                P = 1,
                V = 75.0001m,
                W = 200
            });

            DataGridView.ItemsSource = new ObservableCollection<SizeModel>(SizeLs);
        }

        private void SwipeItemDelete_Tap(object sender, SwipeItemTapEventArgs e)
        {
            // var item = e.Item as SizeModel;

            SizeLs.RemoveAt(e.RowHandle);

            DataGridView.ItemsSource = new ObservableCollection<SizeModel>(SizeLs);
        }
    }

    public class SizeModel
    {
        public int H { get; set; }

        public int L { get; set; }

        public int P { get; set; }

        public decimal V { get; set; }

        public int W { get; set; }
    }
}