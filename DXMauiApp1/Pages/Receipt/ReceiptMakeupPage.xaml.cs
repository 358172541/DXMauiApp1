using DXMauiApp1.Models;
using DXMauiApp1.Services;

namespace DXMauiApp1.Pages;

public partial class ReceiptMakeupPage : ContentPage
{
    public ReceiptMakeupPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        TextEditWaybillNumber.Text = "111111111";

        Common.TextEditBaseRequired(TextEditWaybillNumber);
        Common.NumericEditRequired(NumericEditLength);
        Common.NumericEditRequired(NumericEditWidth);
        Common.NumericEditRequired(NumericEditHeight);
        Common.NumericEditRequired(NumericEditWeight);
        Common.TextEditBaseRequired(TextEditMemberMark);
        Common.TextEditBaseRequired(TextEditMemberNumber);
    }

    private async void ButtonSearch_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TextEditWaybillNumber.Text))
        {
            var tuple = await ReceiptService.MakeupSearchAsync(
                new ReceiptMakeupSearchModel
                {
                    WaybillNumber = TextEditWaybillNumber.Text
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("��" + tuple.Item2.Code + "��", tuple.Item2.Text, "����");
                return; // todo
            }

            NumericEditLength.Value = tuple.Item1.Length;
            NumericEditWidth.Value = tuple.Item1.Width;
            NumericEditHeight.Value = tuple.Item1.Height;
            NumericEditWeight.Value = tuple.Item1.Weight;
            TextEditMemberMark.Text = tuple.Item1.MemberMark;
            TextEditMemberNumber.Text = tuple.Item1.MemberNumber;

            Common.NumericEditRequired(NumericEditLength);
            Common.NumericEditRequired(NumericEditWidth);
            Common.NumericEditRequired(NumericEditHeight);
            Common.NumericEditRequired(NumericEditWeight);
            Common.TextEditBaseRequired(TextEditMemberMark);
            Common.TextEditBaseRequired(TextEditMemberNumber);

            return;
        }

        Clear();
    }

    private void TextEditWaybillNumber_ClearIconClicked(object sender, System.ComponentModel.HandledEventArgs e)
    {
        Clear();
    }

    private void TextEditWaybillNumber_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditWaybillNumber);
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

    private void TextEditMemberMark_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditMemberMark);
    }

    private void TextEditMemberNumber_TextChanged(object sender, EventArgs e)
    {
        Common.TextEditBaseRequired(TextEditMemberNumber);
    }

    private void Clear()
    {
        TextEditWaybillNumber.Text = string.Empty;
        NumericEditLength.Value = null;
        NumericEditWidth.Value = null;
        NumericEditHeight.Value = null;
        NumericEditWeight.Value = null;
        TextEditMemberMark.Text = string.Empty;
        TextEditMemberNumber.Text = string.Empty;
    }

    private async void ButtonSubmit_Clicked(object sender, EventArgs e)
    {
        if (Common.TextEditBaseRequired(TextEditWaybillNumber) &&
            Common.NumericEditRequired(NumericEditLength) &&
            Common.NumericEditRequired(NumericEditWidth) &&
            Common.NumericEditRequired(NumericEditHeight) &&
            Common.NumericEditRequired(NumericEditWeight) &&
            Common.TextEditBaseRequired(TextEditMemberMark) &&
            Common.TextEditBaseRequired(TextEditMemberNumber))
        {
            var tuple = await ReceiptService.MakeupAsync(
                new ReceiptMakeupModel
                {
                    WaybillNumber = TextEditWaybillNumber.Text,
                    Length = NumericEditLength.Value,
                    Width = NumericEditWidth.Value,
                    Height = NumericEditHeight.Value,
                    Weight = NumericEditWeight.Value,
                    MemberMark = TextEditMemberMark.Text,
                    MemberNumber = TextEditMemberNumber.Text
                });

            if (tuple.Item2 != null)
            {
                await DisplayAlert("��" + tuple.Item2.Code + "��", tuple.Item2.Text, "����");
                return;
            }

            Clear();
        }
    }
}