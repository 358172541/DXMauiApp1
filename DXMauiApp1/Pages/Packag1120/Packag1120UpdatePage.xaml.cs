using DXMauiApp1.Models;
using DXMauiApp1.Services;

namespace DXMauiApp1.Pages;

public partial class Packag1120UpdatePage : ContentPage
{
    public Packag1120UpdatePage()
    {
        InitializeComponent();
    }

    public long PrimaryKey { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Common.TextEditBaseRequired(TextEditWaybillNumber);
        Common.TextEditBaseRequired(TextEditLocation);
        Common.TextEditBaseRequired(MultilineEditCargoDescription);
        Common.NumericEditRequired(NumericEditVolume);
    }

    private async void TextEditWaybillNumber_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditWaybillNumber);

        if (!string.IsNullOrWhiteSpace(TextEditWaybillNumber.Text))
        {
            var tuple = await Packag1120Service.UpdateSearchAsync(
                new Packag1120UpdateSearchModel
                {
                    WaybillNumber = TextEditWaybillNumber.Text
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("ьньньньн", tuple.Item2.Text + "║╦" + tuple.Item2.Code + "║╧", "ьньн");
                return;
            }

            PrimaryKey = tuple.Item1.Id; // required

            TextEditLocation.Text = tuple.Item1.Location;
            MultilineEditCargoDescription.Text = tuple.Item1.CargoDescription;
            NumericEditVolume.Value = tuple.Item1.Volume;

            Common.TextEditBaseRequired(TextEditLocation);
            Common.TextEditBaseRequired(MultilineEditCargoDescription);
            Common.NumericEditRequired(NumericEditVolume);

            // sizeLs

            return;
        }

        PrimaryKey = default;
        TextEditWaybillNumber.Text = "";
        TextEditLocation.Text = "";
        MultilineEditCargoDescription.Text = "";
        NumericEditVolume.Value = null;

        // sizeLs
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

    }

    private void SwipeItemDelete_Tap(object sender, DevExpress.Maui.DataGrid.SwipeItemTapEventArgs e)
    {

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
                    SizeLs = "[]",
                    Volume = NumericEditVolume.Value
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("ьньньньн", tuple.Item2.Text + "║╦" + tuple.Item2.Code + "║╧", "ьньн");
                return;
            }

            PrimaryKey = default;
            TextEditWaybillNumber.Text = "";
            TextEditLocation.Text = "";
            MultilineEditCargoDescription.Text = "";
            NumericEditVolume.Value = null;

            // sizeLs
        }
    }
}