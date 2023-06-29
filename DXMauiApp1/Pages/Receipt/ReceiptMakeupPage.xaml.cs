using DXMauiApp1.Models;
using DXMauiApp1.Services;

namespace DXMauiApp1.Pages;

public partial class ReceiptMakeupPage : ContentPage
{
	public ReceiptMakeupPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ReceiptService.MakeupSearchAsync(new ReceiptMakeupSearchModel { WaybillNumber = "416959517323269" });

        var tuple = await ReceiptService.MakeupSearchAsync(new ReceiptMakeupSearchModel { WaybillNumber = "416959517323269" });

        if (tuple.Item2 != null)
        {
            await DisplayAlert("ьньньньн", tuple.Item2.Text + "║╦" + tuple.Item2.Code + "║╧", "ьньн");
            return; // todo
        }

        /*
         
        TextEditName.Text = tuple.Item1?.Name;
        TextEditNumber.Text = tuple.Item1?.Number;

        Common.TextEditBaseRequired(TextEditName);
        Common.TextEditBaseRequired(TextEditNumber);

         */
    }
}