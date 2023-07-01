using DXMauiApp1.Models;
using DXMauiApp1.Services;

namespace DXMauiApp1.Pages;

public partial class ReceiptMakeupPage : ContentPage
{
    public ReceiptMakeupPage()
    {
        InitializeComponent();
    }

    public long PrimaryKey { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Common.TextEditBaseRequired(TextEditWaybillNumber);
        Common.NumericEditRequired(NumericEditLength);
        Common.NumericEditRequired(NumericEditWidth);
        Common.NumericEditRequired(NumericEditHeight);
        Common.NumericEditRequired(NumericEditWeight);
        Common.TextEditBaseRequired(TextEditMemberNumber);
    }

    private async void TextEditWaybillNumber_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditWaybillNumber);

        if (!string.IsNullOrWhiteSpace(TextEditWaybillNumber.Text))
        {
            var tuple = await ReceiptService.MakeupSearchAsync(
                new ReceiptMakeupSearchModel
                {
                    WaybillNumber = TextEditWaybillNumber.Text
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("ьньньньн", tuple.Item2.Text + "║╦" + tuple.Item2.Code + "║╧", "ьньн");
                return; // todo
            }

            PrimaryKey = tuple.Item1.Id; // required

            NumericEditLength.Value = tuple.Item1.Length;
            NumericEditWidth.Value = tuple.Item1.Width;
            NumericEditHeight.Value = tuple.Item1.Height;
            NumericEditWeight.Value = tuple.Item1.Weight;
            TextEditMemberNumber.Text = tuple.Item1.MemberNumber;

            Common.NumericEditRequired(NumericEditLength);
            Common.NumericEditRequired(NumericEditWidth);
            Common.NumericEditRequired(NumericEditHeight);
            Common.NumericEditRequired(NumericEditWeight);
            Common.TextEditBaseRequired(TextEditMemberNumber);

            return;
        }

        PrimaryKey = default;
        TextEditWaybillNumber.Text = "";
        NumericEditLength.Value = null;
        NumericEditWidth.Value = null;
        NumericEditHeight.Value = null;
        NumericEditWeight.Value = null;
        TextEditMemberNumber.Text = "";
    }

    private void NumericEditLength_ValueChanged(object sender, EventArgs e)
    {
        Common.NumericEditRequired(NumericEditLength);
    }

    private void NumericEditWidth_ValueChanged(object sender, EventArgs e)
    {
        Common.NumericEditRequired(NumericEditWidth);
    }

    private void NumericEditHeight_ValueChanged(object sender, EventArgs e)
    {
        Common.NumericEditRequired(NumericEditHeight);
    }

    private void NumericEditWeight_ValueChanged(object sender, EventArgs e)
    {
        Common.NumericEditRequired(NumericEditWeight);
    }

    private void TextEditMemberNumber_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditMemberNumber);
    }

    private async void ButtonSubmit_Clicked(object sender, EventArgs e)
    {
        if (Common.TextEditBaseRequired(TextEditMemberNumber) &&
            Common.NumericEditRequired(NumericEditLength) &&
            Common.NumericEditRequired(NumericEditWidth) &&
            Common.NumericEditRequired(NumericEditHeight) &&
            Common.NumericEditRequired(NumericEditWeight) &&
            Common.TextEditBaseRequired(TextEditMemberNumber))
        {
            var tuple = await ReceiptService.MakeupAsync(
                new ReceiptMakeupModel
                {
                    Id = PrimaryKey,
                    WaybillNumber = TextEditMemberNumber.Text,
                    Length = NumericEditLength.Value,
                    Width = NumericEditWidth.Value,
                    Height = NumericEditHeight.Value,
                    Weight = NumericEditWeight.Value,
                    MemberNumber = TextEditMemberNumber.Text
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("ьньньньн", tuple.Item2.Text + "║╦" + tuple.Item2.Code + "║╧", "ьньн");
                return;
            }

            PrimaryKey = default;
            TextEditWaybillNumber.Text = "";
            NumericEditLength.Value = null;
            NumericEditWidth.Value = null;
            NumericEditHeight.Value = null;
            NumericEditWeight.Value = null;
            TextEditMemberNumber.Text = "";
        }
    }
}