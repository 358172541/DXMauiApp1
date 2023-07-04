using DevExpress.Maui.DataGrid;
using DXMauiApp1.Models;
using DXMauiApp1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;

namespace DXMauiApp1.Pages;

public partial class Packag1120UpdatePage : ContentPage
{
    public Packag1120UpdatePage()
    {
        InitializeComponent();
    }

    public long PrimaryKey { get; set; } = default;

    public List<SizeModel> SizeLs { get; set; } = new List<SizeModel>();

    protected override void OnAppearing()
    {
        base.OnAppearing();

        TextEditWaybillNumber.Text = "M202305160919476";

        Common.TextEditBaseRequired(TextEditWaybillNumber);
        Common.TextEditBaseRequired(TextEditLocation);
        Common.TextEditBaseRequired(MultilineEditCargoDescription);
        Common.NumericEditRequired(NumericEditVolume);
    }

    private async void ButtonSearch_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TextEditWaybillNumber.Text))
        {
            var tuple = await Packag1120Service.UpdateSearchAsync(
                new Packag1120UpdateSearchModel
                {
                    WaybillNumber = TextEditWaybillNumber.Text
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("匚匚匚匚", tuple.Item2.Text + "「" + tuple.Item2.Code + "」", "匚匚");
                return;
            }

            PrimaryKey = tuple.Item1.Id; // required

            TextEditLocation.Text = tuple.Item1.Location;
            MultilineEditCargoDescription.Text = tuple.Item1.CargoDescription;
            NumericEditVolume.Value = tuple.Item1.Volume;

            Common.TextEditBaseRequired(TextEditLocation);
            Common.TextEditBaseRequired(MultilineEditCargoDescription);
            Common.NumericEditRequired(NumericEditVolume);

            SizeLs = JsonSerializer.Deserialize<List<SizeModel>>(tuple.Item1.SizeLs, Common.JsonSerializerOptions);

            DataGridViewSizeLs.ItemsSource = new ObservableCollection<SizeModel>(SizeLs);
            LabelTotalVolume.Text = SizeLs.Sum(x => Common.Volume(x.L, x.W, x.H, x.P)) + " M³";

            return;
        }

        Clear();
    }

    private void TextEditWaybillNumber_ClearIconClicked(object sender, HandledEventArgs e)
    {
        Clear();
    }

    private void TextEditWaybillNumber_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditWaybillNumber);
    }

    private void TextEditLocation_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditLocation);
    }

    private void MultilineEditCargoDescription_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(MultilineEditCargoDescription);
    }

    private void NumericEditVolume_ValueChanged(object sender, EventArgs e)
    {
        Common.NumericEditRequired(NumericEditVolume);
    }

    private void ButtonCreate_Clicked(object sender, EventArgs e)
    {
        SizeLs.Add(new SizeModel
        {
            H = 111,
            L = 111,
            P = 1,
            V = 1.3677m,
            W = 111
        });

        DataGridViewSizeLs.ItemsSource = new ObservableCollection<SizeModel>(SizeLs);
        LabelTotalVolume.Text = SizeLs.Sum(x => Common.Volume(x.L, x.W, x.H, x.P)) + " M³";

        NumericEditVolume.Value = SizeLs.Sum(x => Common.Volume(x.L, x.W, x.H, x.P));
    }

    private void SwipeItemDelete_Tap(object sender, SwipeItemTapEventArgs e)
    {
        SizeLs.RemoveAt(e.RowHandle);

        DataGridViewSizeLs.ItemsSource = new ObservableCollection<SizeModel>(SizeLs);
        LabelTotalVolume.Text = SizeLs.Sum(x => Common.Volume(x.L, x.W, x.H, x.P)) + " M³";

        NumericEditVolume.Value = SizeLs.Sum(x => Common.Volume(x.L, x.W, x.H, x.P));
    }

    private async void ButtonSubmit_Clicked(object sender, EventArgs e)
    {
        if (Common.TextEditBaseRequired(TextEditLocation) &&
            Common.TextEditBaseRequired(MultilineEditCargoDescription) &&
            Common.NumericEditRequired(NumericEditVolume))
        {
            var tuple = await Packag1120Service.UpdateAsync(
                new Packag1120UpdateModel
                {
                    Id = PrimaryKey,
                    CargoDescription = MultilineEditCargoDescription.Text,
                    Location = TextEditLocation.Text,
                    SizeLs = JsonSerializer.Serialize(SizeLs, Common.JsonSerializerOptions),
                    Volume = NumericEditVolume.Value
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("匚匚匚匚", tuple.Item2.Text + "「" + tuple.Item2.Code + "」", "匚匚");
                return;
            }

            Clear();
        }
    }

    private void Clear()
    {
        PrimaryKey = default;
        TextEditWaybillNumber.Text = string.Empty;
        TextEditLocation.Text = string.Empty;
        MultilineEditCargoDescription.Text = string.Empty;
        NumericEditVolume.Value = null;

        SizeLs = new List<SizeModel>();

        DataGridViewSizeLs.ItemsSource = new ObservableCollection<SizeModel>(SizeLs);
        LabelTotalVolume.Text = SizeLs.Sum(x => Math.Ceiling(x.L * x.W * x.H * x.P / 1000000m * 10000m) / 10000m) + " M³";
    }
}